using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DishAPI.Migrations
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
                    LoaiMonAnId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TenLoai = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.LoaiMonAnId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    NguyenLieuId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TenNguyenLieu = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.NguyenLieuId);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    MonAnId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TenMon = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    GhiChu = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    LoaiMonAnId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.MonAnId);
                    table.ForeignKey(
                        name: "FK_Dishes_Categories_LoaiMonAnId",
                        column: x => x.LoaiMonAnId,
                        principalTable: "Categories",
                        principalColumn: "LoaiMonAnId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    CongThucId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MonAnId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NguyenLieuId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SoLuong = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DonViTinh = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.CongThucId);
                    table.ForeignKey(
                        name: "FK_Recipes_Dishes_MonAnId",
                        column: x => x.MonAnId,
                        principalTable: "Dishes",
                        principalColumn: "MonAnId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipes_Ingredients_NguyenLieuId",
                        column: x => x.NguyenLieuId,
                        principalTable: "Ingredients",
                        principalColumn: "NguyenLieuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_LoaiMonAnId",
                table: "Dishes",
                column: "LoaiMonAnId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MonAnId",
                table: "Recipes",
                column: "MonAnId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_NguyenLieuId",
                table: "Recipes",
                column: "NguyenLieuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
