using Microsoft.EntityFrameworkCore.Migrations;

namespace SendARaven.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "developer",
                columns: table => new
                {
                    tenantId = table.Column<string>(nullable: false),
                    apiKey = table.Column<string>(maxLength: 128, nullable: false),
                    email = table.Column<string>(maxLength: 128, nullable: false),
                    companyName = table.Column<string>(maxLength: 128, nullable: false),
                    tenantName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_developer", x => x.tenantId);
                });

            migrationBuilder.CreateTable(
                name: "user1",
                columns: table => new
                {
                    userId = table.Column<string>(nullable: false),
                    tenantId = table.Column<string>(nullable: false),
                    attributes = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user1", x => x.userId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "developer");

            migrationBuilder.DropTable(
                name: "user1");
        }
    }
}
