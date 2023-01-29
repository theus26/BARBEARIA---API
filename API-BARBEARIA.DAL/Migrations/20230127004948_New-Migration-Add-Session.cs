using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_BARBEARIA.DAL.Migrations
{
    public partial class NewMigrationAddSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    IdSession = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUser = table.Column<long>(type: "bigint", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LogoutDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SessionFinalized = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.IdSession);
                    table.ForeignKey(
                        name: "FK_Session_user_IdUser",
                        column: x => x.IdUser,
                        principalTable: "user",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Session_IdUser",
                table: "Session",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Session");
        }
    }
}
