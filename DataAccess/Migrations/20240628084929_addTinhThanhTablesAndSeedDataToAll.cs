using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addTinhThanhTablesAndSeedDataToAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuocGiaTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuocGiaTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TinhThanhTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuocGiaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinhThanhTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TinhThanhTable_QuocGiaTable_QuocGiaId",
                        column: x => x.QuocGiaId,
                        principalTable: "QuocGiaTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuanHuyenTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TinhThanhId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanHuyenTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuanHuyenTable_TinhThanhTable_TinhThanhId",
                        column: x => x.TinhThanhId,
                        principalTable: "TinhThanhTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XaPhuongTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuanHuyenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XaPhuongTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XaPhuongTable_QuanHuyenTable_QuanHuyenId",
                        column: x => x.QuanHuyenId,
                        principalTable: "QuanHuyenTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "QuocGiaTable",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Việt Nam" },
                    { 2, "Nhật Bản" },
                    { 3, "Hoa Kỳ" }
                });

            migrationBuilder.InsertData(
                table: "TinhThanhTable",
                columns: new[] { "Id", "Name", "QuocGiaId" },
                values: new object[,]
                {
                    { 1, "Hà Nội", 1 },
                    { 2, "Thành phố Hồ Chí Minh", 1 },
                    { 3, "Đà Nẵng", 1 },
                    { 4, "Tokyo", 2 }
                });

            migrationBuilder.InsertData(
                table: "QuanHuyenTable",
                columns: new[] { "Id", "Name", "TinhThanhId" },
                values: new object[,]
                {
                    { 1, "Hà Đông", 1 },
                    { 2, "Đống Đa", 1 },
                    { 3, "Hoàng Mai", 1 },
                    { 4, "Cầu Giấy", 1 },
                    { 5, "Ba Đình", 1 },
                    { 6, "Quận 1", 2 }
                });

            migrationBuilder.InsertData(
                table: "XaPhuongTable",
                columns: new[] { "Id", "Name", "QuanHuyenId" },
                values: new object[,]
                {
                    { 1, "La Khê", 1 },
                    { 2, "Khâm Thiên", 2 },
                    { 3, "Phương Liệt", 3 },
                    { 4, "Dịch Vọng", 4 },
                    { 5, "Mỹ Khê", 5 },
                    { 6, "Tân Định", 6 },
                    { 7, "Yên Hòa", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyenTable_TinhThanhId",
                table: "QuanHuyenTable",
                column: "TinhThanhId");

            migrationBuilder.CreateIndex(
                name: "IX_TinhThanhTable_QuocGiaId",
                table: "TinhThanhTable",
                column: "QuocGiaId");

            migrationBuilder.CreateIndex(
                name: "IX_XaPhuongTable_QuanHuyenId",
                table: "XaPhuongTable",
                column: "QuanHuyenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "XaPhuongTable");

            migrationBuilder.DropTable(
                name: "QuanHuyenTable");

            migrationBuilder.DropTable(
                name: "TinhThanhTable");

            migrationBuilder.DropTable(
                name: "QuocGiaTable");
        }
    }
}
