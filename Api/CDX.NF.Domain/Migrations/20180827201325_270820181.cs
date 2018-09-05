using Microsoft.EntityFrameworkCore.Migrations;

namespace CDX.NF.Domain.Migrations
{
    public partial class _270820181 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UtilizaCertificado",
                schema: "dbo",
                table: "Parametros",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UtilizaCertificado",
                schema: "dbo",
                table: "Parametros");
        }
    }
}
