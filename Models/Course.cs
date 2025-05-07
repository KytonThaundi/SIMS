using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SIMS_Web.Models
{
    public class Course
    {
        [Key]
        [Display(Name = "Course ID")]
        public string Course_id { get; set; }
        
        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        
        [Display(Name = "Credit Hours")]
        [Range(1, 10)]
        public int CreditHours { get; set; }
        
        [Display(Name = "Assessment Type")]
        public string AssessmentType { get; set; }
        
        [Display(Name = "Grading System")]
        public string GradingSystem { get; set; }
        
        [Display(Name = "Department")]
        public string Dept_id { get; set; }
        
        // Navigation property
        public virtual Department Department { get; set; }
    }
}