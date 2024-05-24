using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseAccessService.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProjAndTastToForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_LeaderId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "LeaderId",
                table: "Projects",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_LeaderId",
                table: "Projects",
                newName: "IX_Projects_EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_EmployeeId",
                table: "Projects",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Employees_EmployeeId",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Projects",
                newName: "LeaderId");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_EmployeeId",
                table: "Projects",
                newName: "IX_Projects_LeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Employees_LeaderId",
                table: "Projects",
                column: "LeaderId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
