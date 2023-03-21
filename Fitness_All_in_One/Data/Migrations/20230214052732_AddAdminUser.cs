using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_All_in_One.Data.Migrations
{
    public partial class AddAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Age], [Gender], [Height], [Name], [TargetWeight], [Weight]) VALUES (N'0367f24b-7164-4af1-8d8d-2f8a554df9fa', N'patelrutvik074@gmail.com', N'PATELRUTVIK074@GMAIL.COM', N'patelrutvik074@gmail.com', N'PATELRUTVIK074@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAENW359qn6p41LYgBdMiJhHFzaVaiVlzhQNn8wbFJnXKw3ZBAdbOHLEwBKU/89sMLTw==', N'TRLVIAT4BKVNBLUS7676JPKB4RPP44RS', N'35830346-979d-4ba9-b162-8d7ffaa879a8', NULL, 0, 0, NULL, 1, 0, N'23', N'male', N'177', N'Rutvik', N'78', N'68')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Users] Where Id='0367f24b-7164-4af1-8d8d-2f8a554df9fa'");
        }
    }
}
