using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addChucDanhTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChucDanhTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChucDanhTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ChucDanhTable",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Giám đốc trung tâm" },
                    { 2, "Phó giám đốc trung tâm" },
                    { 3, "Leader" },
                    { 4, "Nhân viên" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChucDanhTable");
        }
    }
}
