using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addResignationDateToResignationTable : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<DateOnly>(
				name: "ResignationDate",
				table: "ResignationTable",
				type: "date",
				nullable: false,
				defaultValue: new DateOnly(1900, 1, 1)); // Giá trị mặc định có thể thay đổi tùy ý
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "ResignationDate",
				table: "ResignationTable");
		}
	}
}
