using Microsoft.EntityFrameworkCore.Migrations;

namespace CDX.NF.Domain.Migrations
{
    public partial class _27082018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                schema: "dbo",
                table: "Usuario",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                schema: "dbo",
                table: "Usuario",
                newName: "email");
        }
    }
}
