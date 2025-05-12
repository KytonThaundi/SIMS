using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SIMS.Web.Models
{
    public class Programme
    {
        [Key]
        [Display(Name = "Programme ID")]
        public string Prog_id { get; set; }

        [Required]
        [Display(Name = "Programme Name")]
        public string ProgName { get; set; }

        [Required]
        [Display(Name = "Faculty")]
        public string Faculty_id { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string Dept_id { get; set; }

        [Required]
        public string Duration { get; set; }

        [ForeignKey("Faculty_id")]
        public virtual Faculty Faculty { get; set; }

        [ForeignKey("Dept_id")]
        public virtual Department Department { get; set; }

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
