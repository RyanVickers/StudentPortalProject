using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortalProject.Data.Migrations
{
    public partial class Groups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Groups_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "9c2d3cb2-19fb-4ee6-bd63-a30bb4408fc0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "a63e741c-60ed-4332-bce8-2d39f40d3649");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "c302e3f4-4f4f-41d0-9e6e-167c4485ae70");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a0cd1b2-ae48-451a-b7bf-5e0b34dc0aab", "AQAAAAEAACcQAAAAEP/FNaEA70uNWmjRQUn3BVODmbfgNHI2GltIJ/VKqEVjL6mvUgnoyXnGKZmOYa8Z0w==", "0a287267-f9fe-42b3-9715-0db3762b4d45" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a3a5168-94db-4b22-8312-f9710cf644ba", "AQAAAAEAACcQAAAAEBkr1L1Qd9I7dVDy9r4eFNkGyY3WS7edyG/9nnRg9pp1Q9hmHbwSkHcoX1gTTzRCXw==", "bb06fe53-2c77-461c-8f0a-13daefdaa7fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "634aef16-7c1a-472c-928f-8201fab4eef9", "AQAAAAEAACcQAAAAEFfE/SLmPZwfsLeJKoDbyRcK/VK9+Sdr7tmSeDZj2szuPOM4/La/Wl6zmbs3sf6xtg==", "db17d5a9-2bb0-44cd-9cf4-f3bdbe233758" });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CourseId",
                table: "Groups",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Groups_StudentId",
                table: "Groups",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b1220f2c-2344-418c-bdea-b2641c5ea1cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "19f415ac-fc35-45fe-a0b5-01ea098d5922");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "77d304ff-de77-4477-93cf-e46ff96377a1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1161d3f-d595-4057-bc04-8982d263f242", "AQAAAAEAACcQAAAAED2DBo6xvZjx9545LJHxS5icYZdn5pFRsw5fUhaBdtkJXFOyZlqdKcCTWd8HGre5kw==", "5457a3a3-0aef-4678-afb7-807a02c1437e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1cd4475-e467-403b-ad54-31c56a7067a3", "AQAAAAEAACcQAAAAEGIGmiL2Ctu+XnyMv1ifT9bNAJApt02KCUHpYPqWiJ50nufbLtbf0jYwhDb40WQ5sQ==", "7f17cd8e-7a27-47e4-8e7f-54241e04046f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d37d54d0-7e7c-44ef-9909-3fdf8828bc9b", "AQAAAAEAACcQAAAAEK3eLXzJvATQpSe6ys78wqB3I64Xpub4e6rRMg0CDjzvqfzWxFmtOMaeujs+xS/60A==", "a091f693-8a7c-4f66-b1a5-b6a11d1a159e" });
        }
    }
}
