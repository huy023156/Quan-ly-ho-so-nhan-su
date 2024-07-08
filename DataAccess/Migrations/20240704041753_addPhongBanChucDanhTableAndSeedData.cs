using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addPhongBanChucDanhTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhongBanChucDanhTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhongBanId = table.Column<int>(type: "int", nullable: false),
                    ChucDanhId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBanChucDanhTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhongBanChucDanhTable_ChucDanhTable_ChucDanhId",
                        column: x => x.ChucDanhId,
                        principalTable: "ChucDanhTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhongBanChucDanhTable_PhongBanTable_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBanTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PhongBanChucDanhTable",
                columns: new[] { "Id", "ChucDanhId", "PhongBanId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 1 },
                    { 5, 1, 2 },
                    { 6, 2, 2 },
                    { 7, 3, 2 },
                    { 8, 4, 2 },
                    { 9, 1, 3 },
                    { 10, 2, 3 },
                    { 11, 3, 3 },
                    { 12, 4, 3 },
                    { 13, 1, 4 },
                    { 14, 2, 4 },
                    { 15, 3, 4 },
                    { 16, 4, 4 },
                    { 17, 1, 5 },
                    { 18, 2, 5 },
                    { 19, 3, 5 },
                    { 20, 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhongBanChucDanhTable_ChucDanhId",
                table: "PhongBanChucDanhTable",
                column: "ChucDanhId");

            migrationBuilder.CreateIndex(
                name: "IX_PhongBanChucDanhTable_PhongBanId",
                table: "PhongBanChucDanhTable",
                column: "PhongBanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhongBanChucDanhTable");
        }
    }
}
