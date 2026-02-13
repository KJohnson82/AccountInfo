using AccountInfo.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountInfo.Shared.Interfaces
{
    public interface IAccountService
    {
        Task<List<AccountManagerDto>> GetAccountManagersAsync();
        Task<AccountManagerDto?> GetAccountManagerByIdAsync(int Id);
        Task<List<AccountTypeDto>> GetAccountTypesAsync();
        Task<AccountTypeDto?> GetAccountTypeByIdAsync(int Id);
        Task<List<RepairContactDto>> GetRepairContactsAsync();
        Task<RepairContactDto?> GetRepairContactByIdAsync(int Id);
        Task<List<LocationDto>> GetLocationsAsync();
        Task<LocationDto?> GetLocationByIdAsync(int Id);
        Task<List<InternetAccountDto>> GetInternetAccountsAsync();
        Task<InternetAccountDto?> GetInternetAccountByIdAsync(int Id);
        Task<List<PhoneAccountDto>> GetPhoneAccountsAsync();
        Task<PhoneAccountDto?> GetPhoneAccountByIdAsync(int Id);
        Task<List<ApplicationUserDto>> GetApplicationUsersAsync();
        Task<ApplicationUserDto?> GetApplicationUserByIdAsync(int Id);
        Task<List<LoctypeDto>> GetLoctypesAsync();
        Task<LoctypeDto?> GetLoctypeByIdAsync(int Id);

    }
}
