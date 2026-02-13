
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountInfo.Data.Models
{
    public class AccountManager
    {
        [Key]
        public int Id { get; set; }

        // Foreign keys 
        public int? InternetAccountId { get; set; }
        public int? PhoneAccountId { get; set; }

        [Required]
        public AccountType AccountType { get; set; }

        [Required]
        [StringLength(100)]
        public string AMCompany { get; set; } = string.Empty;  

        [Required]
        [StringLength(100)]
        public string AMName { get; set; } = string.Empty;

        [StringLength(100)]
        [EmailAddress]
        public string AMEmail { get; set; } = string.Empty;

        [StringLength(20)]
        public string? AMPhone { get; set; }
        // Navigation properties
        public InternetAccount? InternetAccount { get; set; }
        public PhoneAccount? PhoneAccount { get; set; }
    }
}
