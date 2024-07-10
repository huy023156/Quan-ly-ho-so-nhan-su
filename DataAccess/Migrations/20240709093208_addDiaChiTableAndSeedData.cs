using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addDiaChiTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaChiTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuocGiaId = table.Column<int>(type: "int", nullable: false),
                    TinhThanhId = table.Column<int>(type: "int", nullable: false),
                    QuanHuyenId = table.Column<int>(type: "int", nullable: false),
                    XaPhuongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaChiTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaChiTable_QuanHuyenTable_QuanHuyenId",
                        column: x => x.QuanHuyenId,
                        principalTable: "QuanHuyenTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DiaChiTable_QuocGiaTable_QuocGiaId",
                        column: x => x.QuocGiaId,
                        principalTable: "QuocGiaTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DiaChiTable_TinhThanhTable_TinhThanhId",
                        column: x => x.TinhThanhId,
                        principalTable: "TinhThanhTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DiaChiTable_XaPhuongTable_XaPhuongId",
                        column: x => x.XaPhuongId,
                        principalTable: "XaPhuongTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "DiaChiTable",
                columns: new[] { "Id", "QuanHuyenId", "QuocGiaId", "TinhThanhId", "XaPhuongId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1 },
                    { 2, 2, 1, 1, 2 },
                    { 3, 3, 1, 1, 3 },
                    { 4, 4, 1, 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiaChiTable_QuanHuyenId",
                table: "DiaChiTable",
                column: "QuanHuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaChiTable_QuocGiaId",
                table: "DiaChiTable",
                column: "QuocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaChiTable_TinhThanhId",
                table: "DiaChiTable",
                column: "TinhThanhId");

            migrationBuilder.CreateIndex(
                name: "IX_DiaChiTable_XaPhuongId",
                table: "DiaChiTable",
                column: "XaPhuongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaChiTable");
        }
    }
}
