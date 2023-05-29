using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_BARBEARIA.DAL.Migrations
{
    public partial class AdiconandoColunaDeDisponibilidadeddeHorario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AvailableTime",
                table: "horaries",
                type: "tinyint(1)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableTime",
                table: "horaries");
        }
    }
}
