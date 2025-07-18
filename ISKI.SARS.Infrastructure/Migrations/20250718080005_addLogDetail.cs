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
                table: "LogEntry",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "LogEntry");
        }
    }
}
