using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlePonto.Migrations
{
    public partial class atual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TabFuncionario",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "TabFuncionario",
                newName: "Id");
        }
    }
}
