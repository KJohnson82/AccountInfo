namespace AccountInfo.Shared.DTOs
{
    public class AccountManagerDto
    {
        public int Id { get; set; }
        public string AMCompany { get; set; } = string.Empty;
        public string AMName { get; set; } = string.Empty;
        public string? AMEmail { get; set; } = string.Empty;
        public string? AMPhone { get; set; }
        public int? InternetAccountId { get; set; }
        public int? PhoneAccountId { get; set; }
        public int AccountType { get; set; }
    }
}
