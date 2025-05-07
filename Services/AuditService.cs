using Microsoft.AspNetCore.Http;
using SIMS_Web.Data;
using SIMS_Web.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SIMS_Web.Services
{
    public class AuditService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuditService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task LogActionAsync(string transactionType, string transactionValue)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var username = httpContext?.User.Identity?.IsAuthenticated == true 
                ? httpContext.User.FindFirstValue(ClaimTypes.Name) 
                : "Anonymous";
            
            var userType = httpContext?.User.IsInRole("Admin") == true 
                ? "Admin" 
                : httpContext?.User.IsInRole("Staff") == true 
                    ? "Staff" 
                    : "Student";

            var ipAddress = httpContext?.Connection.RemoteIpAddress?.ToString();

            var auditTrail = new AuditTrail
            {
                DtTim = DateTime.UtcNow,
                Username = username ?? "System",
                Usertyp = userType,
                IpAdd = ipAddress ?? "Unknown",
                TransactionTyp = transactionType,
                TransactionVal = transactionValue
            };

            _context.AuditTrails.Add(auditTrail);
            await _context.SaveChangesAsync();
        }
    }
}