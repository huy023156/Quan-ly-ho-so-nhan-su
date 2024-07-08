using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addIsAppliedToAllTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "XaPhuongTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "TinhThanhTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "TaiSanCapPhatTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "QuocGiaTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "QuanHuyenTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "PhuCapTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "PhongBanTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "PhongBanChucDanhTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "NganHangTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "HopDongTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "ChucDanhTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "ChiNhanhNganHangTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsApplied",
                table: "CheDoPhucLoiTable",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "CheDoPhucLoiTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "CheDoPhucLoiTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "CheDoPhucLoiTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "CheDoPhucLoiTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "CheDoPhucLoiTable",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "ChiNhanhNganHangTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "ChiNhanhNganHangTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "ChucDanhTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "ChucDanhTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "ChucDanhTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "ChucDanhTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "HopDongTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "HopDongTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "HopDongTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "HopDongTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "HopDongTable",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "NganHangTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "NganHangTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "NganHangTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "NganHangTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 9,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 10,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 11,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 12,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 13,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 14,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 15,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 16,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 17,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 18,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 19,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanChucDanhTable",
                keyColumn: "Id",
                keyValue: 20,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanTable",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhongBanTable",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhuCapTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhuCapTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhuCapTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhuCapTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhuCapTable",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "QuanHuyenTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "QuanHuyenTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "QuanHuyenTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "QuanHuyenTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "QuanHuyenTable",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "QuanHuyenTable",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "QuocGiaTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "QuocGiaTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "QuocGiaTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "TaiSanCapPhatTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "TaiSanCapPhatTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "TaiSanCapPhatTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "TaiSanCapPhatTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "TinhThanhTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "TinhThanhTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "TinhThanhTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "TinhThanhTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "XaPhuongTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "XaPhuongTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "XaPhuongTable",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "XaPhuongTable",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "XaPhuongTable",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "XaPhuongTable",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsApplied",
                value: true);

            migrationBuilder.UpdateData(
                table: "XaPhuongTable",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsApplied",
                value: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "XaPhuongTable");

            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "TinhThanhTable");

            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "TaiSanCapPhatTable");

            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "QuocGiaTable");

            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "QuanHuyenTable");

            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "PhuCapTable");

            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "PhongBanTable");

            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "PhongBanChucDanhTable");

            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "NganHangTable");

            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "HopDongTable");

            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "ChucDanhTable");

            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "ChiNhanhNganHangTable");

            migrationBuilder.DropColumn(
                name: "IsApplied",
                table: "CheDoPhucLoiTable");
        }
    }
}
