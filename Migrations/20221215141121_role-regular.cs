using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosAPI.Migrations
{
    public partial class roleregular : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "0ce7fdca-7363-4270-8d14-77a5cc9079a8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99997, "5e2d9fe0-7457-4664-b319-6f4ec4840c14", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ad508db-92b9-46ae-8d57-7650028c6989", "AQAAAAEAACcQAAAAEN2HB4a1Mv74L7oHaedNZI2U6xgeTC0imJ8YNKHSIpft7jXwMBLJK6xMhCMmKTSI+Q==", "fc87fa7f-e2f8-4fb9-9eff-132b86ad30c7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "584dd8c9-b208-40ef-8d37-914421c36691");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5849327e-77de-4a70-9d67-f3adea497d65", "AQAAAAEAACcQAAAAEP71TIY97SY8TfTakjfFFgUeQ2kg8eD9Dt/3BeTEgQi+00InL3ULnpVxAI3al2ENeQ==", "57c6bb9c-f4f6-42a5-97a1-d0656d53acbc" });
        }
    }
}
