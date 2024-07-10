using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addNoiKhamChuaBenhTableAndSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoiKhamChuaBenhTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiDetail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiaChiId = table.Column<int>(type: "int", nullable: false),
                    IsApplied = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoiKhamChuaBenhTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoiKhamChuaBenhTable_DiaChiTable_DiaChiId",
                        column: x => x.DiaChiId,
                        principalTable: "DiaChiTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "NoiKhamChuaBenhTable",
                columns: new[] { "Id", "DiaChiDetail", "DiaChiId", "IsApplied", "Name" },
                values: new object[] { 1, "18 Hoang Son", 8, true, "Phong kham Tre Viet" });

            migrationBuilder.CreateIndex(
                name: "IX_NoiKhamChuaBenhTable_DiaChiId",
                table: "NoiKhamChuaBenhTable",
                column: "DiaChiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoiKhamChuaBenhTable");
        }
    }
}
