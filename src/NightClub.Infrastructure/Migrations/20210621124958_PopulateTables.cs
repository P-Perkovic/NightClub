using Microsoft.EntityFrameworkCore.Migrations;

namespace NightClub.Infrastructure.Migrations
{
    public partial class PopulateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 1, c.Id FROM [dbo].[Categories] c WHERE Name = 'VIP'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 2, c.Id FROM [dbo].[Categories] c WHERE Name = 'VIP'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 3, c.Id FROM [dbo].[Categories] c WHERE Name = 'VIP'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 4, c.Id FROM [dbo].[Categories] c WHERE Name = 'VIP'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 5, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 6, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 7, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 8, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 9, c.Id FROM [dbo].[Categories] c WHERE Name = 'WallTable'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 10, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 11, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 12, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 13, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 14, c.Id FROM [dbo].[Categories] c WHERE Name = 'WallTable'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 15, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 16, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 17, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 18, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 19, c.Id FROM [dbo].[Categories] c WHERE Name = 'WallTable'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 20, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 21, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 22, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 23, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 24, c.Id FROM [dbo].[Categories] c WHERE Name = 'WallTable'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 25, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 26, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 27, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 28, c.Id FROM [dbo].[Categories] c WHERE Name = 'Standard'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 29, c.Id FROM [dbo].[Categories] c WHERE Name = 'WallTable'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 30, c.Id FROM [dbo].[Categories] c WHERE Name = 'WallTable'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 31, c.Id FROM [dbo].[Categories] c WHERE Name = 'WallTable'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 32, c.Id FROM [dbo].[Categories] c WHERE Name = 'WallTable'
                                    INSERT INTO [dbo].[Tables] ([OrdinalNumber], [CategoryId]) SELECT 33, c.Id FROM [dbo].[Categories] c WHERE Name = 'WallTable'
                                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                                    DELETE FROM [dbo].[Tables]
                                ");
        }
    }
}
