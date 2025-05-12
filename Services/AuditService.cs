using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SIMS.Web.Data;
using SIMS.Web.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SIMS.Web.Services
{
    public class AuditService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditService(
            ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task LogActionAsync(string actionType, string actionDetails)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var username = httpContext?.User?.Identity?.Name ?? "System";
            var userType = "Unknown";

            if (httpContext?.User?.Identity?.IsAuthenticated == true)
            {
                if (httpContext.User.IsInRole("Admin"))
                    userType = "Admin";
                else if (httpContext.User.IsInRole("Staff"))
                    userType = "Staff";
                else if (httpContext.User.IsInRole("Student"))
                    userType = "Student";
            }

            var ipAddress = httpContext?.Connection?.RemoteIpAddress?.ToString() ?? "0.0.0.0";

            var auditEntry = new AuditTrail
            {
                DtTim = DateTime.Now,
                Username = username,
                Usertyp = userType,
                IpAdd = ipAddress,
                TransactionTyp = actionType,
                TransactionVal = actionDetails
            };

            _context.AuditTrails.Add(auditEntry);
            await _context.SaveChangesAsync();
        }
    }
}
