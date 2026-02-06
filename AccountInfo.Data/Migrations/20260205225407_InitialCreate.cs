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
                    table.CheckConstraint("CK_AccountManager_ValidAccountType", "(AccountType = 2 AND PhoneAccountId IS NOT NULL AND InternetAccountId IS NULL) OR \r\n                      (AccountType = 1 AND InternetAccountId IS NOT NULL AND PhoneAccountId IS NULL) OR \r\n                      (AccountType = 3 AND InternetAccountId IS NOT NULL AND PhoneAccountId IS NOT NULL)");
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
                    table.CheckConstraint("CK_RepairContact_ValidAccountType", "(AccountType = 2 AND PhoneAccountId IS NOT NULL AND InternetAccountId IS NULL) OR \r\n                      (AccountType = 1 AND InternetAccountId IS NOT NULL AND PhoneAccountId IS NULL) OR \r\n                      (AccountType = 3 AND InternetAccountId IS NOT NULL AND PhoneAccountId IS NOT NULL)");
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
