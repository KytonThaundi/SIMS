using System;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        
        public string Gender { get; set; }
        
        [Display(Name = "Program of Study")]
        public string ProgramOfStudy { get; set; }
        
        [Display(Name = "Type of Admission")]
        public string TOA { get; set; }
        
        public string Accommodation { get; set; }
        
        [Display(Name = "Registration Status")]
        public string RegStatus { get; set; }
        
        [Display(Name = "Year of Admission")]
        public int? YOA { get; set; }
        
        public string Mobile { get; set; }
        
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        
        [Display(Name = "Account Number")]
        public string AccNum { get; set; }
        
        // Navigation property
        public virtual Programme Programme { get; set; }
    }
}