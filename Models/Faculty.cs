using System.ComponentModel.DataAnnotations;

namespace SIMS.Web.Models
{
    public class Faculty
    {
        [Key]
        [Display(Name = "Faculty ID")]
        public string Faculty_id { get; set; }

        [Required]
        [Display(Name = "Faculty Name")]
        public string FacultyName { get; set; }

        public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
        public virtual ICollection<Programme> Programmes { get; set; } = new List<Programme>();
    }
}
