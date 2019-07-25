using Microsoft.EntityFrameworkCore.Migrations;

namespace SendARaven.Migrations
{
    public partial class tablesupdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChannelInformations",
                table: "UserChannelInformations");

            migrationBuilder.RenameTable(
                name: "UserChannelInformations",
                newName: "userchannelinfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userchannelinfo",
                table: "userchannelinfo",
                columns: new[] { "tenantId", "userId", "channelType" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userchannelinfo",
                table: "userchannelinfo");

            migrationBuilder.RenameTable(
                name: "userchannelinfo",
                newName: "UserChannelInformations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChannelInformations",
                table: "UserChannelInformations",
                columns: new[] { "tenantId", "userId", "channelType" });
        }
    }
}
