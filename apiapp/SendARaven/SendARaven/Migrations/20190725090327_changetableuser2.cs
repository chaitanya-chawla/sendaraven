using Microsoft.EntityFrameworkCore.Migrations;

namespace SendARaven.Migrations
{
    public partial class changetableuser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "myuser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_myuser",
                table: "myuser",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_myuser",
                table: "myuser");

            migrationBuilder.RenameTable(
                name: "myuser",
                newName: "user");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "userId");
        }
    }
}
