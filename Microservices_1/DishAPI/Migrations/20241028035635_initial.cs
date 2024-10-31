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
            migrationBuilder.EnsureSchema(
                name: "TEST1");

            migrationBuilder.CreateTable(
                name: "CATEGORIES",
                schema: "TEST1",
                columns: table => new
                {
                    LOAIMONANID = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TENLOAI = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C007786", x => x.LOAIMONANID);
                });

            migrationBuilder.CreateTable(
                name: "INGREDIENTS",
                schema: "TEST1",
                columns: table => new
                {
                    NGUYENLIEUID = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TENNGUYENLIEU = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C007788", x => x.NGUYENLIEUID);
                });

            migrationBuilder.CreateTable(
                name: "DISHES",
                schema: "TEST1",
                columns: table => new
                {
                    MONANID = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TENMON = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: false),
                    GHICHU = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: true),
                    LOAIMONANID = table.Column<decimal>(type: "NUMBER(38)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C007790", x => x.MONANID);
                    table.ForeignKey(
                        name: "SYS_C007791",
                        column: x => x.LOAIMONANID,
                        principalSchema: "TEST1",
                        principalTable: "CATEGORIES",
                        principalColumn: "LOAIMONANID");
                });

            migrationBuilder.CreateTable(
                name: "RECIPES",
                schema: "TEST1",
                columns: table => new
                {
                    CONGTHUCID = table.Column<decimal>(type: "NUMBER(38)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MONANID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    NGUYENLIEUID = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    SOLUONG = table.Column<decimal>(type: "NUMBER(38)", nullable: false),
                    DONVITINH = table.Column<string>(type: "VARCHAR2(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("SYS_C007793", x => x.CONGTHUCID);
                    table.ForeignKey(
                        name: "SYS_C007794",
                        column: x => x.MONANID,
                        principalSchema: "TEST1",
                        principalTable: "DISHES",
                        principalColumn: "MONANID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "SYS_C007795",
                        column: x => x.NGUYENLIEUID,
                        principalSchema: "TEST1",
                        principalTable: "INGREDIENTS",
                        principalColumn: "NGUYENLIEUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DISHES_LOAIMONANID",
                schema: "TEST1",
                table: "DISHES",
                column: "LOAIMONANID");

            migrationBuilder.CreateIndex(
                name: "IX_RECIPES_MONANID",
                schema: "TEST1",
                table: "RECIPES",
                column: "MONANID");

            migrationBuilder.CreateIndex(
                name: "IX_RECIPES_NGUYENLIEUID",
                schema: "TEST1",
                table: "RECIPES",
                column: "NGUYENLIEUID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RECIPES",
                schema: "TEST1");

            migrationBuilder.DropTable(
                name: "DISHES",
                schema: "TEST1");

            migrationBuilder.DropTable(
                name: "INGREDIENTS",
                schema: "TEST1");

            migrationBuilder.DropTable(
                name: "CATEGORIES",
                schema: "TEST1");
        }
    }
}
