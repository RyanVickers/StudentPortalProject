using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortalProject.Data.Migrations
{
    public partial class AssignmentCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Course_CourseId",
                table: "Assignment");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "0f435698-511f-4800-bc0b-92cf52534e37");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "3a5ef146-d615-4d6b-9f0d-f0a77fa8ad4b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "bbbafc24-a9b4-4e7e-8d45-31008a6c2fd9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a1711fed-0367-4b2e-9b04-ce13283ba109", "AQAAAAEAACcQAAAAEDLZQiVaROOE9tOBbASLjoldCb2mtodlvb6gft04Bau0PATs9BYErWyoDAdnNqgzTg==", "12b2a8fd-1c10-41d1-973b-8ff8800eae55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "11081555-0162-41a6-a2b7-64ffc5613741", "AQAAAAEAACcQAAAAEDgtxb5dfIPxMJCvEQEUgwF23HSk9QJ36i2iX8F0G20Nw86m6d88B+W99BVBI8hVEg==", "bf4f47f4-6d5d-4462-a3ca-e21d993ee8fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "436f113b-139d-45c2-8562-37137a975a77", "AQAAAAEAACcQAAAAEGteNNE8vA2acSohY1NJf81ycGLu8nD0+GLMx+7BocEEQ8m1EvDaXw3QtQ2z08ZW0Q==", "97a4af2c-d4cf-43c0-9439-fe4c86ee9f64" });

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Course_CourseId",
                table: "Assignment",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Course_CourseId",
                table: "Assignment");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f1d05c3b-b875-4945-9517-eaf58b70c366");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "cebe7b87-178f-4a9e-9f56-7e15c90abe8e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "2707432f-6d06-4947-82d3-bb9b83ff46b2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "adb00a26-399b-445b-a865-0aa4b78a6847", "AQAAAAEAACcQAAAAEOHvjuE9r+tT3uWcfmTUGH/OJbuRexKHDXOijR1B5CEF8Zx283g7afLnn8oFcnzNzg==", "b5e899a0-fa1f-41a3-81eb-beaa60eb488e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8e287b2-f89a-41e6-8bb9-c9f7c0d2a39f", "AQAAAAEAACcQAAAAECicLbkSYoZBJlmWpLC948HrEQb7DjJax8gvVqLYAc8YcMPRl75/FJErVBsMwtOc5A==", "c0f3f915-253d-4b46-8fe2-6bae9ff5509b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69c26a1a-f654-46eb-b91d-195dd0e814b6", "AQAAAAEAACcQAAAAEBuwBbyIuok4KpfD96isicYvUnk6CEb7fProfeD1KP9EVICP2R00zICQO5o0uotKbQ==", "5e0237df-c82b-4690-90c3-7ffbea571ec6" });

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Course_CourseId",
                table: "Assignment",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");
        }
    }
}
