using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addDisciplineAndRewardTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DisciplinaryActionTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ViolationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ViolationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Evidence = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionTakenType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplinaryActionTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplinaryActionTable_EmployeeTable_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RewardTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    RewardDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RewardType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RewardTable_EmployeeTable_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DisciplinaryActionTable",
                columns: new[] { "Id", "ActionTakenType", "Description", "EmployeeId", "Evidence", "Remarks", "ViolationDate", "ViolationType" },
                values: new object[] { 1, "VerbalWarning", "Arrived 30 minutes late", 1, "", "", new DateOnly(2024, 7, 20), "Late" });

         

            migrationBuilder.InsertData(
                table: "RewardTable",
                columns: new[] { "Id", "Description", "EmployeeId", "Reason", "Remarks", "RewardDate", "RewardType" },
                values: new object[] { 1, "$1000 bonus", 1, "Exceed sales target", "", new DateOnly(2024, 7, 24), "Bonus" });

            migrationBuilder.CreateIndex(
                name: "IX_DisciplinaryActionTable_EmployeeId",
                table: "DisciplinaryActionTable",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RewardTable_EmployeeId",
                table: "RewardTable",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DisciplinaryActionTable");

            migrationBuilder.DropTable(
                name: "RewardTable");
        }
    }
}
