using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifyChiNhanhNganHangTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiNhanhNganHangTable_XaPhuongTable_XaPhuongId",
                table: "ChiNhanhNganHangTable");

            migrationBuilder.DropColumn(
                name: "DiaChi",
                table: "ChiNhanhNganHangTable");

            migrationBuilder.RenameColumn(
                name: "XaPhuongId",
                table: "ChiNhanhNganHangTable",
                newName: "DiaChiId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiNhanhNganHangTable_XaPhuongId",
                table: "ChiNhanhNganHangTable",
                newName: "IX_ChiNhanhNganHangTable_DiaChiId");

            migrationBuilder.UpdateData(
                table: "ChiNhanhNganHangTable",
                keyColumn: "Id",
                keyValue: 2,
                column: "DiaChiId",
                value: 2);

            migrationBuilder.InsertData(
                table: "ChiNhanhNganHangTable",
                columns: new[] { "Id", "DiaChiId", "IsApplied", "NganHangId" },
                values: new object[] { 3, 3, true, 3 });

            migrationBuilder.AddForeignKey(
                name: "FK_ChiNhanhNganHangTable_DiaChiTable_DiaChiId",
                table: "ChiNhanhNganHangTable",
                column: "DiaChiId",
                principalTable: "DiaChiTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChiNhanhNganHangTable_DiaChiTable_DiaChiId",
                table: "ChiNhanhNganHangTable");

            migrationBuilder.DeleteData(
                table: "ChiNhanhNganHangTable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "DiaChiId",
                table: "ChiNhanhNganHangTable",
                newName: "XaPhuongId");

            migrationBuilder.RenameIndex(
                name: "IX_ChiNhanhNganHangTable_DiaChiId",
                table: "ChiNhanhNganHangTable",
                newName: "IX_ChiNhanhNganHangTable_XaPhuongId");

            migrationBuilder.AddColumn<string>(
                name: "DiaChi",
                table: "ChiNhanhNganHangTable",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ChiNhanhNganHangTable",
                keyColumn: "Id",
                keyValue: 1,
                column: "DiaChi",
                value: "12 đường Lê Trọng Tấn");

            migrationBuilder.UpdateData(
                table: "ChiNhanhNganHangTable",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DiaChi", "XaPhuongId" },
                values: new object[] { "69 đường Tôn Thất Thuyết", 4 });

            migrationBuilder.AddForeignKey(
                name: "FK_ChiNhanhNganHangTable_XaPhuongTable_XaPhuongId",
                table: "ChiNhanhNganHangTable",
                column: "XaPhuongId",
                principalTable: "XaPhuongTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
