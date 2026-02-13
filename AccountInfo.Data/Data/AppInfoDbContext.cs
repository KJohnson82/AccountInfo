using AccountInfo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountInfo.Data.Data
{
    public class AppInfoDbContext : DbContext
    {
        public AppInfoDbContext(DbContextOptions<AppInfoDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<InternetAccount> InternetAccounts { get; set; }
        public DbSet<PhoneAccount> PhoneAccounts { get; set; }
        public DbSet<AccountManager> AccountManagers { get; set; }
        public DbSet<RepairContact> RepairContacts { get; set; }
        public DbSet<Location> Locations { get; set; }
        //public DbSet<Loctype> Loctypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Helper method
            static string GetAccountTypeCheckConstraint()
            {
                return @"(""AccountType"" = 2 AND ""PhoneAccountId"" IS NOT NULL AND ""InternetAccountId"" IS NULL) OR 
                     (""AccountType"" = 1 AND ""InternetAccountId"" IS NOT NULL AND ""PhoneAccountId"" IS NULL) OR 
                     (""AccountType"" = 3 AND ""InternetAccountId"" IS NOT NULL AND ""PhoneAccountId"" IS NOT NULL)";
            }

            // ============================================
            // Loctype Configuration
            // ============================================
            //modelBuilder.Entity<Loctype>(entity =>
            //{
            //    entity.ToTable("Loctypes");

            //    entity.Property(e => e.LoctypeName)
            //        .IsRequired()
            //        .HasMaxLength(50);

            //    // Seed static data
            //    entity.HasData(
            //        new Loctype { Id = 1, LoctypeName = "Corporate" },
            //        new Loctype { Id = 2, LoctypeName = "Metal Mart" },
            //        new Loctype { Id = 3, LoctypeName = "Service Center" },
            //        new Loctype { Id = 4, LoctypeName = "Plant" },
            //        new Loctype { Id = 5, LoctypeName = "Other" }
            //    );
            //});

            // ============================================
            // Location Configuration & Seed Data
            // ============================================
            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Locations");

                //entity.HasOne(l => l.Loctype)
                //    .WithMany(lt => lt.Locations)
                //    .HasForeignKey(l => l.LoctypeId)
                //    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(l => l.Loctype);

                entity.HasMany(l => l.InternetAccounts)
                    .WithOne(ia => ia.Location)
                    .HasForeignKey(ia => ia.LocationId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(l => l.PhoneAccount)
                    .WithOne(pa => pa.Location)
                    .HasForeignKey<PhoneAccount>(pa => pa.LocationId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(l => l.LocNum).IsUnique();
                entity.HasIndex(l => l.Active);
                entity.HasIndex(l => l.Loctype);

                // ✅ SEED DATA - Locations
                entity.HasData(
                    new Location
                    {
                        Id = 1,
                        LocName = "Corporate Headquarters",
                        LocNum = 101,
                        Address = "123 Main Street",
                        City = "Bossier City",
                        State = "LA",
                        Zipcode = "71111",
                        PhoneNumber = "318-555-0100",
                        FaxNumber = "318-555-0101",
                        Email = "hq@company.com",
                        Hours = "Mon-Fri 8AM-5PM",
                        Loctype = Loctype.Corporate,
                        AreaManager = "John Smith",
                        StoreManager = "Jane Doe",
                        Active = true,
                        RecordAdd = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                    },
                    new Location
                    {
                        Id = 2,
                        LocName = "Downtown Metal Mart",
                        LocNum = 201,
                        Address = "456 Commerce Ave",
                        City = "Shreveport",
                        State = "LA",
                        Zipcode = "71101",
                        PhoneNumber = "318-555-0200",
                        FaxNumber = "318-555-0201",
                        Email = "downtown@metalmart.com",
                        Hours = "Mon-Sat 7AM-6PM",
                        Loctype = Loctype.MetalMart,
                        AreaManager = "Mike Johnson",
                        StoreManager = "Sarah Williams",
                        Active = true,
                        RecordAdd = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                    },
                    new Location
                    {
                        Id = 3,
                        LocName = "North Service Center",
                        LocNum = 601,
                        Address = "789 Industrial Blvd",
                        City = "Monroe",
                        State = "LA",
                        Zipcode = "71201",
                        PhoneNumber = "318-555-0300",
                        FaxNumber = "318-555-0301",
                        Email = "north@service.com",
                        Hours = "Mon-Fri 7AM-5PM",
                        Loctype = Loctype.ServiceCenter,
                        AreaManager = "Robert Brown",
                        StoreManager = "Emily Davis",
                        Active = true,
                        RecordAdd = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                    },
                    new Location
                    {
                        Id = 4,
                        LocName = "Alexandria Plant",
                        LocNum = 111,
                        Address = "321 Manufacturing Dr",
                        City = "Alexandria",
                        State = "LA",
                        Zipcode = "71301",
                        PhoneNumber = "318-555-0400",
                        Email = "plant@company.com",
                        Hours = "24/7",
                        Loctype = Loctype.Plant,
                        AreaManager = "David Miller",
                        StoreManager = "Lisa Wilson",
                        Active = true,
                        RecordAdd = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                    },
                    new Location
                    {
                        Id = 5,
                        LocName = "Warehouse Storage",
                        LocNum = 901,
                        Address = "555 Storage Lane",
                        City = "Bossier City",
                        State = "LA",
                        Zipcode = "71112",
                        PhoneNumber = "318-555-0500",
                        Email = "warehouse@company.com",
                        Hours = "Mon-Fri 6AM-4PM",
                        Loctype = Loctype.Other,
                        AreaManager = "Tom Anderson",
                        Active = true,
                        RecordAdd = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                    }
                );
            });

            // ============================================
            // InternetAccount Configuration & Seed Data
            // ============================================
            modelBuilder.Entity<InternetAccount>(entity =>
            {
                entity.ToTable("InternetAccounts");

                entity.HasMany(a => a.AccountManagers)
                    .WithOne(am => am.InternetAccount)
                    .HasForeignKey(am => am.InternetAccountId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(a => a.RepairContacts)
                    .WithOne(rc => rc.InternetAccount)
                    .HasForeignKey(rc => rc.InternetAccountId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(a => a.LocationId);
                entity.HasIndex(a => a.Active);
                entity.HasIndex(a => a.InternetProvider);

                // ✅ SEED DATA - Internet Accounts
                entity.HasData(
                    new InternetAccount
                    {
                        Id = 1,
                        LocationId = 1,
                        InternetProvider = "AT&T Business Fiber",
                        ServiceType = "Dedicated Fiber",
                        DataAccountNumber = "ATT-FB-1234567",
                        CircuitId = "ATTF/123456/DFW",
                        ConnectionType = "Fiber",
                        ConnectionSpeed = "1 Gbps",
                        IPAddress = "203.0.113.10",
                        SubnetMask = "255.255.255.0",
                        DefaultGateway = "203.0.113.1",
                        DNSPrimary = "8.8.8.8",
                        DNSSecondary = "8.8.4.4",
                        AccountAddedDate = new DateTime(2023, 08, 01, 0, 0, 0, DateTimeKind.Utc),
                        BillEntryDate = new DateTime(2023, 08, 01, 0, 0, 0, DateTimeKind.Utc),
                        MonthlyCost = 599.99m,
                        AdminPortalURL = "https://business.att.com",
                        AdminUsername = "hq_admin",
                        AdminPassword = "SecurePass123!",
                        AdminInfo = "Primary internet connection for HQ",
                        Active = true,
                        RecordAdd = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                    },
                    new InternetAccount
                    {
                        Id = 2,
                        LocationId = 2,
                        InternetProvider = "Comcast Business",
                        ServiceType = "Cable",
                        DataAccountNumber = "CMCST-987654321",
                        ConnectionType = "Cable",
                        ConnectionSpeed = "500 Mbps",
                        IPAddress = "198.51.100.25",
                        SubnetMask = "255.255.255.0",
                        DefaultGateway = "198.51.100.1",
                        DNSPrimary = "75.75.75.75",
                        DNSSecondary = "75.75.76.76",
                        AccountAddedDate = new DateTime(2023, 08, 01, 0, 0, 0, DateTimeKind.Utc),
                        BillEntryDate = new DateTime(2023, 08, 01, 0, 0, 0, DateTimeKind.Utc),
                        MonthlyCost = 299.99m,
                        AdminPortalURL = "https://business.comcast.com",
                        AdminUsername = "metalmart_admin",
                        Notes = "Backup connection also available",
                        Active = true,
                        RecordAdd = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                    },
                    new InternetAccount
                    {
                        Id = 3,
                        LocationId = 3,
                        InternetProvider = "Suddenlink Business",
                        ServiceType = "Cable",
                        DataAccountNumber = "SDLN-456789123",
                        ConnectionType = "Cable",
                        ConnectionSpeed = "300 Mbps",
                        IPAddress = "192.0.2.50",
                        SubnetMask = "255.255.255.0",
                        DefaultGateway = "192.0.2.1",
                        DNSPrimary = "8.8.8.8",
                        AccountAddedDate = new DateTime(2023, 08, 01, 0, 0, 0, DateTimeKind.Utc),
                        BillEntryDate = new DateTime(2023, 08, 01, 0, 0, 0, DateTimeKind.Utc),
                        MonthlyCost = 199.99m,
                        Active = true,
                        RecordAdd = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                    },
                    new InternetAccount
                    {
                        Id = 4,
                        LocationId = 4,
                        InternetProvider = "AT&T Business",
                        ServiceType = "Fiber",
                        DataAccountNumber = "ATT-987123456",
                        CircuitId = "ATTF/987654/DFW",
                        ConnectionType = "Fiber",
                        ConnectionSpeed = "500 Mbps",
                        IPAddress = "203.0.113.75",
                        SubnetMask = "255.255.255.0",
                        DefaultGateway = "203.0.113.1",
                        DNSPrimary = "8.8.8.8",
                        DNSSecondary = "8.8.4.4",
                        AccountAddedDate = new DateTime(2023, 08, 01, 0, 0, 0, DateTimeKind.Utc),
                        BillEntryDate = new DateTime(2023, 08, 01, 0, 0, 0, DateTimeKind.Utc),
                        MonthlyCost = 449.99m,
                        AdminPortalURL = "https://business.att.com",
                        AdminUsername = "plant_admin",
                        Notes = "Critical - 24/7 operations",
                        Active = true,
                        RecordAdd = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                    }
                );
            });

            // ============================================
            // PhoneAccount Configuration & Seed Data
            // ============================================
            modelBuilder.Entity<PhoneAccount>(entity =>
            {
                entity.ToTable("PhoneAccounts");

                entity.HasIndex(pa => pa.LocationId).IsUnique();

                entity.HasMany(a => a.AccountManagers)
                    .WithOne(am => am.PhoneAccount)
                    .HasForeignKey(am => am.PhoneAccountId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(a => a.RepairContacts)
                    .WithOne(rc => rc.PhoneAccount)
                    .HasForeignKey(rc => rc.PhoneAccountId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasIndex(a => a.Active);
                entity.HasIndex(a => a.LocalProvider);

                // ✅ SEED DATA - Phone Accounts
                entity.HasData(
                    new PhoneAccount
                    {
                        Id = 1,
                        LocationId = 1,
                        LocalProvider = "AT&T",
                        LocalAccountNumber = "ATT-LOCAL-789456",
                        LongDistanceProvider = "AT&T",
                        LongDistanceAccountNumber = "ATT-LD-789456",
                        TermNumber = "318-555-0100",
                        FaxNumber = "318-555-0101",
                        TollFreeNumber1 = "800-555-0100",
                        TollFreeNumber2 = "888-555-0100",
                        RolloverNumbers = "318-555-0102, 318-555-0103, 318-555-0104",
                        AccountAddedDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                        BillEntryDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                        MonthlyCost = 350.00m,
                        Notes = "Main phone system with 12 lines",
                        Active = true,
                        RecordAdd = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                    },
                    new PhoneAccount
                    {
                        Id = 2,
                        LocationId = 2,
                        LocalProvider = "CenturyLink",
                        LocalAccountNumber = "CTL-456789123",
                        LongDistanceProvider = "CenturyLink",
                        LongDistanceAccountNumber = "CTL-456789123",
                        TermNumber = "318-555-0200",
                        FaxNumber = "318-555-0201",
                        TollFreeNumber1 = "800-555-0200",
                        AccountAddedDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                        BillEntryDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                        MonthlyCost = 225.00m,
                        Notes = "6 line business system",
                        Active = true,
                        RecordAdd = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)
                    },
                    new PhoneAccount
                    {
                        Id = 3,
                        LocationId = 3,
                        LocalProvider = "AT&T",
                        LocalAccountNumber = "ATT-LOCAL-321654",
                        TermNumber = "318-555-0300",
                        FaxNumber = "318-555-0301",
                        AccountAddedDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                        BillEntryDate = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc),
                        MonthlyCost = 175.00m,
                        Notes = "4 line system",
                        Active = true,
                        RecordAdd = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc)

                    }
                );
            });

            // ============================================
            // AccountManager Configuration & Seed Data
            // ============================================
            modelBuilder.Entity<AccountManager>(entity =>
            {
                entity.ToTable("AccountManagers", t => t.HasCheckConstraint(
                    "CK_AccountManager_ValidAccountType",
                    GetAccountTypeCheckConstraint())
                    );


                entity.HasIndex(am => am.InternetAccountId);
                entity.HasIndex(am => am.PhoneAccountId);
                entity.HasIndex(am => am.AccountType);
                entity.HasIndex(am => am.AMEmail);

                // ✅ SEED DATA - Account Managers
                entity.HasData(
                    // Internet Account Managers
                    new AccountManager
                    {
                        Id = 1,
                        InternetAccountId = 1,
                        AccountType = AccountType.Internet,
                        AMCompany = "AT&T Business Support",
                        AMName = "Jennifer Martinez",
                        AMEmail = "j.martinez@att.com",
                        AMPhone = "888-321-8880"
                    },
                    new AccountManager
                    {
                        Id = 2,
                        InternetAccountId = 2,
                        AccountType = AccountType.Internet,
                        AMCompany = "Comcast Business Sales",
                        AMName = "Michael Thompson",
                        AMEmail = "m.thompson@comcast.com",
                        AMPhone = "800-555-2020"
                    },
                    // Phone Account Managers
                    new AccountManager
                    {
                        Id = 3,
                        PhoneAccountId = 1,
                        AccountType = AccountType.Phone,
                        AMCompany = "AT&T Business Voice",
                        AMName = "Patricia Rodriguez",
                        AMEmail = "p.rodriguez@att.com",
                        AMPhone = "888-321-8881"
                    },
                    new AccountManager
                    {
                        Id = 4,
                        PhoneAccountId = 2,
                        AccountType = AccountType.Phone,
                        AMCompany = "CenturyLink Business",
                        AMName = "Robert Chen",
                        AMEmail = "r.chen@centurylink.com",
                        AMPhone = "877-453-1234"
                    },
                    // Account Manager for BOTH (Internet Account 3 and Phone Account 3)
                    new AccountManager
                    {
                        Id = 5,
                        InternetAccountId = 3,
                        PhoneAccountId = 3,
                        AccountType = AccountType.Both,
                        AMCompany = "Suddenlink/AT&T Business",
                        AMName = "Amanda Johnson",
                        AMEmail = "a.johnson@business.com",
                        AMPhone = "866-789-4560"
                    }
                );
            });

            // ============================================
            // RepairContact Configuration & Seed Data
            // ============================================
            modelBuilder.Entity<RepairContact>(entity =>
            {
                entity.ToTable("RepairContacts", rc => rc.HasCheckConstraint(
                    "CK_RepairContact_ValidAccountType",
                    GetAccountTypeCheckConstraint())
                    );

                entity.HasIndex(rc => rc.InternetAccountId);
                entity.HasIndex(rc => rc.PhoneAccountId);
                entity.HasIndex(rc => rc.AccountType);

                // ✅ SEED DATA - Repair Contacts
                entity.HasData(
                    // Internet Repair Contacts
                    new RepairContact
                    {
                        Id = 1,
                        InternetAccountId = 1,
                        AccountType = AccountType.Internet,
                        RPCompany = "AT&T Business Repair",
                        RPName = "Technical Support Team",
                        RPPhone = "800-321-2000",
                        RPEmail = "test@mcelroymetal.com",
                        RPPortal = "https://support.business.att.com"
                    },
                    new RepairContact
                    {
                        Id = 2,
                        InternetAccountId = 2,
                        AccountType = AccountType.Internet,
                        RPCompany = "Comcast Business Care",
                        RPName = "Network Operations",
                        RPPhone = "800-391-3000",
                        RPEmail = "test@mcelroymetal.com",
                        RPPortal = "https://business.comcast.com/support"
                    },
                    // Phone Repair Contacts
                    new RepairContact
                    {
                        Id = 3,
                        PhoneAccountId = 1,
                        AccountType = AccountType.Phone,
                        RPCompany = "AT&T Business Voice Support",
                        RPName = "Voice Technical Team",
                        RPEmail = "test@mcelroymetal.com",
                        RPPhone = "800-321-2001"
                    },
                    new RepairContact
                    {
                        Id = 4,
                        PhoneAccountId = 2,
                        AccountType = AccountType.Phone,
                        RPCompany = "CenturyLink Repair",
                        RPName = "Business Support Center",
                        RPPhone = "877-453-1235",
                        RPEmail = "test@mcelroymetal.com",
                        RPPortal = "https://business.centurylink.com/help"
                    },
                    // Repair Contact for BOTH
                    new RepairContact
                    {
                        Id = 5,
                        InternetAccountId = 3,
                        PhoneAccountId = 3,
                        AccountType = AccountType.Both,
                        RPCompany = "Suddenlink Business Support",
                        RPName = "Unified Support Team",
                        RPPhone = "877-694-9474",
                        RPEmail = "test@mcelroymetal.com",
                        RPPortal = "https://business.suddenlink.com/support"
                    }
                );
            });
        }
    }
}