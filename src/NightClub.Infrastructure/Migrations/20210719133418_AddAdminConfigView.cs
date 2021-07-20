using Microsoft.EntityFrameworkCore.Migrations;

namespace NightClub.Infrastructure.Migrations
{
	public partial class AddAdminConfigView : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
										CREATE VIEW dbo.vwAdminConfigs
										AS
										SELECT AC.[Key],
											   AC.[Value],
											   AC.[TypeName]
										FROM dbo.AdminConfigs AC
										UNION ALL
										SELECT C.[Name] + 'MaxNumberOfGuests_TableCategory' AS [Key],
											   CAST( C.[MaxNumberOfGuests] as varchar) AS [Value],
											   'int32' AS TypeName
										FROM dbo.Categories C
										UNION ALL
										SELECT C.[Name] + 'MinBillValue_TableCategory' AS [Key],
											   CAST( C.[MinBillValue] as varchar) AS [Value],
											   'decimal' As TypeName
										FROM dbo.Categories C
								  ");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
									IF EXISTS (SELECT * FROM sys. objects WHERE object_id = OBJECT_ID('dbo.vwAdminConfigs') AND type = 'V')
										BEGIN
											DROP VIEW dbo.vwAdminConfigs
										END
										GO
								  ");
		}
	}
}
