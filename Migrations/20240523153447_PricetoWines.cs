using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineHouse.Migrations
{
    public partial class PricetoWines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Wines",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Wines");
        }
    }
}
