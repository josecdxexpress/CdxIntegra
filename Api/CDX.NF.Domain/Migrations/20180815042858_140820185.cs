using Microsoft.EntityFrameworkCore.Migrations;

namespace CDX.NF.Domain.Migrations
{
    public partial class _140820185 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrestadorCnpj",
                schema: "dbo",
                table: "NotaFiscalAutorizada");

            migrationBuilder.AddColumn<int>(
                name: "PrestadorId",
                schema: "dbo",
                table: "NotaFiscalAutorizada",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscalAutorizada_PrestadorId",
                schema: "dbo",
                table: "NotaFiscalAutorizada",
                column: "PrestadorId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotaFiscalAutorizada_Prestador_PrestadorId",
                schema: "dbo",
                table: "NotaFiscalAutorizada",
                column: "PrestadorId",
                principalSchema: "dbo",
                principalTable: "Prestador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotaFiscalAutorizada_Prestador_PrestadorId",
                schema: "dbo",
                table: "NotaFiscalAutorizada");

            migrationBuilder.DropIndex(
                name: "IX_NotaFiscalAutorizada_PrestadorId",
                schema: "dbo",
                table: "NotaFiscalAutorizada");

            migrationBuilder.DropColumn(
                name: "PrestadorId",
                schema: "dbo",
                table: "NotaFiscalAutorizada");

            migrationBuilder.AddColumn<string>(
                name: "PrestadorCnpj",
                schema: "dbo",
                table: "NotaFiscalAutorizada",
                maxLength: 20,
                nullable: true);
        }
    }
}
