using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_BARBEARIA.DAL.Migrations
{
    public partial class addnewcampoScheduling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SchedulingCompleted",
                table: "scheduling",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchedulingCompleted",
                table: "scheduling");
        }
    }
}
