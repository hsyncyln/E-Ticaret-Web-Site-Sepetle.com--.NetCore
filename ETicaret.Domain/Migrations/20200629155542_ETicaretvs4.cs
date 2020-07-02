using Microsoft.EntityFrameworkCore.Migrations;

namespace ETicaret.Domain.Migrations
{
    public partial class ETicaretvs4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Bills",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Bills");
        }
    }
}
