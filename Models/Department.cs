using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [Display(Name = "Faculty")]
        public string Faculty_id { get; set; }

        [ForeignKey("Faculty_id")]
        public virtual Faculty Faculty { get; set; }

        public virtual ICollection<Programme> Programmes { get; set; } = new List<Programme>();

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
