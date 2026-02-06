using AccountInfo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountInfo.Data
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
        public DbSet<Loctype> Loctypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ============================================
            // Loctype Configuration
            // ============================================
            modelBuilder.Entity<Loctype>(entity =>
            {
                entity.ToTable("Loctypes");

                entity.Property(e => e.LoctypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                // Seed static data - only these 5 types
                entity.HasData(
                    new Loctype { Id = 1, LoctypeName = "Corporate" },
                    new Loctype { Id = 2, LoctypeName = "Metal Mart" },
                    new Loctype { Id = 3, LoctypeName = "Service Center" },
                    new Loctype { Id = 4, LoctypeName = "Plant" },
                    new Loctype { Id = 5, LoctypeName = "Other" }
                );
            });

            // ============================================
            // Location Configuration
            // ============================================
            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Locations");

                // Relationship with Loctype
                entity.HasOne(l => l.LocationType)
                    .WithMany(lt => lt.Locations)
                    .HasForeignKey(l => l.LoctypeId)
                    .OnDelete(DeleteBehavior.Restrict);

                // One Location -> Many InternetAccounts
                entity.HasMany(l => l.InternetAccounts)
                    .WithOne(ia => ia.Location)
                    .HasForeignKey(ia => ia.LocationId)
                    .OnDelete(DeleteBehavior.Restrict);

                // One Location -> One PhoneAccount (or zero)
                entity.HasOne(l => l.PhoneAccount)
                    .WithOne(pa => pa.Location)
                    .HasForeignKey<PhoneAccount>(pa => pa.LocationId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Indexes for common queries
                entity.HasIndex(l => l.LocNum).IsUnique();
                entity.HasIndex(l => l.Active);
                entity.HasIndex(l => l.LoctypeId);
            });

            // ============================================
            // InternetAccount Configuration
            // ============================================
            modelBuilder.Entity<InternetAccount>(entity =>
            {
                entity.ToTable("InternetAccounts");

                // Relationships with AccountManagers and RepairContacts
                entity.HasMany(a => a.AccountManagers)
                    .WithOne(am => am.InternetAccount)
                    .HasForeignKey(am => am.InternetAccountId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(a => a.RepairContacts)
                    .WithOne(rc => rc.InternetAccount)
                    .HasForeignKey(rc => rc.InternetAccountId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Indexes
                entity.HasIndex(a => a.LocationId);
                entity.HasIndex(a => a.Active);
                entity.HasIndex(a => a.InternetProvider);
            });

            // ============================================
            // PhoneAccount Configuration
            // ============================================
            modelBuilder.Entity<PhoneAccount>(entity =>
            {
                entity.ToTable("PhoneAccounts");

                // Unique constraint - one location can only have ONE phone account
                entity.HasIndex(pa => pa.LocationId).IsUnique();

                // Relationships with AccountManagers and RepairContacts
                entity.HasMany(a => a.AccountManagers)
                    .WithOne(am => am.PhoneAccount)
                    .HasForeignKey(am => am.PhoneAccountId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(a => a.RepairContacts)
                    .WithOne(rc => rc.PhoneAccount)
                    .HasForeignKey(rc => rc.PhoneAccountId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Indexes
                entity.HasIndex(a => a.Active);
                entity.HasIndex(a => a.LocalProvider);
            });

            // ============================================
            // AccountManager Configuration
            // ============================================
            modelBuilder.Entity<AccountManager>(entity =>
            {
                entity.ToTable("AccountManagers");

                // Check constraint: Must have correct foreign keys based on AccountType
                // AccountType.Phone = 2, AccountType.Internet = 1, AccountType.Both = 3
                entity.ToTable(t => t.HasCheckConstraint(
                    "CK_AccountManager_ValidAccountType",
                    @"(AccountType = 2 AND PhoneAccountId IS NOT NULL AND InternetAccountId IS NULL) OR 
                      (AccountType = 1 AND InternetAccountId IS NOT NULL AND PhoneAccountId IS NULL) OR 
                      (AccountType = 3 AND InternetAccountId IS NOT NULL AND PhoneAccountId IS NOT NULL)"
                ));

                // Indexes
                entity.HasIndex(am => am.InternetAccountId);
                entity.HasIndex(am => am.PhoneAccountId);
                entity.HasIndex(am => am.AccountType);
                entity.HasIndex(am => am.AMEmail);
            });

            // ============================================
            // RepairContact Configuration
            // ============================================
            modelBuilder.Entity<RepairContact>(entity =>
            {
                entity.ToTable("RepairContacts");

                // Check constraint: Must have correct foreign keys based on AccountType
                // AccountType.Phone = 2, AccountType.Internet = 1, AccountType.Both = 3
                entity.ToTable(t => t.HasCheckConstraint(
                    "CK_RepairContact_ValidAccountType",
                    @"(AccountType = 2 AND PhoneAccountId IS NOT NULL AND InternetAccountId IS NULL) OR 
                      (AccountType = 1 AND InternetAccountId IS NOT NULL AND PhoneAccountId IS NULL) OR 
                      (AccountType = 3 AND InternetAccountId IS NOT NULL AND PhoneAccountId IS NOT NULL)"
                ));

                // Indexes
                entity.HasIndex(rc => rc.InternetAccountId);
                entity.HasIndex(rc => rc.PhoneAccountId);
                entity.HasIndex(rc => rc.AccountType);
            });
        }
    }
}