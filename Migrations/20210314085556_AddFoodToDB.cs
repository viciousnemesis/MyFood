using Microsoft.EntityFrameworkCore.Migrations;

namespace MyFood.Migrations
{
    public partial class AddFoodToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    ServingSize = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Carb = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Protein = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Fat = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foods");
        }
    }
}
