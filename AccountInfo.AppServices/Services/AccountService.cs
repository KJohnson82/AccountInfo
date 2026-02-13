using AccountInfo.Data.Data;
using AccountInfo.Shared.DTOs;
using AccountInfo.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountInfo.Shared.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppInfoDbContext _context;

        public AccountService(AppInfoDbContext context)
        {
            _context = context;
        }

            public async Task<List<AccountManagerDto>> GetAccountManagersAsync()
            {
                var accountManagers = await _context.AccountManagers
                .Where(am => am.InternetAccountId != null || am.PhoneAccountId != null)
                .ToListAsync();

            return accountManagers;
            
            }

        public async Task<AccountManagerDto?> GetAccountManagerByIdAsync(int Id)
        {
            return _context.AccountManagers.Where(am => am.Id == Id).FirstOrDefaultAsync();
            
        }

        public Task<AccountTypeDto?> GetAccountTypeByIdAsync(int Id)
        {
            var accountType = AccountTypeDto.GetAccountType().FirstOrDefault(at => at.Id == Id);
            return Task.FromResult<AccountTypeDto?>(accountType);
        }

        public Task<List<AccountTypeDto>> GetAccountTypesAsync()
        {
            return Task.FromResult(AccountTypeDto.GetAccountType());
            
        }

        public Task<ApplicationUserDto?> GetApplicationUserByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationUserDto>> GetApplicationUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<InternetAccountDto?> GetInternetAccountByIdAsync(int Id)
        {
            var account = await _context.InternetAccounts
                .Include(ia => ia.Location)
                .Include(ia => ia.AccountManagers)
                .Include(ia => ia.RepairContacts)
                .FirstOrDefaultAsync(ia => ia.Id == Id);

            return account;
        }

        public Task<List<InternetAccountDto>> GetInternetAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LocationDto?> GetLocationByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LocationDto>> GetLocationsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<LoctypeDto?> GetLoctypeByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LoctypeDto>> GetLoctypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PhoneAccountDto?> GetPhoneAccountByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PhoneAccountDto>> GetPhoneAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RepairContactDto?> GetRepairContactByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<RepairContactDto>> GetRepairContactsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
