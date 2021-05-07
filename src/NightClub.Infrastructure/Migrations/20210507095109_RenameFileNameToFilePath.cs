using Microsoft.EntityFrameworkCore.Migrations;

namespace NightClub.Infrastructure.Migrations
{
    public partial class RenameFileNameToFilePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Photos",
                newName: "FilePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "Photos",
                newName: "FileName");
        }
    }
}
