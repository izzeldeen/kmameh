using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class IntialCreateOrderTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    BuyerEmail = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTimeOffset>(nullable: false),
                    ShippingPrice = table.Column<decimal>(nullable: false),
                    Subtotal = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    PaymenIntId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductItemOrder",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ProductIntId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(nullable: true),
                    PictuerUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItemOrder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    ItemOrderedID = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Quntity = table.Column<int>(nullable: false),
                    OrderID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderItems_ProductItemOrder_ItemOrderedID",
                        column: x => x.ItemOrderedID,
                        principalTable: "ProductItemOrder",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemOrderedID",
                table: "OrderItems",
                column: "ItemOrderedID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItems",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductItemOrder");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
