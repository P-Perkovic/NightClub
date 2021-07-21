using Microsoft.EntityFrameworkCore.Migrations;

namespace NightClub.Infrastructure.Migrations
{
    public partial class CorrectReservations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Reservations",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reservations",
                type: "varchar(150)",
                nullable: true,
                oldClrType: typeof(int),
                oldDefaultValue: 2);
        }
    }
}
