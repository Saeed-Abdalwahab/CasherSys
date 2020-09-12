using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class edit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_LoafType_LoafTypeID",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "LoafTypeID",
                table: "OrderDetails",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_LoafType_LoafTypeID",
                table: "OrderDetails",
                column: "LoafTypeID",
                principalTable: "LoafType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_LoafType_LoafTypeID",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "LoafTypeID",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_LoafType_LoafTypeID",
                table: "OrderDetails",
                column: "LoafTypeID",
                principalTable: "LoafType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
