using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_All_in_One.Data.Migrations
{
    public partial class AddNewPropertBMIFood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BMI",
                schema: "security",
                table: "DietPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Food",
                schema: "security",
                table: "DietPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BMI",
                schema: "security",
                table: "DietPlans");

            migrationBuilder.DropColumn(
                name: "Food",
                schema: "security",
                table: "DietPlans");
        }
    }
}
