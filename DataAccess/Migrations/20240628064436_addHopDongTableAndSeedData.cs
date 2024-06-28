using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addHopDongTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HopDongTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "HopDongTable",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Hợp đồng đào tạo" },
                    { 2, "Hợp đồng học viên" },
                    { 3, "Hợp đồng thử việc" },
                    { 4, "Hợp đồng chính thức" },
                    { 5, "Hợp đồng cộng tác viên" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HopDongTable");
        }
    }
}
