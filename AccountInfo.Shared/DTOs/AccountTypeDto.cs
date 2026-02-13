using AccountInfo.Shared.Enums;

namespace AccountInfo.Shared.DTOs
{
    public class AccountTypeDto
    {
        public int Id { get; set; }

        public string? AccountTypeName { get; set; }

        public static List<AccountTypeDto> GetAccountType()
        {
            return Enum.GetValues(typeof(AccountType))
                .Cast<AccountType>()
                .Select(at => new AccountTypeDto
                {
                    Id = (int)at,
                    AccountTypeName = at.ToString()
                })
                .ToList();
        }
    }
}
