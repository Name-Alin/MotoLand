using Microsoft.EntityFrameworkCore.Migrations;

namespace MotoLand.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DealerMoto",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerMoto", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Motorcycle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand = table.Column<string>(maxLength: 30, nullable: false),
                    model = table.Column<string>(maxLength: 20, nullable: false),
                    year = table.Column<int>(nullable: false),
                    price = table.Column<double>(nullable: false),
                    DealerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorcycle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Motorcycle_DealerMoto_DealerID",
                        column: x => x.DealerID,
                        principalTable: "DealerMoto",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MotoCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotoID = table.Column<int>(nullable: false),
                    MotorcycleID = table.Column<int>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotoCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MotoCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MotoCategory_Motorcycle_MotorcycleID",
                        column: x => x.MotorcycleID,
                        principalTable: "Motorcycle",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MotoCategory_CategoryID",
                table: "MotoCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_MotoCategory_MotorcycleID",
                table: "MotoCategory",
                column: "MotorcycleID");

            migrationBuilder.CreateIndex(
                name: "IX_Motorcycle_DealerID",
                table: "Motorcycle",
                column: "DealerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotoCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Motorcycle");

            migrationBuilder.DropTable(
                name: "DealerMoto");
        }
    }
}
