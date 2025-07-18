using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISKI.SARS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addLogDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "LogEntries",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "LogEntries");
        }
    }
}
