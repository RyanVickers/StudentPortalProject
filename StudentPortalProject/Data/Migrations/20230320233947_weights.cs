using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortalProject.Data.Migrations
{
    public partial class weights : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Course_CourseId",
                table: "Assignment");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Course",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Assignment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                table: "Assignment",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "51663824-eb31-43a3-86a3-8410ec7037b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "c18fd7e5-799a-4e00-bd2f-b1452dc5650f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "2d331a07-32f4-48be-8ea6-bc53b4ca002c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc87267e-b7bb-42ac-8cf5-7110a7116438", "AQAAAAEAACcQAAAAEAVOH06xCmGrHpv+JiD8EKBjwg/+s5DumGSMMf5HgNIP0ON6ZNzfvKFMl20Pqh17Bw==", "52117fd6-dc49-4b6e-86bd-1275d6419dd8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fffc24c2-1a0f-4edd-9bde-77e72972f85d", "AQAAAAEAACcQAAAAEC+gn8hL6RedB9byPOcX1VKsITEX9s0ktpmyK0nYKbUQJMZXavAW0GxMIIuXX7dYBQ==", "37cc9ead-0cd7-440c-9173-d004a4f94f45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b8a52829-0efb-4bfb-aea2-9580db510c68", "AQAAAAEAACcQAAAAEOJiJBjd7Fb8ofIs3BJaaW3tZ+JIDh3zSWQ+q7MG83xFnvuHu4Oy3lgGB6hp2uf7xg==", "81fd0818-58b8-47de-8bfb-58f57d4b421b" });

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Course_CourseId",
                table: "Assignment",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignment_Course_CourseId",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Assignment");

            migrationBuilder.AlterColumn<string>(
                name: "TeacherId",
                table: "Course",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Assignment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Assignment_Course_CourseId",
                table: "Assignment",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
