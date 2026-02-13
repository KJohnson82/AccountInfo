using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountInfo.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConvertLoctypetoEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Loctypes_LoctypeId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "Loctypes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Loctypes_LoctypeId",
                table: "Locations",
                column: "LoctypeId",
                principalTable: "Loctypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
