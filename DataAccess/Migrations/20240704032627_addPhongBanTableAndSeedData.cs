using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addPhongBanTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhongBanTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBanTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PhongBanTable",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "C12" },
                    { 2, "C10" },
                    { 3, "C9" },
                    { 4, "C3" },
                    { 5, "C6" },
                    { 6, "DU" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhongBanTable");
        }
    }
}
