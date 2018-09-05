using Microsoft.EntityFrameworkCore.Migrations;

namespace CDX.NF.Domain.Migrations
{
    public partial class _140820184 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ValorNota",
                schema: "dbo",
                table: "Requisicao",
                nullable: true,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "ValorNota",
                schema: "dbo",
                table: "Requisicao",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
