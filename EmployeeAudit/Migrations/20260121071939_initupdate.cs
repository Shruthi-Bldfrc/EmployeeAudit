using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAudit.Migrations
{
    /// <inheritdoc />
    public partial class initupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActionUser",
                table: "EmployeeAudits",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionUser",
                table: "EmployeeAudits");
        }
    }
}
