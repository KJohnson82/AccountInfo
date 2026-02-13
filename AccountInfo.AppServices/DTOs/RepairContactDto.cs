using System;
using System.Collections.Generic;
using System.Text;

namespace AccountInfo.Shared.DTOs
{
    public class RepairContactDto
    {
        public int Id { get; set; }
        public int? InternetAccountId { get; set; }
        public int? PhoneAccountId { get; set; }
        public string AccountType { get; set; } = string.Empty;
        public string RPCompany { get; set; } = string.Empty;
        public string RPName { get; set; } = string.Empty;
        public string? RPPhone { get; set; }
        public string? RPEmail { get; set; }
        public string? RPPortal { get; set; }

    }
}
