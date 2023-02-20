using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortalProject.Data.Migrations
{
    public partial class Announcements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Grade",
                table: "AssignmentSubmissions",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Announcement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announcement_Course_CourseId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Announcement_CourseId",
                table: "Announcement",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcement");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "AssignmentSubmissions");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "b7f1aa63-177f-4b5d-9ec7-4e34a44c0a74");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "e4e6ba63-00ff-4c94-bc6c-c2913aae6fe6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "fcd62b7b-3a5c-4522-80ee-12ab60f37b78");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b227f28-e848-445f-b113-8d46bd220ac3", "AQAAAAEAACcQAAAAEHbqY40s/Mdxfg/VNzcZCwZGo6OpjTgy5AEpwZuQX7mAfyau+QVRj3ArzetBFANHkg==", "f7ec421a-7759-4ed5-b9b4-5e60c9d22aca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ba0225a-7d45-44d1-834e-6ab073101bb8", "AQAAAAEAACcQAAAAEGHaeL2kfQjLX+7phXkPYwJc3eGZ0ISKSbUXUmJOnjZaaZ+gwolBSFRa8QwAwbuhOA==", "c725ce4d-9f6a-4000-be93-53190888809b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "16d1949b-4e0b-4446-bfbe-fa8d2389eefe", "AQAAAAEAACcQAAAAEH4X+lsXHNyOiVg+Ns3VscHQWM3P3GP2TNejYXXTFRh+mDcnr6Pal7nKN/8ODBx1Sg==", "0efe8da1-09bd-44e9-b972-5d1288433a76" });
        }
    }
}
