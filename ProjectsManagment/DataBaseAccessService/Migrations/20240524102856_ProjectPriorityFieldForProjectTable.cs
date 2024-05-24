using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseAccessService.Migrations
{
    /// <inheritdoc />
    public partial class ProjectPriorityFieldForProjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectPriority",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectPriority",
                table: "Projects");
        }
    }
}
