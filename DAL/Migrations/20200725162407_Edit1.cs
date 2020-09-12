using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Edit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_items_itemID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_itemID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "Discription",
                table: "items");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "items");

            migrationBuilder.AddColumn<int>(
                name: "ItemDetailsID",
                table: "OrderDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ItemDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Discription = table.Column<string>(nullable: true),
                    ItemID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemDetails_items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "items",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ItemDetailsID",
                table: "OrderDetails",
                column: "ItemDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetails_ItemID",
                table: "ItemDetails",
                column: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ItemDetails_ItemDetailsID",
                table: "OrderDetails",
                column: "ItemDetailsID",
                principalTable: "ItemDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ItemDetails_ItemDetailsID",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ItemDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ItemDetailsID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ItemDetailsID",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "items",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_itemID",
                table: "OrderDetails",
                column: "itemID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_items_itemID",
                table: "OrderDetails",
                column: "itemID",
                principalTable: "items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
