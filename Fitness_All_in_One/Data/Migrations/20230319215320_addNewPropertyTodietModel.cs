using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_All_in_One.Data.Migrations
{
    public partial class addNewPropertyTodietModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeightRange",
                schema: "security",
                table: "DietPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WeightRange",
                schema: "security",
                table: "DietPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeightRange",
                schema: "security",
                table: "DietPlans");

            migrationBuilder.DropColumn(
                name: "WeightRange",
                schema: "security",
                table: "DietPlans");
        }
    }
}
