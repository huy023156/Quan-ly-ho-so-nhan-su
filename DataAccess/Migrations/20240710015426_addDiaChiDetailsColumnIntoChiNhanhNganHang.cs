using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addDiaChiDetailsColumnIntoChiNhanhNganHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiaChiDetails",
                table: "ChiNhanhNganHangTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ChiNhanhNganHangTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "DiaChiDetails",
                value: "12 Le Trong Tan");

            migrationBuilder.UpdateData(
                table: "ChiNhanhNganHangTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "DiaChiDetails",
                value: "20 Duong Lang");

            migrationBuilder.UpdateData(
                table: "ChiNhanhNganHangTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "DiaChiDetails",
                value: "50 Duong Mac Thai Tong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaChiDetails",
                table: "ChiNhanhNganHangTable");
        }
    }
}
