using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Srs.Migrations
{
    /// <inheritdoc />
    public partial class SecondSchema3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GoodId",
                table: "Orders",
                column: "GoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Goods_GoodId",
                table: "Orders",
                column: "GoodId",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Goods_GoodId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_GoodId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "GoodOrder",
                columns: table => new
                {
                    GoodsId = table.Column<int>(type: "int", nullable: false),
                    OrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodOrder", x => new { x.GoodsId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_GoodOrder_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GoodOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoodOrder_OrdersId",
                table: "GoodOrder",
                column: "OrdersId");
        }
    }
}
