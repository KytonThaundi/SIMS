using System.ComponentModel.DataAnnotations;

namespace SIMS.Web.Models
{
    public class ResetAdminPasswordViewModel
    {
        [Required(ErrorMessage = "New password is required")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmNewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Security code is required")]
        [Display(Name = "Security Code")]
        public string SecurityCode { get; set; } = string.Empty;
    }
}
