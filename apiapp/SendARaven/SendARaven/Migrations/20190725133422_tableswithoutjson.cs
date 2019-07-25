using Microsoft.EntityFrameworkCore.Migrations;

namespace SendARaven.Migrations
{
    public partial class tableswithoutjson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_myuser",
                table: "myuser");

            migrationBuilder.DropColumn(
                name: "tenantName",
                table: "developer");

            migrationBuilder.AlterColumn<string>(
                name: "tenantId",
                table: "myuser",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_myuser",
                table: "myuser",
                columns: new[] { "tenantId", "userId" });

            migrationBuilder.CreateTable(
                name: "channel_entity",
                columns: table => new
                {
                    tenantId = table.Column<string>(maxLength: 128, nullable: false),
                    channelName = table.Column<string>(maxLength: 128, nullable: false),
                    channelType = table.Column<int>(nullable: false),
                    templateId = table.Column<string>(maxLength: 128, nullable: true),
                    channelProvider = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_channel_entity", x => new { x.tenantId, x.channelName });
                });

            migrationBuilder.InsertData(
                table: "channel_entity",
                columns: new[] { "tenantId", "channelName", "channelProvider", "channelType", "status", "templateId" },
                values: new object[,]
                {
                    { "tenant_1", "mail", 0, 1, 1, "mail_sendgrid" },
                    { "tenant_1", "sms-t", 1, 0, 1, "sms_msg91" }
                });

            migrationBuilder.InsertData(
                table: "developer",
                columns: new[] { "tenantId", "apiKey", "companyName", "email" },
                values: new object[] { "tenant_1", "key_1", "Microsoft", "chaitanyachawla@yahoo.co.in" });

            migrationBuilder.InsertData(
                table: "myuser",
                columns: new[] { "tenantId", "userId", "attributes" },
                values: new object[,]
                {
                    { "tenant_1", "user_1", "{\"City\":\"Bangalore\"}" },
                    { "tenant_1", "user_2", "{\"City\":\"Bangalore\"}" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "channel_entity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_myuser",
                table: "myuser");

            migrationBuilder.DeleteData(
                table: "developer",
                keyColumn: "tenantId",
                keyValue: "tenant_1");

            migrationBuilder.DeleteData(
                table: "myuser",
                keyColumns: new[] { "tenantId", "userId" },
                keyValues: new object[] { "tenant_1", "user_1" });

            migrationBuilder.DeleteData(
                table: "myuser",
                keyColumns: new[] { "tenantId", "userId" },
                keyValues: new object[] { "tenant_1", "user_2" });

            migrationBuilder.AlterColumn<string>(
                name: "tenantId",
                table: "myuser",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "tenantName",
                table: "developer",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_myuser",
                table: "myuser",
                column: "userId");
        }
    }
}
