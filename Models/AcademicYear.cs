using System;
using System.ComponentModel.DataAnnotations;

namespace SIMS.Web.Models
{
    public class AcademicYear
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Year Begin")]
        [DataType(DataType.Date)]
        public DateTime YrBegin { get; set; }
        
        [Required]
        [Display(Name = "Year Break")]
        [DataType(DataType.Date)]
        public DateTime YrBreak { get; set; }
        
        [Required]
        [Display(Name = "Year Resume")]
        [DataType(DataType.Date)]
        public DateTime YrResume { get; set; }
        
        [Required]
        [Display(Name = "Year End")]
        [DataType(DataType.Date)]
        public DateTime YrEnd { get; set; }
    }
}
