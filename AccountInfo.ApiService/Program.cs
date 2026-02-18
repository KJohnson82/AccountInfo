using AccountInfo.Data.Data;
using AccountInfo.Data.Models;
using AccountInfo.ServiceDefaults;
using AccountInfo.Shared.DTOs;
using AccountInfo.Shared.Enums;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddProblemDetails();
builder.Services.AddOpenApi();
builder.AddNpgsqlDbContext<AppInfoDbContext>(connectionName: "appinfodb");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    Console.WriteLine("ATTEMPTING TO RUN MIGRATIONS...");
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppInfoDbContext>();
    await db.Database.MigrateAsync();
    Console.WriteLine("MIGRATIONS COMPLETED!");
    app.MapOpenApi();
}

app.UseExceptionHandler();

var api = app.MapGroup("/api");

api.MapGet("/locations", async (AppInfoDbContext db) =>
{
    var locations = await db.Locations
        .Where(l => l.Active == true)
        .ToListAsync();
    return Results.Ok(locations.Select(MapLocation));
});

api.MapGet("/locations/{id:int}", async (int id, AppInfoDbContext db) =>
{
    var location = await db.Locations.FindAsync(id);
    return location is null ? Results.NotFound() : Results.Ok(MapLocation(location));
});

api.MapGet("/loctypes", () =>
{
    return Results.Ok(LoctypeDto.GetLoctype());
});

api.MapGet("/internetaccounts", async (AppInfoDbContext db) =>
{
    var accounts = await db.InternetAccounts
        .Include(ia => ia.Location)
        .Include(ia => ia.AccountManagers)
        .Include(ia => ia.RepairContacts)
        .ToListAsync();
    return Results.Ok(accounts.Select(MapInternetAccount));
});

api.MapGet("/internetaccounts/{id:int}", async (int id, AppInfoDbContext db) =>
{
    var account = await db.InternetAccounts
        .Include(ia => ia.Location)
        .Include(ia => ia.AccountManagers)
        .Include(ia => ia.RepairContacts)
        .FirstOrDefaultAsync(ia => ia.Id == id);
    return account is null ? Results.NotFound() : Results.Ok(MapInternetAccount(account));
});

api.MapGet("/internetaccounts/bylocation/{locationId:int}", async (int locationId, AppInfoDbContext db) =>
{
    var accounts = await db.InternetAccounts
        .Include(ia => ia.Location)
        .Include(ia => ia.AccountManagers)
        .Include(ia => ia.RepairContacts)
        .Where(ia => ia.LocationId == locationId)
        .ToListAsync();
    return Results.Ok(accounts.Select(MapInternetAccount));
});

api.MapGet("/phoneaccounts", async (AppInfoDbContext db) =>
{
    var accounts = await db.PhoneAccounts
        .Include(pa => pa.Location)
        .Include(pa => pa.AccountManagers)
        .Include(pa => pa.RepairContacts)
        .ToListAsync();
    return Results.Ok(accounts.Select(MapPhoneAccount));
});

api.MapGet("/phoneaccounts/{id:int}", async (int id, AppInfoDbContext db) =>
{
    var account = await db.PhoneAccounts
        .Include(pa => pa.Location)
        .Include(pa => pa.AccountManagers)
        .Include(pa => pa.RepairContacts)
        .FirstOrDefaultAsync(pa => pa.Id == id);
    return account is null ? Results.NotFound() : Results.Ok(MapPhoneAccount(account));
});

api.MapGet("/phoneaccounts/bylocation/{locationId:int}", async (int locationId, AppInfoDbContext db) =>
{
    var accounts = await db.PhoneAccounts
        .Include(pa => pa.Location)
        .Include(pa => pa.AccountManagers)
        .Include(pa => pa.RepairContacts)
        .Where(pa => pa.LocationId == locationId)
        .ToListAsync();
    return Results.Ok(accounts.Select(MapPhoneAccount));
});

api.MapGet("/accountmanagers", async (AppInfoDbContext db) =>
{
    var managers = await db.AccountManagers
        .ToListAsync();
    return Results.Ok(managers.Select(MapAccountManager));
});

api.MapGet("/repaircontacts", async (AppInfoDbContext db) =>
{
    var contacts = await db.RepairContacts
        .ToListAsync();
    return Results.Ok(contacts.Select(MapRepairContact));
});

app.MapDefaultEndpoints();
app.Run();

// --- Mapping helpers ---
static LocationDto MapLocation(Location l) => new()
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

static AccountManagerDto MapAccountManager(AccountManager am) => new()
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

static RepairContactDto MapRepairContact(RepairContact rc) => new()
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

static InternetAccountDto MapInternetAccount(InternetAccount ia) => new()
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

static PhoneAccountDto MapPhoneAccount(PhoneAccount pa) => new()
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