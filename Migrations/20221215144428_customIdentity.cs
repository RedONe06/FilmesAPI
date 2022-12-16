using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosAPI.Migrations
{
    public partial class customIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "95d4db01-0e91-48ab-8efc-9e6be3bc5768");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "97208204-9e56-4561-8087-93d7a171b65b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "621f3589-5791-44cb-aedc-2b1363f4481b", "AQAAAAEAACcQAAAAEKx3h3f6c4sqY5xts44DEYctKm1nqiBOf5KKooKbBRpEC9wtXutSFGoxIN6yiPl/Aw==", "4ffbdbd6-3271-455a-8748-8c5c0e620ed3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "5e2d9fe0-7457-4664-b319-6f4ec4840c14");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "0ce7fdca-7363-4270-8d14-77a5cc9079a8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ad508db-92b9-46ae-8d57-7650028c6989", "AQAAAAEAACcQAAAAEN2HB4a1Mv74L7oHaedNZI2U6xgeTC0imJ8YNKHSIpft7jXwMBLJK6xMhCMmKTSI+Q==", "fc87fa7f-e2f8-4fb9-9eff-132b86ad30c7" });
        }
    }
}
