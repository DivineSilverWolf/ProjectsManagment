using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseAccessService.Migrations
{
    /// <inheritdoc />
    public partial class MailingAddressFieldForEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MailingAddress",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MailingAddress",
                table: "Employees",
                column: "MailingAddress",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_MailingAddress",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MailingAddress",
                table: "Employees");
        }
    }
}
