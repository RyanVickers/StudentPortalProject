using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortalProject.Data.Migrations
{
    public partial class GroupFileUploadFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupFileUploads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupFileUploads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupFileUploads_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupFileUploads_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SubmissionId = table.Column<int>(type: "int", nullable: false),
                    FileUploadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupFiles_GroupFileUploads_FileUploadId",
                        column: x => x.FileUploadId,
                        principalTable: "GroupFileUploads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "31badb2a-3613-4506-ac86-4be417f5ef5d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "3192149f-e4f4-4e27-95b8-1134d9921290");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "ec5953d3-ad23-424a-88a9-757077a8ca78");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42c3052f-f6ce-45ac-b1a4-67d9f1a3fbcc", "AQAAAAEAACcQAAAAEHtSMGig8l6UZAZ6nPLdD4vyYYxFygcW6L9KZwy92Val6fMse0SLlW83gcrv2UubjA==", "1d339070-e633-4777-a414-78c5e95df409" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f115e24-94e8-4b0a-82ca-ce5ae2437a8b", "AQAAAAEAACcQAAAAEBmchZD0DJau1tLirUO8fUFCJq+zsz7BOjRo40iMHauiTN8EtnODbhC2gFucXfD1Tg==", "b22675bc-7b92-4c04-ab50-bb793f832027" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0491cce-c8c3-40dc-9353-8526136db7ec", "AQAAAAEAACcQAAAAEIbt/z5iYrZbZ/rfCOsAahed4SNDt6mOGan+Ifvht+qLnwFScnpicdmW1r3/Jixx+g==", "ba986056-4c10-4d45-b221-43e1ee1f88a8" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupFiles_FileUploadId",
                table: "GroupFiles",
                column: "FileUploadId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupFileUploads_GroupId",
                table: "GroupFileUploads",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupFileUploads_StudentId",
                table: "GroupFileUploads",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupFiles");

            migrationBuilder.DropTable(
                name: "GroupFileUploads");

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
        }
    }
}
