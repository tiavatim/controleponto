using Microsoft.EntityFrameworkCore.Migrations;

namespace ControlePonto.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TempodeDescanso",
                table: "TabFuncionario",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TabHorario",
                columns: table => new
                {
                    HorarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiadaSemana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraInicio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoraFim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TempodeDescanso = table.Column<int>(type: "int", nullable: true),
                    CargaHoraria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CargaHorariaSEmanal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id = table.Column<int>(type: "int", nullable: false),
                    Funcionarioid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabHorario", x => x.HorarioID);
                    table.ForeignKey(
                        name: "FK_TabHorario_TabFuncionario_Funcionarioid",
                        column: x => x.Funcionarioid,
                        principalTable: "TabFuncionario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TabHorario_Funcionarioid",
                table: "TabHorario",
                column: "Funcionarioid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabHorario");

            migrationBuilder.AlterColumn<string>(
                name: "TempodeDescanso",
                table: "TabFuncionario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
