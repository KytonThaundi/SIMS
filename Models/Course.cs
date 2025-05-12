using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMS.Web.Models
{
    public class Course
    {
        [Key]
        [Display(Name = "Course ID")]
        public string Course_id { get; set; }

        [Required]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [Required]
        [Display(Name = "Credit Hours")]
        public int CreditHrs { get; set; }

        [Display(Name = "Programme")]
        public string? Prog_id { get; set; }

        [Display(Name = "Department")]
        public string? Dept_id { get; set; }

        [ForeignKey("Prog_id")]
        public virtual Programme? Programme { get; set; }

        [ForeignKey("Dept_id")]
        public virtual Department? Department { get; set; }

        // For compatibility with controller
        public int CreditHours => CreditHrs;
    }
}
