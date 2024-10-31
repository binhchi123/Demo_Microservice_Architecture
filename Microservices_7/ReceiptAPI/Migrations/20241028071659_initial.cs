using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReceiptAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    LoaiNguyenLieuId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TenLoai = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    MoTa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.LoaiNguyenLieuId);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    PhieuThuId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NgayLap = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NhanVienLap = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    GhiChu = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ThanhTien = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.PhieuThuId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    NguyenLieuId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    LoaiNguyenLieuId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TenNguyenLieu = table.Column<string>(type: "NVARCHAR2(20)", maxLength: 20, nullable: false),
                    GiaBan = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DonViTinh = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    SoLuongKho = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.NguyenLieuId);
                    table.ForeignKey(
                        name: "FK_Ingredients_Categories_LoaiNguyenLieuId",
                        column: x => x.LoaiNguyenLieuId,
                        principalTable: "Categories",
                        principalColumn: "LoaiNguyenLieuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptDetails",
                columns: table => new
                {
                    ChiTietPhieuThuId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NguyenLieuId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PhieuThuId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SoLuongBan = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptDetails", x => x.ChiTietPhieuThuId);
                    table.ForeignKey(
                        name: "FK_ReceiptDetails_Ingredients_NguyenLieuId",
                        column: x => x.NguyenLieuId,
                        principalTable: "Ingredients",
                        principalColumn: "NguyenLieuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptDetails_Receipts_PhieuThuId",
                        column: x => x.PhieuThuId,
                        principalTable: "Receipts",
                        principalColumn: "PhieuThuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_LoaiNguyenLieuId",
                table: "Ingredients",
                column: "LoaiNguyenLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDetails_NguyenLieuId",
                table: "ReceiptDetails",
                column: "NguyenLieuId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptDetails_PhieuThuId",
                table: "ReceiptDetails",
                column: "PhieuThuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceiptDetails");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
