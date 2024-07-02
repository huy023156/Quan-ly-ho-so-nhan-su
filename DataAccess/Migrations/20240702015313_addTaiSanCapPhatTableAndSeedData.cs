using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addTaiSanCapPhatTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaiSanCapPhatTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiSanCapPhatTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TaiSanCapPhatTable",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Máy tính" },
                    { 2, "Chuột" },
                    { 3, "Bàn phím" },
                    { 4, "Ổ cứng" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaiSanCapPhatTable");
        }
    }
}
