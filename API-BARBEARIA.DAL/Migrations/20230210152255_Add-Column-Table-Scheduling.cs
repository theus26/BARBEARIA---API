using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_BARBEARIA.DAL.Migrations
{
    public partial class AddColumnTableScheduling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameUser",
                table: "scheduling",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameUser",
                table: "scheduling");
        }
    }
}
