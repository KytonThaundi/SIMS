using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMS_Web.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "Student ID")]
        public string Student_Id { get; set; }
        
        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }
        
        [Required]
        public string Surname { get; set; }
        
        [Required]
        public string Gender { get; set; }
        
        [Required]
        [Display(Name = "Program of Study")]
        public string ProgramOfStudy { get; set; }
        
        [Display(Name = "Type of Admission")]
        public string TOA { get; set; }
        
        public string Accommodation { get; set; }
        
        [Display(Name = "Registration Status")]
        public string RegStatus { get; set; }
        
        [Display(Name = "Year of Admission")]
        public string YOA { get; set; }
        
        public string Mobile { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        
        [Display(Name = "Account Number")]
        public string AccNum { get; set; }
        
        [ForeignKey("ProgramOfStudy")]
        public virtual Programme Programme { get; set; }
        
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
