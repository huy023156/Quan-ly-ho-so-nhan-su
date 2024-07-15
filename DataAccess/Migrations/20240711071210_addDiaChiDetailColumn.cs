using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addDiaChiDetailColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmployeeTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "DiaChiDetail",
                value: "số 13 ngõ 5 đường ngô đình mẫn");

            migrationBuilder.UpdateData(
                table: "EmployeeTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "DiaChiDetail",
                value: "số 16 đường chiến thắng");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
