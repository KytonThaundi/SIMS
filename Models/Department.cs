using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SIMS_Web.Models
{
    public class Department
    {
        [Key]
        [Display(Name = "Department ID")]
        public string Dept_id { get; set; }
        
        [Required]
        [Display(Name = "Department Name")]
        public string DeptName { get; set; }
        
        [Display(Name = "Faculty")]
        public string Faculty_id { get; set; }
        
        // Navigation properties
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Programme> Programmes { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}