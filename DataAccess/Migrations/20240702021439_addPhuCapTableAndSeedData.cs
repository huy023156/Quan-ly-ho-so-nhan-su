using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addPhuCapTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhuCapTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuCapTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PhuCapTable",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bảo hiểm y tế" },
                    { 2, "Bảo hiểm xã hội" },
                    { 3, "Bảo hiểm thất nghiệp" },
                    { 4, "Bảo hiểm tai nạn lao động, bệnh nghề nghiệp" },
                    { 5, "Hưu trí" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhuCapTable");
        }
    }
}
