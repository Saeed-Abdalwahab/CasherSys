using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddloafTpeRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "loafType",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "LoafTypeID",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LoafType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plusCost = table.Column<double>(nullable: true),
                    Name = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoafType", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_LoafTypeID",
                table: "OrderDetails",
                column: "LoafTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_LoafType_LoafTypeID",
                table: "OrderDetails",
                column: "LoafTypeID",
                principalTable: "LoafType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_LoafType_LoafTypeID",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "LoafType");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_LoafTypeID",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "LoafTypeID",
                table: "OrderDetails");

            migrationBuilder.AddColumn<int>(
                name: "loafType",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
