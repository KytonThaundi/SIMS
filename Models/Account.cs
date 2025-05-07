using System.ComponentModel.DataAnnotations;

namespace SIMS_Web.Models
{
    public class Account
    {
        [Key]
        [Display(Name = "Account Number")]
        public string AccNo { get; set; }
        
        [Required]
        [Display(Name = "Student ID")]
        public string Student_Id { get; set; }
        
        [Display(Name = "Account Balance")]
        [DataType(DataType.Currency)]
        public decimal AccBal { get; set; }
        
        // Navigation property
        public virtual Student Student { get; set; }
    }
}