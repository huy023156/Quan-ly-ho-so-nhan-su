using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addNhanVienHoSoLuongHopDongTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiaChiDetails",
                table: "ChiNhanhNganHangTable",
                newName: "DiaChiDetail");

            migrationBuilder.CreateTable(
                name: "EmployeeTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChiNhanhNganHangId = table.Column<int>(type: "int", nullable: false),
                    PhongBanId = table.Column<int>(type: "int", nullable: false),
                    ChucDanhId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTable_ChiNhanhNganHangTable_ChiNhanhNganHangId",
                        column: x => x.ChiNhanhNganHangId,
                        principalTable: "ChiNhanhNganHangTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeTable_ChucDanhTable_ChucDanhId",
                        column: x => x.ChucDanhId,
                        principalTable: "ChucDanhTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeTable_PhongBanTable_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBanTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "QuyetDinhTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyetDinhTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HoSoLuongTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BacLuong = table.Column<float>(type: "real", nullable: false),
                    LuongCoBan = table.Column<int>(type: "int", nullable: false),
                    RanhLuongMin = table.Column<int>(type: "int", nullable: false),
                    RanhLuongMax = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoLuongTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoLuongTable_EmployeeTable_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuyetDinhDetailTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuyetDinhId = table.Column<int>(type: "int", nullable: false),
                    NgayQuyetDinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHieuLuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHetHieuLuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyetDinhDetailTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyetDinhDetailTable_QuyetDinhTable_QuyetDinhId",
                        column: x => x.QuyetDinhId,
                        principalTable: "QuyetDinhTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoSoLuongCheDoPhucLoiTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheDoPhucLoiId = table.Column<int>(type: "int", nullable: false),
                    HoSoLuongId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoLuongCheDoPhucLoiTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoLuongCheDoPhucLoiTable_CheDoPhucLoiTable_CheDoPhucLoiId",
                        column: x => x.CheDoPhucLoiId,
                        principalTable: "CheDoPhucLoiTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HoSoLuongCheDoPhucLoiTable_HoSoLuongTable_HoSoLuongId",
                        column: x => x.HoSoLuongId,
                        principalTable: "HoSoLuongTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoSoLuongPhuCapTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhuCapId = table.Column<int>(type: "int", nullable: false),
                    HoSoLuongId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoLuongPhuCapTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoSoLuongPhuCapTable_HoSoLuongTable_HoSoLuongId",
                        column: x => x.HoSoLuongId,
                        principalTable: "HoSoLuongTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoSoLuongPhuCapTable_PhuCapTable_PhuCapId",
                        column: x => x.PhuCapId,
                        principalTable: "PhuCapTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "HopDongDetailTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HopDongId = table.Column<int>(type: "int", nullable: false),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    QuyetDinhDetailId = table.Column<int>(type: "int", nullable: false),
                    HoSoLuongId = table.Column<int>(type: "int", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongDetailTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDongDetailTable_EmployeeTable_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HopDongDetailTable_HoSoLuongTable_HoSoLuongId",
                        column: x => x.HoSoLuongId,
                        principalTable: "HoSoLuongTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HopDongDetailTable_HopDongTable_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDongTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_HopDongDetailTable_QuyetDinhDetailTable_QuyetDinhDetailId",
                        column: x => x.QuyetDinhDetailId,
                        principalTable: "QuyetDinhDetailTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "EmployeeTable",
                columns: new[] { "Id", "ChiNhanhNganHangId", "ChucDanhId", "DateOfBirth", "Email", "Gender", "Name", "NgayTao", "NgayUpdate", "NguoiTao", "NguoiUpdate", "PhoneNumber", "PhongBanId" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2003, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "huy023156@gmail.com", true, "Nguyen Quang Huy", new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1459), null, "Admin", null, "0369694076", 1 },
                    { 2, 2, 2, new DateTime(2002, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "miaf@mai.com", false, "Nguyen Phuong Mai", new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1472), null, "Admin", null, "0123485682", 2 }
                });

            migrationBuilder.InsertData(
                table: "QuyetDinhTable",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Quyết định tuyển dụng" },
                    { 2, "Quyết định đuổi việc" },
                    { 3, "Quyết định thăng chức" }
                });

            migrationBuilder.InsertData(
                table: "HoSoLuongTable",
                columns: new[] { "Id", "BacLuong", "EmployeeId", "LuongCoBan", "NgayTao", "NgayUpdate", "NguoiTao", "NguoiUpdate", "RanhLuongMax", "RanhLuongMin" },
                values: new object[,]
                {
                    { 1, 4.3f, 1, 20000, new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1503), null, "Admin", null, 150000, 70000 },
                    { 2, 3.9f, 2, 16000, new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1505), null, "Admin", null, 100000, 50000 }
                });

            migrationBuilder.InsertData(
                table: "QuyetDinhDetailTable",
                columns: new[] { "Id", "NgayHetHieuLuc", "NgayHieuLuc", "NgayQuyetDinh", "NgayTao", "NgayUpdate", "NguoiTao", "NguoiUpdate", "NoiDung", "QuyetDinhId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1602), null, "Admin", null, "Tuyển dụng anh Huy vào vị trí Giám đốc", 1 },
                    { 2, new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1604), null, "Admin", null, "Tuyển dụng chị Mai vào vị trí Phó giám đốc", 1 }
                });

            migrationBuilder.InsertData(
                table: "HoSoLuongCheDoPhucLoiTable",
                columns: new[] { "Id", "Amount", "CheDoPhucLoiId", "HoSoLuongId" },
                values: new object[,]
                {
                    { 1, 500, 1, 1 },
                    { 2, 300, 2, 1 },
                    { 3, 450, 1, 1 },
                    { 4, 1500, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "HoSoLuongPhuCapTable",
                columns: new[] { "Id", "Amount", "HoSoLuongId", "PhuCapId" },
                values: new object[,]
                {
                    { 1, 100, 1, 1 },
                    { 2, 10, 1, 3 },
                    { 3, 30, 1, 4 },
                    { 4, 80, 2, 1 },
                    { 5, 7, 2, 3 },
                    { 6, 25, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "HopDongDetailTable",
                columns: new[] { "Id", "EmployeeId", "HoSoLuongId", "HopDongId", "NgayBatDau", "NgayKetThuc", "NgayTao", "NgayUpdate", "NguoiTao", "NguoiUpdate", "QuyetDinhDetailId" },
                values: new object[,]
                {
                    { 1, 1, 1, 6, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1638), null, "Admin", null, 1 },
                    { 2, 2, 2, 6, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 11, 10, 16, 5, 808, DateTimeKind.Local).AddTicks(1640), null, "Admin", null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTable_ChiNhanhNganHangId",
                table: "EmployeeTable",
                column: "ChiNhanhNganHangId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTable_ChucDanhId",
                table: "EmployeeTable",
                column: "ChucDanhId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTable_PhongBanId",
                table: "EmployeeTable",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongDetailTable_EmployeeId",
                table: "HopDongDetailTable",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongDetailTable_HopDongId",
                table: "HopDongDetailTable",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongDetailTable_HoSoLuongId",
                table: "HopDongDetailTable",
                column: "HoSoLuongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDongDetailTable_QuyetDinhDetailId",
                table: "HopDongDetailTable",
                column: "QuyetDinhDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoLuongCheDoPhucLoiTable_CheDoPhucLoiId",
                table: "HoSoLuongCheDoPhucLoiTable",
                column: "CheDoPhucLoiId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoLuongCheDoPhucLoiTable_HoSoLuongId",
                table: "HoSoLuongCheDoPhucLoiTable",
                column: "HoSoLuongId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoLuongPhuCapTable_HoSoLuongId",
                table: "HoSoLuongPhuCapTable",
                column: "HoSoLuongId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoLuongPhuCapTable_PhuCapId",
                table: "HoSoLuongPhuCapTable",
                column: "PhuCapId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoLuongTable_EmployeeId",
                table: "HoSoLuongTable",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinhDetailTable_QuyetDinhId",
                table: "QuyetDinhDetailTable",
                column: "QuyetDinhId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HopDongDetailTable");

            migrationBuilder.DropTable(
                name: "HoSoLuongCheDoPhucLoiTable");

            migrationBuilder.DropTable(
                name: "HoSoLuongPhuCapTable");

            migrationBuilder.DropTable(
                name: "QuyetDinhDetailTable");

            migrationBuilder.DropTable(
                name: "HoSoLuongTable");

            migrationBuilder.DropTable(
                name: "QuyetDinhTable");

            migrationBuilder.DropTable(
                name: "EmployeeTable");

            migrationBuilder.RenameColumn(
                name: "DiaChiDetail",
                table: "ChiNhanhNganHangTable",
                newName: "DiaChiDetails");
        }
    }
}
