using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortalProject.Data.Migrations
{
    public partial class comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "AssignmentSubmissions",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "AssignmentSubmissions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "27069550-a3ba-4691-b1bf-6ca3d0ef4418");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "59c360a9-6593-418f-aa62-f75b0746a164");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "51498596-5d5f-4341-81a4-25ef402b1eb9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7f4f7a5-26ba-4174-8ee8-35f4ab22ef9f", "AQAAAAEAACcQAAAAEEBCdDAg2YnHyWmPJLu5dYcPutu/N/fSgd4rhEO+L6mE7cpbFTBDw8j2iYcz+Emkjg==", "ce191363-12fd-4041-b087-722648ceeada" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "046f5cb3-6f52-4c3c-b721-175a25ade93d", "AQAAAAEAACcQAAAAECq+mz9nIyE/8TNRtLKhRQJRD+fXM2MuM8WEx7ZoZx9dkyWTn6ykYxxNodhfCBev+Q==", "80de862b-1ed3-4321-ba51-e52dc570a148" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4792a6a8-5a29-4253-89c5-fde404dbb151", "AQAAAAEAACcQAAAAEAjSH9sBxOxNe7QeTh5/Xy++Qq9Pv6cgps0dnzu98pnvilBWHlUxRXfbMg/ZaDuEVw==", "91c06551-75ac-4327-8b85-89bfb1b4e522" });
        }
    }
}
