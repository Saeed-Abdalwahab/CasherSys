using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Change5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_itemCategories_categoryID",
                table: "items");

            migrationBuilder.DropIndex(
                name: "IX_items_categoryID",
                table: "items");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "items",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "categoryID",
                table: "items",
                newName: "CategoryID");

            migrationBuilder.AddColumn<int>(
                name: "ItemCategoryID",
                table: "items",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "items",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "items",
                newName: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_items_categoryID",
                table: "items",
                column: "categoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_items_itemCategories_categoryID",
                table: "items",
                column: "categoryID",
                principalTable: "itemCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
