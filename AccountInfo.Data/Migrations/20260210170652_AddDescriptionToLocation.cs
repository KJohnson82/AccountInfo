using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountInfo.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RPEmail",
                table: "RepairContacts",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RepairContacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "RPEmail",
                value: "test@mcelroymetal.com");

            migrationBuilder.UpdateData(
                table: "RepairContacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "RPEmail",
                value: "test@mcelroymetal.com");

            migrationBuilder.UpdateData(
                table: "RepairContacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "RPEmail",
                value: "test@mcelroymetal.com");

            migrationBuilder.UpdateData(
                table: "RepairContacts",
                keyColumn: "Id",
                keyValue: 4,
                column: "RPEmail",
                value: "test@mcelroymetal.com");

            migrationBuilder.UpdateData(
                table: "RepairContacts",
                keyColumn: "Id",
                keyValue: 5,
                column: "RPEmail",
                value: "test@mcelroymetal.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RPEmail",
                table: "RepairContacts");
        }
    }
}
