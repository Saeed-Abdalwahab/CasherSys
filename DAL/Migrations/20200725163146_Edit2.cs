using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Edit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ItemDetails_ItemDetailsID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "coast",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "itemID",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "discount",
                table: "orders",
                newName: "Discount");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "orders",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "ItemDetailsID",
                table: "OrderDetails",
                newName: "itemDetailsID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ItemDetailsID",
                table: "OrderDetails",
                newName: "IX_OrderDetails_itemDetailsID");

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TotalCoast",
                table: "orders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "itemDetailsID",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails",
                column: "OrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_orders_OrderID",
                table: "OrderDetails",
                column: "OrderID",
                principalTable: "orders",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ItemDetails_itemDetailsID",
                table: "OrderDetails",
                column: "itemDetailsID",
                principalTable: "ItemDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_orders_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_ItemDetails_itemDetailsID",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "TotalCoast",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "orders",
                newName: "discount");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "orders",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "itemDetailsID",
                table: "OrderDetails",
                newName: "ItemDetailsID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_itemDetailsID",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ItemDetailsID");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "coast",
                table: "orders",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "ItemDetailsID",
                table: "OrderDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "itemID",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_ItemDetails_ItemDetailsID",
                table: "OrderDetails",
                column: "ItemDetailsID",
                principalTable: "ItemDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
