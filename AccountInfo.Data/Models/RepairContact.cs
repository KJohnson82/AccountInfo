using AccountInfo.Shared.Enums;
using System.ComponentModel.DataAnnotations;

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

        [StringLength(50)]
        public string? RPEmail { get; set; }

        public string? RPPortal { get; set; }

        // Navigation properties
        public InternetAccount? InternetAccount { get; set; }
        public PhoneAccount? PhoneAccount { get; set; }
    }
}
