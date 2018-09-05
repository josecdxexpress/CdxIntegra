using Microsoft.EntityFrameworkCore.Migrations;

namespace CDX.NF.Domain.Migrations
{
    public partial class _140820183 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prestador",
                schema: "dbo",
                table: "Requisicao");

            migrationBuilder.RenameColumn(
                name: "erro",
                schema: "dbo",
                table: "Requisicao",
                newName: "Erro");

            migrationBuilder.AddColumn<int>(
                name: "PrestadorId",
                schema: "dbo",
                table: "Requisicao",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requisicao_PrestadorId",
                schema: "dbo",
                table: "Requisicao",
                column: "PrestadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Requisicao_Prestador_PrestadorId",
                schema: "dbo",
                table: "Requisicao",
                column: "PrestadorId",
                principalSchema: "dbo",
                principalTable: "Prestador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisicao_Prestador_PrestadorId",
                schema: "dbo",
                table: "Requisicao");

            migrationBuilder.DropIndex(
                name: "IX_Requisicao_PrestadorId",
                schema: "dbo",
                table: "Requisicao");

            migrationBuilder.DropColumn(
                name: "PrestadorId",
                schema: "dbo",
                table: "Requisicao");

            migrationBuilder.RenameColumn(
                name: "Erro",
                schema: "dbo",
                table: "Requisicao",
                newName: "erro");

            migrationBuilder.AddColumn<string>(
                name: "Prestador",
                schema: "dbo",
                table: "Requisicao",
                maxLength: 20,
                nullable: true);
        }
    }
}
