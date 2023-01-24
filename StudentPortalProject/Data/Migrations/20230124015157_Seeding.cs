using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortalProject.Data.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "612c8894-302c-434c-9e91-de9437d6c709", "Student", "STUDENT" },
                    { "2", "95c17dee-ecd6-465a-9688-e2f97f94f13f", "Teacher", "TEACHER" },
                    { "3", "ef14cebf-2782-4991-a658-19296cdf8ba7", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "a6195214-3018-464d-aa35-eb166829ccb4", "student@test.com", true, "Student", "User", false, null, "STUDENT@TEST.COM", "STUDENT@TEST.COM", "AQAAAAEAACcQAAAAEPqFwLR2vOA7AC12y7RfBBKxheMlaOhNSoz6WC15BfDQYzjFhFTmAI0XGdPVfBCTnA==", null, false, "ebdab893-ea7e-4819-8c04-03f25cc266da", false, "student@test.com" },
                    { "2", 0, "4150740b-1cfd-4f6e-975a-0f1f7fd745eb", "teacher@test.com", true, "Teacher", "User", false, null, "TEACHER@TEST.COM", "TEACHER@TEST.COM", "AQAAAAEAACcQAAAAEBX+AA/JbonrPfYGgFrDOMo8jmJgf3u3BzHNnOCtm0X+cVVKDVhwqkpDDw/YyCyvdw==", null, false, "27603306-fdb4-48c2-830e-bef0e1cb8784", false, "teacher@test.com" },
                    { "3", 0, "8295e470-5356-4c7b-bb4f-c65f9b068979", "admin@test.com", true, "Admin", "User", false, null, "ADMIN@TEST.COM", "ADMIN@TEST.COM", "AQAAAAEAACcQAAAAEHATB3LKoj7ek6AP+HeZfhxolZMIAbfhmdaILUk6Mb+ao4mfcwjpautSoxQpqz6vnQ==", null, false, "7f9f884f-47e7-4194-b569-b1ff24fa0db5", false, "admin@test.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2", "2" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3", "3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");
        }
    }
}
