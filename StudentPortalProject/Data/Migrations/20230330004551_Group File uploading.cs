using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortalProject.Data.Migrations
{
    public partial class GroupFileuploading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
