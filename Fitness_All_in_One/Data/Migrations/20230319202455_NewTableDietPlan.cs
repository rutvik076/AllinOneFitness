using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_All_in_One.Data.Migrations
{
    public partial class NewTableDietPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DietPlans",
                schema: "security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DietName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartAge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndAge = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartWeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartHeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndHeight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietPlans", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietPlans",
                schema: "security");
        }
    }
}
