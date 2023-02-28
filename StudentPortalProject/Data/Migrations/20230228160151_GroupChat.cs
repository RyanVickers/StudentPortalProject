using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortalProject.Data.Migrations
{
    public partial class GroupChat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    AddedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "ab1f43fc-37b0-419b-8ea4-4b25042b484e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "0045c365-6df7-4d88-bcf3-c195d38af32b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "a848d2cd-4b69-4ef2-8288-ed8502ae0415");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8237a142-adab-4f10-b39d-e8f9e194b235", "AQAAAAEAACcQAAAAEEEDsJ99lsjsddrKUDxj0J9w2YcCy8dWjWlmeX4oVS5k0A3QTHLRPtzIZSrCiAOJTw==", "e7d1006a-d35c-4049-ba5a-a9f67968d737" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a7cdbd5-632a-4bae-8d05-38b1cb168081", "AQAAAAEAACcQAAAAEECi6Z7ovsU84gmgj1Q+cDg0abjJdZLMl21p/jhwe/Hx6wOraAB+Jt3bN1vR9HTB4A==", "323fd0f2-a7e0-49e7-afa3-2ef317154654" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e020aafc-d15c-4462-9524-95b1456787c6", "AQAAAAEAACcQAAAAEL9AbwW+oNjeGBNysn03QaNz1UUVhwZjZvWefqaZR7C8Y/D9jgWHhdSUXVtXLcJO9g==", "7500b387-d0c7-4b8b-b637-49d0502eec82" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "abf9a2c3-623c-4447-b737-b1cf5ab88904");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d595b4cc-ffe5-4e04-8d64-940a14d7d39b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "c3968de4-17a4-4a86-b677-f1c5855f82ab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "848d8828-c7ef-43dc-927a-46a8387a81ff", "AQAAAAEAACcQAAAAEIHYGRfE0XG7zMrLxt6Ed/GIKZQgEiAP1tCxDXDyqJHJ+F/O7z84QEbhDKbrvra41A==", "b04d131d-a0b5-425a-96cb-fa5bd7eab795" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe6e1ab0-8246-4929-9009-e04438b7e0b2", "AQAAAAEAACcQAAAAEA6bt/qYOkuDAhmyYJjchFfCRtI5Glc5QQmDz3coZdmAm2UImCke+LgVgivsxN+kbA==", "25a4bf7e-8731-47b9-8069-67287adad345" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d8f287b1-34ad-4b9b-aca4-18f7ef9158df", "AQAAAAEAACcQAAAAEAYLzgudHsnGgr3AvRhuCjeR744uwF9R9BLTSsGaEF7YJ30zefELA3IJ7ZCCzuJHWA==", "f1cf7788-3610-4c5b-9e21-00f07fa6d861" });
        }
    }
}
