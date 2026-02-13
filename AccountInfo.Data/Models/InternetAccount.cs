using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountInfo.Data.Models
{
    public class InternetAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        [StringLength(100)]
        public string InternetProvider { get; set; } = string.Empty;

        [StringLength(50)]
        public string? ServiceType { get; set; }

        [Required]
        [StringLength(50)]
        public string DataAccountNumber { get; set; } = string.Empty;

        [StringLength(50)]
        public string? CircuitId { get; set; }

        public string? ConnectionType { get; set; }

        [StringLength(50)]
        public string? ConnectionSpeed { get; set; }

        [StringLength(50)]
        public string? IPAddress { get; set; }

        [StringLength(50)]
        public string? SubnetMask { get; set; }

        [StringLength(50)]
        public string? DefaultGateway { get; set; }

        [StringLength(30)]
        public string? DNSPrimary { get; set; }

        [StringLength(30)]
        public string? DNSSecondary { get; set; }

        public DateTime? AccountAddedDate { get; set; }
        public DateTime? BillEntryDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MonthlyCost { get; set; }

        public string? AdminPortalURL { get; set; }

        [StringLength(50)]
        public string? AdminUsername { get; set; }

        [StringLength(50)]
        public string? AdminPassword { get; set; }

        public string? AdminInfo { get; set; }

        public string? AdminAnswers { get; set; }

        public string? Notes { get; set; }

        public bool Active { get; set; } = true;

        public DateTime RecordAdd { get; set; } = DateTime.Now;

        // Navigation properties
        public Location? Location { get; set; }
        public List<AccountManager> AccountManagers { get; set; } = new();
        public List<RepairContact> RepairContacts { get; set; } = new();
    }
}
