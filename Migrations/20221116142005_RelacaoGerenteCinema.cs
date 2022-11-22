using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmesAPI.Migrations
{
    public partial class RelacaoGerenteCinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GerenteFK",
                table: "Cinemas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_GerenteId",
                table: "Cinemas",
                column: "GerenteFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_Gerente_GerenteId",
                table: "Cinemas",
                column: "GerenteFK",
                principalTable: "Gerente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_Gerente_GerenteId",
                table: "Cinemas");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_GerenteId",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "GerenteFK",
                table: "Cinemas");
        }
    }
}
