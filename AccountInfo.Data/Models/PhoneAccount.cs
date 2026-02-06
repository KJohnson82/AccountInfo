using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AccountInfo.Data.Models
{
    public class PhoneAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int LocationId { get; set; }

        [Required]
        [StringLength(100)]
        public string LocalProvider { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LocalAccountNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LongDistanceProvider { get; set; } = string.Empty;

        [StringLength(50)]
        public string? LongDistanceAccountNumber { get; set; }

        [Required]
        [StringLength(15)]
        public string TermNumber { get; set; } = string.Empty;

        [StringLength(15)]
        public string? FaxNumber { get; set; }

        [StringLength(20)]
        public string? TollFreeNumber1 { get; set; }

        [StringLength(20)]
        public string? TollFreeNumber2 { get; set; }

        public string? RolloverNumbers { get; set; }
        public DateTime? AccountAddedDate { get; set; }
        public DateTime? BillEntryDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MonthlyCost { get; set; }

        public string? Notes { get; set; }

        public bool Active { get; set; } = true;

        public DateTime RecordAdd { get; set; } = DateTime.Now;

        // Navigation properties
        public Location? Location { get; set; }
        public List<AccountManager> AccountManagers { get; set; } = new();
        public List<RepairContact> RepairContacts { get; set; } = new();
    }
}
