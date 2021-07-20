using Microsoft.EntityFrameworkCore.Migrations;

namespace NightClub.Infrastructure.Migrations
{
    public partial class PopulateAdminConfigs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql(@"
                                    INSERT INTO [dbo].[AdminConfigs] ([Key], [Value], [TypeName]) VALUES (N'ReservationPeriod', N'1', N'Month') 
                                  ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    DELETE FROM [dbo].[AdminConfigs]
                                  ");
        }
    }
}
