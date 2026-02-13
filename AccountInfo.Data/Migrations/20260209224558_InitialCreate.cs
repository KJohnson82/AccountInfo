using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountInfo.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loctypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoctypeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loctypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LocNum = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Zipcode = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    FaxNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: true),
                    Hours = table.Column<string>(type: "text", nullable: true),
                    LoctypeId = table.Column<int>(type: "integer", nullable: false),
                    AreaManager = table.Column<string>(type: "text", nullable: true),
                    StoreManager = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: true),
                    RecordAdd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Loctypes_LoctypeId",
                        column: x => x.LoctypeId,
                        principalTable: "Loctypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InternetAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    InternetProvider = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ServiceType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DataAccountNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CircuitId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ConnectionType = table.Column<string>(type: "text", nullable: true),
                    ConnectionSpeed = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IPAddress = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    SubnetMask = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DefaultGateway = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DNSPrimary = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    DNSSecondary = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    AccountAddedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BillEntryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MonthlyCost = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    AdminPortalURL = table.Column<string>(type: "text", nullable: true),
                    AdminUsername = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    AdminPassword = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    AdminInfo = table.Column<string>(type: "text", nullable: true),
                    AdminAnswers = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    RecordAdd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternetAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternetAccounts_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationId = table.Column<int>(type: "integer", nullable: false),
                    LocalProvider = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LocalAccountNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LongDistanceProvider = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    LongDistanceAccountNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    TermNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    FaxNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    TollFreeNumber1 = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    TollFreeNumber2 = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    RolloverNumbers = table.Column<string>(type: "text", nullable: true),
                    AccountAddedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    BillEntryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MonthlyCost = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    RecordAdd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneAccounts_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountManagers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InternetAccountId = table.Column<int>(type: "integer", nullable: true),
                    PhoneAccountId = table.Column<int>(type: "integer", nullable: true),
                    AccountType = table.Column<int>(type: "integer", nullable: false),
                    AMCompany = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AMName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AMEmail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AMPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountManagers", x => x.Id);
                    table.CheckConstraint("CK_AccountManager_ValidAccountType", "(\"AccountType\" = 2 AND \"PhoneAccountId\" IS NOT NULL AND \"InternetAccountId\" IS NULL) OR \r\n                     (\"AccountType\" = 1 AND \"InternetAccountId\" IS NOT NULL AND \"PhoneAccountId\" IS NULL) OR \r\n                     (\"AccountType\" = 3 AND \"InternetAccountId\" IS NOT NULL AND \"PhoneAccountId\" IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_AccountManagers_InternetAccounts_InternetAccountId",
                        column: x => x.InternetAccountId,
                        principalTable: "InternetAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountManagers_PhoneAccounts_PhoneAccountId",
                        column: x => x.PhoneAccountId,
                        principalTable: "PhoneAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepairContacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InternetAccountId = table.Column<int>(type: "integer", nullable: true),
                    PhoneAccountId = table.Column<int>(type: "integer", nullable: true),
                    AccountType = table.Column<int>(type: "integer", nullable: false),
                    RPCompany = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RPName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RPPhone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    RPPortal = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairContacts", x => x.Id);
                    table.CheckConstraint("CK_RepairContact_ValidAccountType", "(\"AccountType\" = 2 AND \"PhoneAccountId\" IS NOT NULL AND \"InternetAccountId\" IS NULL) OR \r\n                     (\"AccountType\" = 1 AND \"InternetAccountId\" IS NOT NULL AND \"PhoneAccountId\" IS NULL) OR \r\n                     (\"AccountType\" = 3 AND \"InternetAccountId\" IS NOT NULL AND \"PhoneAccountId\" IS NOT NULL)");
                    table.ForeignKey(
                        name: "FK_RepairContacts_InternetAccounts_InternetAccountId",
                        column: x => x.InternetAccountId,
                        principalTable: "InternetAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairContacts_PhoneAccounts_PhoneAccountId",
                        column: x => x.PhoneAccountId,
                        principalTable: "PhoneAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Loctypes",
                columns: new[] { "Id", "LoctypeName" },
                values: new object[,]
                {
                    { 1, "Corporate" },
                    { 2, "Metal Mart" },
                    { 3, "Service Center" },
                    { 4, "Plant" },
                    { 5, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Active", "Address", "AreaManager", "City", "Email", "FaxNumber", "Hours", "LocName", "LocNum", "LoctypeId", "PhoneNumber", "RecordAdd", "State", "StoreManager", "Zipcode" },
                values: new object[,]
                {
                    { 1, true, "123 Main Street", "John Smith", "Bossier City", "hq@company.com", "318-555-0101", "Mon-Fri 8AM-5PM", "Corporate Headquarters", 101, 1, "318-555-0100", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "LA", "Jane Doe", "71111" },
                    { 2, true, "456 Commerce Ave", "Mike Johnson", "Shreveport", "downtown@metalmart.com", "318-555-0201", "Mon-Sat 7AM-6PM", "Downtown Metal Mart", 201, 2, "318-555-0200", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "LA", "Sarah Williams", "71101" },
                    { 3, true, "789 Industrial Blvd", "Robert Brown", "Monroe", "north@service.com", "318-555-0301", "Mon-Fri 7AM-5PM", "North Service Center", 601, 3, "318-555-0300", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "LA", "Emily Davis", "71201" },
                    { 4, true, "321 Manufacturing Dr", "David Miller", "Alexandria", "plant@company.com", null, "24/7", "Alexandria Plant", 111, 4, "318-555-0400", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "LA", "Lisa Wilson", "71301" },
                    { 5, true, "555 Storage Lane", "Tom Anderson", "Bossier City", "warehouse@company.com", null, "Mon-Fri 6AM-4PM", "Warehouse Storage", 901, 5, "318-555-0500", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "LA", null, "71112" }
                });

            migrationBuilder.InsertData(
                table: "InternetAccounts",
                columns: new[] { "Id", "AccountAddedDate", "Active", "AdminAnswers", "AdminInfo", "AdminPassword", "AdminPortalURL", "AdminUsername", "BillEntryDate", "CircuitId", "ConnectionSpeed", "ConnectionType", "DNSPrimary", "DNSSecondary", "DataAccountNumber", "DefaultGateway", "IPAddress", "InternetProvider", "LocationId", "MonthlyCost", "Notes", "RecordAdd", "ServiceType", "SubnetMask" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, null, "Primary internet connection for HQ", "SecurePass123!", "https://business.att.com", "hq_admin", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ATTF/123456/DFW", "1 Gbps", "Fiber", "8.8.8.8", "8.8.4.4", "ATT-FB-1234567", "203.0.113.1", "203.0.113.10", "AT&T Business Fiber", 1, 599.99m, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Dedicated Fiber", "255.255.255.0" },
                    { 2, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, null, null, null, "https://business.comcast.com", "metalmart_admin", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "500 Mbps", "Cable", "75.75.75.75", "75.75.76.76", "CMCST-987654321", "198.51.100.1", "198.51.100.25", "Comcast Business", 2, 299.99m, "Backup connection also available", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cable", "255.255.255.0" },
                    { 3, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, null, null, null, null, null, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "300 Mbps", "Cable", "8.8.8.8", null, "SDLN-456789123", "192.0.2.1", "192.0.2.50", "Suddenlink Business", 3, 199.99m, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Cable", "255.255.255.0" },
                    { 4, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, null, null, null, "https://business.att.com", "plant_admin", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Utc), "ATTF/987654/DFW", "500 Mbps", "Fiber", "8.8.8.8", "8.8.4.4", "ATT-987123456", "203.0.113.1", "203.0.113.75", "AT&T Business", 4, 449.99m, "Critical - 24/7 operations", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fiber", "255.255.255.0" }
                });

            migrationBuilder.InsertData(
                table: "PhoneAccounts",
                columns: new[] { "Id", "AccountAddedDate", "Active", "BillEntryDate", "FaxNumber", "LocalAccountNumber", "LocalProvider", "LocationId", "LongDistanceAccountNumber", "LongDistanceProvider", "MonthlyCost", "Notes", "RecordAdd", "RolloverNumbers", "TermNumber", "TollFreeNumber1", "TollFreeNumber2" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "318-555-0101", "ATT-LOCAL-789456", "AT&T", 1, "ATT-LD-789456", "AT&T", 350.00m, "Main phone system with 12 lines", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "318-555-0102, 318-555-0103, 318-555-0104", "318-555-0100", "800-555-0100", "888-555-0100" },
                    { 2, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "318-555-0201", "CTL-456789123", "CenturyLink", 2, "CTL-456789123", "CenturyLink", 225.00m, "6 line business system", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "318-555-0200", "800-555-0200", null },
                    { 3, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), true, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "318-555-0301", "ATT-LOCAL-321654", "AT&T", 3, null, "", 175.00m, "4 line system", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, "318-555-0300", null, null }
                });

            migrationBuilder.InsertData(
                table: "AccountManagers",
                columns: new[] { "Id", "AMCompany", "AMEmail", "AMName", "AMPhone", "AccountType", "InternetAccountId", "PhoneAccountId" },
                values: new object[,]
                {
                    { 1, "AT&T Business Support", "j.martinez@att.com", "Jennifer Martinez", "888-321-8880", 1, 1, null },
                    { 2, "Comcast Business Sales", "m.thompson@comcast.com", "Michael Thompson", "800-555-2020", 1, 2, null },
                    { 3, "AT&T Business Voice", "p.rodriguez@att.com", "Patricia Rodriguez", "888-321-8881", 2, null, 1 },
                    { 4, "CenturyLink Business", "r.chen@centurylink.com", "Robert Chen", "877-453-1234", 2, null, 2 },
                    { 5, "Suddenlink/AT&T Business", "a.johnson@business.com", "Amanda Johnson", "866-789-4560", 3, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "RepairContacts",
                columns: new[] { "Id", "AccountType", "InternetAccountId", "PhoneAccountId", "RPCompany", "RPName", "RPPhone", "RPPortal" },
                values: new object[,]
                {
                    { 1, 1, 1, null, "AT&T Business Repair", "Technical Support Team", "800-321-2000", "https://support.business.att.com" },
                    { 2, 1, 2, null, "Comcast Business Care", "Network Operations", "800-391-3000", "https://business.comcast.com/support" },
                    { 3, 2, null, 1, "AT&T Business Voice Support", "Voice Technical Team", "800-321-2001", null },
                    { 4, 2, null, 2, "CenturyLink Repair", "Business Support Center", "877-453-1235", "https://business.centurylink.com/help" },
                    { 5, 3, 3, 3, "Suddenlink Business Support", "Unified Support Team", "877-694-9474", "https://business.suddenlink.com/support" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountManagers_AccountType",
                table: "AccountManagers",
                column: "AccountType");

            migrationBuilder.CreateIndex(
                name: "IX_AccountManagers_AMEmail",
                table: "AccountManagers",
                column: "AMEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AccountManagers_InternetAccountId",
                table: "AccountManagers",
                column: "InternetAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountManagers_PhoneAccountId",
                table: "AccountManagers",
                column: "PhoneAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_InternetAccounts_Active",
                table: "InternetAccounts",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_InternetAccounts_InternetProvider",
                table: "InternetAccounts",
                column: "InternetProvider");

            migrationBuilder.CreateIndex(
                name: "IX_InternetAccounts_LocationId",
                table: "InternetAccounts",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Active",
                table: "Locations",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocNum",
                table: "Locations",
                column: "LocNum",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LoctypeId",
                table: "Locations",
                column: "LoctypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneAccounts_Active",
                table: "PhoneAccounts",
                column: "Active");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneAccounts_LocalProvider",
                table: "PhoneAccounts",
                column: "LocalProvider");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneAccounts_LocationId",
                table: "PhoneAccounts",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairContacts_AccountType",
                table: "RepairContacts",
                column: "AccountType");

            migrationBuilder.CreateIndex(
                name: "IX_RepairContacts_InternetAccountId",
                table: "RepairContacts",
                column: "InternetAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairContacts_PhoneAccountId",
                table: "RepairContacts",
                column: "PhoneAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountManagers");

            migrationBuilder.DropTable(
                name: "RepairContacts");

            migrationBuilder.DropTable(
                name: "InternetAccounts");

            migrationBuilder.DropTable(
                name: "PhoneAccounts");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Loctypes");
        }
    }
}
