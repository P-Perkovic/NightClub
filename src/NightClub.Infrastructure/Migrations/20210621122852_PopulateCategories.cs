using Microsoft.EntityFrameworkCore.Migrations;

namespace NightClub.Infrastructure.Migrations
{
    public partial class PopulateCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    INSERT INTO [dbo].[Categories] ([Name], [MinBillValue], [MaxNumberOfGuests]) 
                                    VALUES (N'VIP', CAST(1000.00 AS Decimal(18, 2)), 8)
                                    INSERT INTO [dbo].[Categories] ([Name], [MinBillValue], [MaxNumberOfGuests]) 
                                    VALUES (N'Standard', CAST(500.00 AS Decimal(18, 2)), 6)
                                    INSERT INTO [dbo].[Categories] ([Name], [MinBillValue], [MaxNumberOfGuests]) 
                                    VALUES (N'WallTable', CAST(300.00 AS Decimal(18, 2)), 4)
                                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                   DELETE FROM [dbo].[Categories]
                                ");
        }
    }
}
