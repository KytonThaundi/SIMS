using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMS_Web.Models
{
    public class Account
    {
        [Key]
        [Display(Name = "Account Number")]
        public string AccNo { get; set; }
        
        [Required]
        [Display(Name = "Student")]
        public string Student_Id { get; set; }
        
        [Required]
        [Display(Name = "Account Balance")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AccBal { get; set; }
        
        [ForeignKey("Student_Id")]
        public virtual Student Student { get; set; }
    }
}
