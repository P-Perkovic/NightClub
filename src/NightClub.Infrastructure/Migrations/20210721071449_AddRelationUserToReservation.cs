using Microsoft.EntityFrameworkCore.Migrations;

namespace NightClub.Infrastructure.Migrations
{
    public partial class AddRelationUserToReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReservedFor",
                table: "Reservations",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserStringId",
                table: "Reservations",
                type: "varchar(150)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserStringId",
                table: "Reservations",
                column: "UserStringId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_UserStringId",
                table: "Reservations",
                column: "UserStringId",
                principalTable: "Users",
                principalColumn: "StringId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_UserStringId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_UserStringId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservedFor",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UserStringId",
                table: "Reservations");
        }
    }
}
