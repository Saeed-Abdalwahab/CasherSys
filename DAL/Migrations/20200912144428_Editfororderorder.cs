using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Editfororderorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderNumberForShift",
                table: "orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "OrderStatus",
                table: "orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "ordersnumberForever",
                table: "orders",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "shiftStatus",
                table: "orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNumberForShift",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "OrderStatus",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ordersnumberForever",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "shiftStatus",
                table: "orders");

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
