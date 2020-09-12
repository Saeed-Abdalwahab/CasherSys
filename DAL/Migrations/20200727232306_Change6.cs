using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Change6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_itemCategories_ItemCategoryID",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_ItemCategoryID",
                table: "items");

            migrationBuilder.DropColumn(
                name: "ItemCategoryID",
                table: "items");

            migrationBuilder.CreateIndex(
                name: "IX_items_CategoryID",
                table: "items",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_items_itemCategories_CategoryID",
                table: "items",
                column: "CategoryID",
                principalTable: "itemCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_itemCategories_CategoryID",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_CategoryID",
                table: "items");

            migrationBuilder.AddColumn<int>(
                name: "ItemCategoryID",
                table: "items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_items_ItemCategoryID",
                table: "items",
                column: "ItemCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_items_itemCategories_ItemCategoryID",
                table: "items",
                column: "ItemCategoryID",
                principalTable: "itemCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
