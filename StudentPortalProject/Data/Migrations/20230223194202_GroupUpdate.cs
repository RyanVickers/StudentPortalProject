using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortalProject.Data.Migrations
{
    public partial class GroupUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_AspNetUsers_StudentId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_StudentId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Groups");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Groups",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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
                name: "IX_Groups_StudentId",
                table: "Groups",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_AspNetUsers_StudentId",
                table: "Groups",
                column: "StudentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
