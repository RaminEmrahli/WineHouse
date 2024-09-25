using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WineHouse.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Movie",
                table: "Orders",
                newName: "Wine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wine",
                table: "Orders",
                newName: "Movie");
        }
    }
}
