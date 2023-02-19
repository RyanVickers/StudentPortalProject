using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortalProject.Data.Migrations
{
    public partial class Lectures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lectures_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LectureFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    LectureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LectureFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LectureFiles_Lectures_LectureId",
                        column: x => x.LectureId,
                        principalTable: "Lectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "72a77376-ce2a-49b8-babf-9039c2b86b9e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "2dcfe1ae-aa71-4a49-a128-7fa1aeadec82");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "aa10fa0c-3f14-451b-864f-829e9803865d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fad1ee06-5da3-4ccf-9b4d-29a8d9c42c1c", "AQAAAAEAACcQAAAAEJHmRY2GGNH5qjAv8c7udkyNJ8+363rKLgR2y7CMZnLo3wfOflmEHOmiiKYMQTdb2Q==", "1fc248ad-d392-441f-b55b-38b0f14aa9d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b6da550-3683-45df-992b-d036a2af6ef2", "AQAAAAEAACcQAAAAEEJzvS10G20Fa0ZgxgRbvvOnQXUmMI1zXj5v9dp0VNnn4minpyBvCVnq+EUSLHx9HQ==", "e68f6885-e0e1-4406-87ec-deebe83d657d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9b77422-af4a-4c9e-a307-a47a7f4a15ff", "AQAAAAEAACcQAAAAEOFy4dV4/UVIMoxB+8sR4TmODMh0csLpxVxPdFq7eLA1iN7Fk0vF2lRTmQb2/epu3w==", "9dd99012-6c23-4762-a678-8a8c5daf44d9" });

            migrationBuilder.CreateIndex(
                name: "IX_LectureFiles_LectureId",
                table: "LectureFiles",
                column: "LectureId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CourseId",
                table: "Lectures",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LectureFiles");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "612c8894-302c-434c-9e91-de9437d6c709");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "95c17dee-ecd6-465a-9688-e2f97f94f13f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "ef14cebf-2782-4991-a658-19296cdf8ba7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6195214-3018-464d-aa35-eb166829ccb4", "AQAAAAEAACcQAAAAEPqFwLR2vOA7AC12y7RfBBKxheMlaOhNSoz6WC15BfDQYzjFhFTmAI0XGdPVfBCTnA==", "ebdab893-ea7e-4819-8c04-03f25cc266da" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4150740b-1cfd-4f6e-975a-0f1f7fd745eb", "AQAAAAEAACcQAAAAEBX+AA/JbonrPfYGgFrDOMo8jmJgf3u3BzHNnOCtm0X+cVVKDVhwqkpDDw/YyCyvdw==", "27603306-fdb4-48c2-830e-bef0e1cb8784" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8295e470-5356-4c7b-bb4f-c65f9b068979", "AQAAAAEAACcQAAAAEHATB3LKoj7ek6AP+HeZfhxolZMIAbfhmdaILUk6Mb+ao4mfcwjpautSoxQpqz6vnQ==", "7f9f884f-47e7-4194-b569-b1ff24fa0db5" });
        }
    }
}
