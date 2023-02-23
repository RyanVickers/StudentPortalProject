using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortalProject.Data.Migrations
{
    public partial class GroupMember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupMembers",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMembers", x => new { x.GroupId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_GroupMembers_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_GroupMembers_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_StudentId",
                table: "GroupMembers",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupMembers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "a4899d28-43f9-44e7-a8bd-679dd5283635");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "d76ec9bb-83b9-4faf-b848-48a9937812b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "21f86164-e73a-4ebb-b4c3-466994c3ad4d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a32280d8-e832-4557-aede-d64ebdbccbd2", "AQAAAAEAACcQAAAAEEHyCqsKjpyRPFj+VFu5Jq0Xu3NzpIMEqaqhJoSyyhT2OJyxdyGq8HO2qoopYURR+Q==", "528837c0-deae-4c7e-9a32-6b08b60022b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98eb9726-47fc-454d-bdea-01bfaa60cddf", "AQAAAAEAACcQAAAAEG2gifLyCNE0DQG5A7QwE9ofcgLa8dm5WNcuHFX15VXNjENNgecc2KD+2ffL/WX57A==", "14a75c7c-4831-4a4c-a320-e36011ddf800" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6aacde1a-fa49-48b7-a592-edc54d760d19", "AQAAAAEAACcQAAAAEIn+NeGgKfZSOhnMXJUwCtlp2EPdInpg9gD7AGtH/GEiBhb8RfzKrt6qwtJlGlqaCQ==", "02c419fe-8dc4-4301-a739-ad1055f82fd5" });
        }
    }
}
