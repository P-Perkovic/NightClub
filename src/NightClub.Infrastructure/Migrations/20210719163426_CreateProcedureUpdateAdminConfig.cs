using Microsoft.EntityFrameworkCore.Migrations;

namespace NightClub.Infrastructure.Migrations
{
	public partial class CreateProcedureUpdateAdminConfig : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
										CREATE PROCEDURE dbo.stpUpdateAdminConfig @Key varchar(255), @Value varchar(255), @TypeName varchar(255)
										AS

										DECLARE @TableCategory varchar(255) = '%TableCategory'
										DECLARE @VIP varchar(255) = 'VIP%'
										DECLARE @Standard varchar(255) = 'Standard%'
										DECLARE @MinBillV varchar(255) = '%MinBillValue%'
										DECLARE @SQL nvarchar(max) = N'UPDATE '
										DECLARE @params nvarchar(400) = '@Key varchar(255), @Value varchar(255), @TypeName varchar(255)'

										IF @Key LIKE @TableCategory 
										BEGIN
											SELECT @SQL = @SQL + 'dbo.Categories SET '
											IF @Key LIKE @MinBillV
												SELECT @SQL = @SQL + 'MinBillValue = @Value '
											ELSE
												SELECT @SQL = @SQL + 'MaxNumberOfGuests = @Value '

											IF @Key LIKE @VIP
												SELECT @SQL = @SQL + 'WHERE Name = ''VIP'''
											ELSE IF @Key LIKE @Standard
												SELECT @SQL = @SQL + 'WHERE Name = ''Standard'''
											ELSE 
												SELECT @SQL = @SQL + 'WHERE Name = ''WallTable'''
										END

										ELSE 
												SELECT @SQL = @SQL + 'dbo.AdminConfigs SET [Value] = @Value, TypeName = @TypeName WHERE [Key] = @Key'

										EXEC sp_executesql @SQL, @params, @Key, @Value, @TypeName;
									");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
										IF EXISTS (SELECT * FROM sys.objects WHERE TYPE = 'p' AND NAME = 'stpUpdateAdminConfig' )
										BEGIN
											DROP PROCEDURE dbo.stpUpdateAdminConfig;
										END
										GO
									");
		}
	}
}
