using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ISKI.SARS.Infrastructure.Migrations
{
    public partial class addTagDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ReportTemplateTags",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ReportTemplateTags");
        }
    }
}
