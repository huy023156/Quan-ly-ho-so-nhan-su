using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddToEmployeeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeTable",
                columns: new[] { "Id", "ChiNhanhNganHangId", "ChucDanhId", "DateOfBirth", "Email", "Gender", "Name", "NgayTao", "NgayUpdate", "NguoiTao", "NguoiUpdate", "PhoneNumber", "PhongBanId" , "DiaChiId"},
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2003, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "huy023156@gmail.com", true, "Nguyen Quang Huy", new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1459), null, "Admin", null, "0369694076", 1, 12 },
                    { 2, 2, 2, new DateTime(2002, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "miaf@mai.com", false, "Nguyen Phuong Mai", new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1472), null, "Admin", null, "0123485682", 2, 13}
                });
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmployeeTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 14, 3, 29, 934, DateTimeKind.Local).AddTicks(9990));

            migrationBuilder.UpdateData(
                table: "EmployeeTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "NgayTao",
                value: new DateTime(2024, 7, 11, 14, 3, 29, 935, DateTimeKind.Local).AddTicks(6));

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
        }
    }
}
