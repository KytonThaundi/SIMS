using System;
using System.ComponentModel.DataAnnotations;

namespace SIMS_Web.Models
{
    public class AcademicYear
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Year Begin")]
        [DataType(DataType.Date)]
        public DateTime YrBegin { get; set; }
        
        [Display(Name = "Year Break")]
        [DataType(DataType.Date)]
        public DateTime YrBreak { get; set; }
        
        [Display(Name = "Year Resume")]
        [DataType(DataType.Date)]
        public DateTime YrResume { get; set; }
        
        [Required]
        [Display(Name = "Year End")]
        [DataType(DataType.Date)]
        public DateTime YrEnd { get; set; }
        
        [Display(Name = "Academic Year")]
        public string DisplayName => $"{YrBegin.Year}-{YrEnd.Year}";
    }
}