using Microsoft.EntityFrameworkCore.Migrations;

namespace NightClub.Infrastructure.Migrations
{
    public partial class UpdateReservationsAndAddAdminConfigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCanceledByAdmin",
                table: "Reservations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Reservations",
                type: "varchar(150)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Reservations",
                type: "varchar(150)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdminConfigs",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(type: "varchar(255)", nullable: false),
                    TypeName = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminConfigs", x => x.Key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminConfigs");

            migrationBuilder.DropColumn(
                name: "IsCanceledByAdmin",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservations");
        }
    }
}
