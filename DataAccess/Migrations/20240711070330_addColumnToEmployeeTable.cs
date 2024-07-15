using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addColumnToEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiaChiDetail",
                table: "EmployeeTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DiaChiId",
                table: "EmployeeTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "EmployeeTable",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DiaChiDetail", "DiaChiId", "NgayTao" },
                values: new object[] { "số 13 ngõ 5 đường ngô đình mẫn", 12, new DateTime(2024, 7, 11, 14, 3, 29, 934, DateTimeKind.Local).AddTicks(9990) });

            migrationBuilder.UpdateData(
                table: "EmployeeTable",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DiaChiDetail", "DiaChiId", "NgayTao" },
                values: new object[] { "số 16 đường chiến thắng", 13, new DateTime(2024, 7, 11, 14, 3, 29, 935, DateTimeKind.Local).AddTicks(6) });

            migrationBuilder.UpdateData(
                table: "HoSoLuongTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 14, 3, 29, 935, DateTimeKind.Local).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "HoSoLuongTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 14, 3, 29, 935, DateTimeKind.Local).AddTicks(43));

            migrationBuilder.UpdateData(
                table: "HopDongDetailTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 14, 3, 29, 935, DateTimeKind.Local).AddTicks(182));

            migrationBuilder.UpdateData(
                table: "HopDongDetailTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 14, 3, 29, 935, DateTimeKind.Local).AddTicks(185));

            migrationBuilder.UpdateData(
                table: "QuyetDinhDetailTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 14, 3, 29, 935, DateTimeKind.Local).AddTicks(142));

            migrationBuilder.UpdateData(
                table: "QuyetDinhDetailTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 14, 3, 29, 935, DateTimeKind.Local).AddTicks(144));

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTable_DiaChiId",
                table: "EmployeeTable",
                column: "DiaChiId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTable_DiaChiTable_DiaChiId",
                table: "EmployeeTable",
                column: "DiaChiId",
                principalTable: "DiaChiTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTable_DiaChiTable_DiaChiId",
                table: "EmployeeTable");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTable_DiaChiId",
                table: "EmployeeTable");

            migrationBuilder.DropColumn(
                name: "DiaChiDetail",
                table: "EmployeeTable");

            migrationBuilder.DropColumn(
                name: "DiaChiId",
                table: "EmployeeTable");

            migrationBuilder.UpdateData(
                table: "EmployeeTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1459));

            migrationBuilder.UpdateData(
                table: "EmployeeTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "HoSoLuongTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1503));

            migrationBuilder.UpdateData(
                table: "HoSoLuongTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1505));

            migrationBuilder.UpdateData(
                table: "HopDongDetailTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1638));

            migrationBuilder.UpdateData(
                table: "HopDongDetailTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1640));

            migrationBuilder.UpdateData(
                table: "QuyetDinhDetailTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "QuyetDinhDetailTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1604));
        }
    }
}
