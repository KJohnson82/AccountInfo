using System;
using System.Collections.Generic;
using System.Text;

namespace AccountInfo.Shared.DTOs
{
    public class PhoneAccountDto
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public string LocalProvider { get; set; } = string.Empty;
        public string LocalAccountNumber { get; set; } = string.Empty;
        public string LongDistanceProvider { get; set; } = string.Empty;
        public string? LongDistanceAccountNumber { get; set; }
        public string TermNumber { get; set; } = string.Empty;
        public string? FaxNumber { get; set; }
        public string? TollFreeNumber1 { get; set; }
        public string? TollFreeNumber2 { get; set; }
        public string? RolloverNumbers { get; set; }
        public DateTime? AccountAddedDate { get; set; }
        public DateTime? BillEntryDate { get; set; }
        public decimal? MonthlyCost { get; set; }
        public string? Notes { get; set; }
        public bool Active { get; set; }
        public DateTime? RecordAdd { get; set; }
        // Flattened related data
        public string? LocationName { get; set; }
        public List<AccountManagerDto> AccountManagers { get; set; } = new List<AccountManagerDto>();
        public List<RepairContactDto> RepairContacts { get; set; } = new List<RepairContactDto>();
    }
}
