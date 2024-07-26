using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addResignationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResignationTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IdentityUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResignationTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResignationTable_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResignationTable_EmployeeTable_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.InsertData(
                table: "ResignationTable",
                columns: new[] { "Id", "CreatedDate", "EmployeeId", "IdentityUserId", "Reason", "UpdatedDate" },
                values: new object[] { 1, new DateOnly(2024, 7, 25), 3, "70a0e26c-99c7-4d9a-9061-fe76029d4893", "Khong muon lam", null });

            migrationBuilder.CreateIndex(
                name: "IX_ResignationTable_EmployeeId",
                table: "ResignationTable",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResignationTable_IdentityUserId",
                table: "ResignationTable",
                column: "IdentityUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResignationTable");
        }
    }
}
