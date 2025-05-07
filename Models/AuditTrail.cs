using System;
using System.ComponentModel.DataAnnotations;

namespace SIMS_Web.Models
{
    public class AuditTrail
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Date/Time")]
        public DateTime DtTim { get; set; }
        
        [Required]
        public string Username { get; set; }
        
        [Required]
        [Display(Name = "User Type")]
        public string Usertyp { get; set; }
        
        [Display(Name = "IP Address")]
        public string IpAdd { get; set; }
        
        [Required]
        [Display(Name = "Transaction Type")]
        public string TransactionTyp { get; set; }
        
        [Display(Name = "Transaction Value")]
        public string TransactionVal { get; set; }
    }
}