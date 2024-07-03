using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addChiNhanhNganHangTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiNhanhNganHangTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NganHangId = table.Column<int>(type: "int", nullable: false),
                    XaPhuongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiNhanhNganHangTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiNhanhNganHangTable_NganHangTable_NganHangId",
                        column: x => x.NganHangId,
                        principalTable: "NganHangTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiNhanhNganHangTable_XaPhuongTable_XaPhuongId",
                        column: x => x.XaPhuongId,
                        principalTable: "XaPhuongTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChiNhanhNganHangTable",
                columns: new[] { "Id", "DiaChi", "NganHangId", "XaPhuongId" },
                values: new object[,]
                {
                    { 1, "12 đường Lê Trọng Tấn", 1, 1 },
                    { 2, "69 đường Tôn Thất Thuyết", 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiNhanhNganHangTable_NganHangId",
                table: "ChiNhanhNganHangTable",
                column: "NganHangId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiNhanhNganHangTable_XaPhuongId",
                table: "ChiNhanhNganHangTable",
                column: "XaPhuongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiNhanhNganHangTable");
        }
    }
}
