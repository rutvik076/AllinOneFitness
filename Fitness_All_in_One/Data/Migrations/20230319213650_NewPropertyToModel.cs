using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_All_in_One.Data.Migrations
{
    public partial class NewPropertyToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgeRange",
                schema: "security",
                table: "DietPlans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeRange",
                schema: "security",
                table: "DietPlans");
        }
    }
}
