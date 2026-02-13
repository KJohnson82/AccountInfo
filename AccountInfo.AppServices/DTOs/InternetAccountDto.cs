using System;
using System.Collections.Generic;
using System.Text;

namespace AccountInfo.Shared.DTOs
{
    public  class InternetAccountDto
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string InternetProvider { get; set; } = string.Empty;
        public string? ServiceType { get; set; }
        public string DataAccountNumber { get; set; } = string.Empty;
        public string? CircuitId { get; set; }
        public string? ConnectionType { get; set; }
        public string? ConnectionSpeed { get; set; }
        public string? IPAddress { get; set; }
        public string? SubnetMask { get; set; }
        public string? DefaultGateway { get; set; }
        public string? DNSPrimary { get; set; }
        public string? DNSSecondary { get; set; }
        public DateTime? AccountAddedDate { get; set; }
        public DateTime? BillEntryDate { get; set; }
        public decimal? MonthlyCost { get; set; } 
        public string? AdminPortalURL { get; set; }
        public string? AdminUsername { get; set; }
        public string? AdminPassword { get; set; }
        public string? AdminAnswers { get; set; }
        public string? Notes { get; set; }
        public bool Active { get; set; }
        public DateTime? RecordAdd { get; set; }
        // Flattened related data
        public string? LocationName { get; set; }
        public List<AccountManagerDto> AccountManagers { get; set; } = new List<AccountManagerDto>();
        public List<RepairContactDto> RepairContacts { get; set; } = new List<RepairContactDto>();
    }
}
