using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "itemCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(nullable: false),
                    coast = table.Column<double>(nullable: false),
                    discount = table.Column<double>(nullable: true),
                    MyProperty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Discription = table.Column<string>(nullable: true),
                    categoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_items_itemCategories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "itemCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    itemID = table.Column<int>(nullable: false),
                    count = table.Column<int>(nullable: false),
                    totalPrice = table.Column<double>(nullable: false),
                    notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_items_itemID",
                        column: x => x.itemID,
                        principalTable: "items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_items_categoryID",
                table: "items",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_itemID",
                table: "OrderDetails",
                column: "itemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "itemCategories");
        }
    }
}
