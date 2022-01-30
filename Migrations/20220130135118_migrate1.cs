using Microsoft.EntityFrameworkCore.Migrations;

namespace MotoLand.Migrations
{
    public partial class migrate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotoCategory_Motorcycle_MotorcycleID",
                table: "MotoCategory");

            migrationBuilder.DropColumn(
                name: "MotoID",
                table: "MotoCategory");

            migrationBuilder.AlterColumn<int>(
                name: "MotorcycleID",
                table: "MotoCategory",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MotoCategory_Motorcycle_MotorcycleID",
                table: "MotoCategory",
                column: "MotorcycleID",
                principalTable: "Motorcycle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MotoCategory_Motorcycle_MotorcycleID",
                table: "MotoCategory");

            migrationBuilder.AlterColumn<int>(
                name: "MotorcycleID",
                table: "MotoCategory",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "MotoID",
                table: "MotoCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MotoCategory_Motorcycle_MotorcycleID",
                table: "MotoCategory",
                column: "MotorcycleID",
                principalTable: "Motorcycle",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
