using Microsoft.EntityFrameworkCore.Migrations;

namespace CDX.NF.Domain.Migrations
{
    public partial class _200820181 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Certificado",
                schema: "dbo",
                table: "Parametros",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Certificado",
                schema: "dbo",
                table: "Parametros");
        }
    }
}
