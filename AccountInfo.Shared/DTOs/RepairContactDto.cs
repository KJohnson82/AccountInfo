namespace AccountInfo.Shared.DTOs
{
    public class RepairContactDto
    {
        public int Id { get; set; }
        public int? InternetAccountId { get; set; }
        public int? PhoneAccountId { get; set; }
        public int AccountType { get; set; }
        public string RPCompany { get; set; } = string.Empty;
        public string RPName { get; set; } = string.Empty;
        public string? RPPhone { get; set; }
        public string? RPEmail { get; set; }
        public string? RPPortal { get; set; }

    }
}
