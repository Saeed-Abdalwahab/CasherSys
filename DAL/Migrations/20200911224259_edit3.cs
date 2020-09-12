using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class edit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_LoafType_LoafTypeID",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoafType",
                table: "LoafType");

            migrationBuilder.RenameTable(
                name: "LoafType",
                newName: "LoafTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoafTypes",
                table: "LoafTypes",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_LoafTypes_LoafTypeID",
                table: "OrderDetails",
                column: "LoafTypeID",
                principalTable: "LoafTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_LoafTypes_LoafTypeID",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoafTypes",
                table: "LoafTypes");

            migrationBuilder.RenameTable(
                name: "LoafTypes",
                newName: "LoafType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoafType",
                table: "LoafType",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_LoafType_LoafTypeID",
                table: "OrderDetails",
                column: "LoafTypeID",
                principalTable: "LoafType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
