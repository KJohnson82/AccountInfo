using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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

//public string? AccountManager1 { get; set; }
//[StringLength(50)]
//public string? AMEmail1 { get; set; }
//[StringLength(20)]
//public string? AMPhone1 { get; set; }
//[StringLength(50)]
//public string? AccountManager2 { get; set; }
//[StringLength(50)]
//public string? AMEmail2 { get; set; }
//[StringLength(20)]
//public string? AMPhone2 { get; set; }
//[StringLength(50)]
//public string? AccountManager3 { get; set; }
//[StringLength(50)]
//public string? AMEmail3 { get; set; }
//[StringLength(20)]
//public string? AMPhone3 { get; set; }
//[StringLength(100)]
//public string? RepairContact1 { get; set; }
//[StringLength(20)]
//public string? RepairPhone1 { get; set; }
//public string? RepairPortal1 { get; set; }
//[StringLength(100)]
//public string? RepairContact2 { get; set; }
//[StringLength(20)]
//public string? RepairPhone2 { get; set; }
//public string? RepairPortal2 { get; set; }
//[StringLength(100)]
//public string? RepairContact3 { get; set; }
//[StringLength(20)]
//public string? RepairPhone3 { get; set; }
//public string? RepairPortal3 { get; set; }