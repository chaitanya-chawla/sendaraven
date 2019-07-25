using Microsoft.EntityFrameworkCore.Migrations;

namespace SendARaven.Migrations
{
    public partial class tablesupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "channelConfig",
                table: "channel_entity",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserChannelInformations",
                columns: table => new
                {
                    userId = table.Column<string>(nullable: false),
                    tenantId = table.Column<string>(nullable: false),
                    channelType = table.Column<int>(nullable: false),
                    userChannelId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChannelInformations", x => new { x.tenantId, x.userId, x.channelType });
                });

            migrationBuilder.InsertData(
                table: "UserChannelInformations",
                columns: new[] { "tenantId", "userId", "channelType", "userChannelId" },
                values: new object[,]
                {
                    { "tenant_1", "user_1", 1, "chaitanyachawla1996@gmail.com" },
                    { "tenant_1", "user_1", 0, "9717795767" },
                    { "tenant_1", "user_2", 1, "ashima.wadha.1996@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "channel_entity",
                keyColumns: new[] { "tenantId", "channelName" },
                keyValues: new object[] { "tenant_1", "mail" },
                column: "channelConfig",
                value: "{\"senderId\":\"test@example.com\",\"apiKey\":\"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\"}");

            migrationBuilder.UpdateData(
                table: "channel_entity",
                keyColumns: new[] { "tenantId", "channelName" },
                keyValues: new object[] { "tenant_1", "sms-t" },
                column: "channelConfig",
                value: "{\"senderId\":\"TestId\",\"apiKey\":\"286355ArYeDDLx4EFP5d367ce1\"}");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserChannelInformations");

            migrationBuilder.DropColumn(
                name: "channelConfig",
                table: "channel_entity");
        }
    }
}
