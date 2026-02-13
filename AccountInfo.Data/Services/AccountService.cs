using AccountInfo.Data.Data;
using AccountInfo.Data.Models;
using AccountInfo.Shared.DTOs;
using AccountInfo.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountInfo.Data.Services
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
            return await _context.AccountManagers
                .Select(am => MapAccountManager(am))
                .ToListAsync();
        }

        public async Task<AccountManagerDto?> GetAccountManagerByIdAsync(int id)
        {
            var am = await _context.AccountManagers.FindAsync(id);
            return am is null ? null : MapAccountManager(am);
        }


        public Task<List<AccountTypeDto>> GetAccountTypesAsync()
        {
            return Task.FromResult(AccountTypeDto.GetAccountType());
        }

        public Task<AccountTypeDto?> GetAccountTypeByIdAsync(int id)
        {
            var result = AccountTypeDto.GetAccountType().FirstOrDefault(at => at.Id == id);
            return Task.FromResult(result);
        }


        public async Task<List<InternetAccountDto>> GetInternetAccountsAsync()
        {
            return await _context.InternetAccounts
                .Include(ia => ia.Location)
                .Include(ia => ia.AccountManagers)
                .Include(ia => ia.RepairContacts)
                .Select(ia => MapInternetAccount(ia))
                .ToListAsync();
        }

        public async Task<InternetAccountDto?> GetInternetAccountByIdAsync(int id)
        {
            var account = await _context.InternetAccounts
                .Include(ia => ia.Location)
                .Include(ia => ia.AccountManagers)
                .Include(ia => ia.RepairContacts)
                .FirstOrDefaultAsync(ia => ia.Id == id);

            return account is null ? null : MapInternetAccount(account);
        }


        public async Task<List<PhoneAccountDto>> GetPhoneAccountsAsync()
        {
            return await _context.PhoneAccounts
                .Include(pa => pa.Location)
                .Include(pa => pa.AccountManagers)
                .Include(pa => pa.RepairContacts)
                .Select(pa => MapPhoneAccount(pa))
                .ToListAsync();
        }

        public async Task<PhoneAccountDto?> GetPhoneAccountByIdAsync(int id)
        {
            var account = await _context.PhoneAccounts
                .Include(pa => pa.Location)
                .Include(pa => pa.AccountManagers)
                .Include(pa => pa.RepairContacts)
                .FirstOrDefaultAsync(pa => pa.Id == id);

            return account is null ? null : MapPhoneAccount(account);
        }


        public async Task<List<LocationDto>> GetLocationsAsync()
        {
            return await _context.Locations
                .Select(l => MapLocation(l))
                .ToListAsync();
        }

        public async Task<LocationDto?> GetLocationByIdAsync(int id)
        {
            var location = await _context.Locations.FindAsync(id);
            return location is null ? null : MapLocation(location);
        }


        public Task<List<LoctypeDto>> GetLoctypesAsync()
        {
            return Task.FromResult(LoctypeDto.GetLoctype());
        }

        public Task<LoctypeDto?> GetLoctypeByIdAsync(int id)
        {
            var result = LoctypeDto.GetLoctype().FirstOrDefault(lt => lt.Id == id);
            return Task.FromResult(result);
        }


        public async Task<List<RepairContactDto>> GetRepairContactsAsync()
        {
            return await _context.RepairContacts
                .Select(rc => MapRepairContact(rc))
                .ToListAsync();
        }

        public async Task<RepairContactDto?> GetRepairContactByIdAsync(int id)
        {
            var rc = await _context.RepairContacts.FindAsync(id);
            return rc is null ? null : MapRepairContact(rc);
        }


        public Task<List<ApplicationUserDto>> GetApplicationUsersAsync()
            => throw new NotImplementedException();

        public Task<ApplicationUserDto?> GetApplicationUserByIdAsync(int id)
            => throw new NotImplementedException();


        private static AccountManagerDto MapAccountManager(AccountManager am) => new()
        {
            Id = am.Id,
            AMCompany = am.AMCompany,
            AMName = am.AMName,
            AMEmail = am.AMEmail,
            AMPhone = am.AMPhone,
            InternetAccountId = am.InternetAccountId,
            PhoneAccountId = am.PhoneAccountId,
            AccountType = (int)am.AccountType
        };

        private static RepairContactDto MapRepairContact(RepairContact rc) => new()
        {
            Id = rc.Id,
            InternetAccountId = rc.InternetAccountId,
            PhoneAccountId = rc.PhoneAccountId,
            AccountType = (int)rc.AccountType,
            RPCompany = rc.RPCompany,
            RPName = rc.RPName,
            RPPhone = rc.RPPhone,
            RPEmail = rc.RPEmail,
            RPPortal = rc.RPPortal
        };

        private static LocationDto MapLocation(Location l) => new()
        {
            Id = l.Id,
            LocName = l.LocName,
            LocNum = l.LocNum,
            Address = l.Address,
            City = l.City,
            State = l.State,
            Zipcode = l.Zipcode,
            PhoneNumber = l.PhoneNumber,
            FaxNumber = l.FaxNumber,
            Email = l.Email,
            Hours = l.Hours,
            Loctype = (int)l.Loctype,
            LoctypeName = l.Loctype.ToString(),
            AreaManager = l.AreaManager,
            StoreManager = l.StoreManager,
            RecordAdd = l.RecordAdd,
            Active = l.Active ?? true
        };

        private static InternetAccountDto MapInternetAccount(InternetAccount ia) => new()
        {
            Id = ia.Id,
            LocationId = ia.LocationId,
            LocationName = ia.Location?.LocName,
            InternetProvider = ia.InternetProvider,
            ServiceType = ia.ServiceType,
            DataAccountNumber = ia.DataAccountNumber,
            CircuitId = ia.CircuitId,
            ConnectionType = ia.ConnectionType,
            ConnectionSpeed = ia.ConnectionSpeed,
            IPAddress = ia.IPAddress,
            SubnetMask = ia.SubnetMask,
            DefaultGateway = ia.DefaultGateway,
            DNSPrimary = ia.DNSPrimary,
            DNSSecondary = ia.DNSSecondary,
            AccountAddedDate = ia.AccountAddedDate,
            BillEntryDate = ia.BillEntryDate,
            MonthlyCost = ia.MonthlyCost,
            AdminPortalURL = ia.AdminPortalURL,
            AdminUsername = ia.AdminUsername,
            AdminPassword = ia.AdminPassword,
            AdminInfo = ia.AdminInfo,
            AdminAnswers = ia.AdminAnswers,
            Notes = ia.Notes,
            Active = ia.Active,
            RecordAdd = ia.RecordAdd,
            AccountManagers = ia.AccountManagers?.Select(MapAccountManager).ToList() ?? [],
            RepairContacts = ia.RepairContacts?.Select(MapRepairContact).ToList() ?? []
        };

        private static PhoneAccountDto MapPhoneAccount(PhoneAccount pa) => new()
        {
            Id = pa.Id,
            LocationId = pa.LocationId,
            LocationName = pa.Location?.LocName,
            LocalProvider = pa.LocalProvider,
            LocalAccountNumber = pa.LocalAccountNumber,
            LongDistanceProvider = pa.LongDistanceProvider,
            LongDistanceAccountNumber = pa.LongDistanceAccountNumber,
            TermNumber = pa.TermNumber,
            FaxNumber = pa.FaxNumber,
            TollFreeNumber1 = pa.TollFreeNumber1,
            TollFreeNumber2 = pa.TollFreeNumber2,
            RolloverNumbers = pa.RolloverNumbers,
            AccountAddedDate = pa.AccountAddedDate,
            BillEntryDate = pa.BillEntryDate,
            MonthlyCost = pa.MonthlyCost,
            Notes = pa.Notes,
            Active = pa.Active,
            RecordAdd = pa.RecordAdd,
            AccountManagers = pa.AccountManagers?.Select(MapAccountManager).ToList() ?? [],
            RepairContacts = pa.RepairContacts?.Select(MapRepairContact).ToList() ?? []
        };
    }
}
