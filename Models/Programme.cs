using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SIMS_Web.Models
{
    public class Programme
    {
        [Key]
        [Display(Name = "Programme ID")]
        public string Prog_id { get; set; }
        
        [Required]
        [Display(Name = "Programme Name")]
        public string ProgName { get; set; }
        
        [Display(Name = "Faculty")]
        public string Faculty_id { get; set; }
        
        [Display(Name = "Department")]
        public string Dept_id { get; set; }
        
        [Display(Name = "Duration (Years)")]
        public string Duration { get; set; }
        
        // Navigation properties
        public virtual Faculty Faculty { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}