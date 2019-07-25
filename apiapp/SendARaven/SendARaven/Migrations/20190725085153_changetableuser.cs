using Microsoft.EntityFrameworkCore.Migrations;

namespace SendARaven.Migrations
{
    public partial class changetableuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user1",
                table: "user1");

            migrationBuilder.RenameTable(
                name: "user1",
                newName: "user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "user1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user1",
                table: "user1",
                column: "userId");
        }
    }
}
