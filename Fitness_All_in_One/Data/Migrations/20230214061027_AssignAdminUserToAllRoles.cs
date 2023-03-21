using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_All_in_One.Data.Migrations
{
    public partial class AssignAdminUserToAllRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[UserRoles] (UserId, RoleId) SELECT '0367f24b-7164-4af1-8d8d-2f8a554df9fa', Id FROM [security].[Roles] ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[UserRoles] WHERE UserId = '0367f24b-7164-4af1-8d8d-2f8a554df9fa'");
        }
    }
}
