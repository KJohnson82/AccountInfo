using AccountInfo.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountInfo.Data.Models
{
    public class RepairContact
    {
        [Key]
        public int Id { get; set; }

        public int? InternetAccountId { get; set; }
        public int? PhoneAccountId { get; set; }

        [Required]
        public AccountType AccountType { get; set; }

        [Required]
        [StringLength(100)]
        public string RPCompany { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string RPName { get; set; } = string.Empty;

        [StringLength(20)]
        public string? RPPhone { get; set; }

        public string? RPPortal { get; set; }

        // Navigation properties
        public InternetAccount? InternetAccount { get; set; }
        public PhoneAccount? PhoneAccount { get; set; }
    }
}
