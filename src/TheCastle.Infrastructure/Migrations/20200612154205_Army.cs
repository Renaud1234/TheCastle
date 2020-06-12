using Microsoft.EntityFrameworkCore.Migrations;

namespace TheCastle.Infrastructure.Migrations
{
    public partial class Army : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Castles_Towers_ArmyId",
                table: "Castles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Towers",
                table: "Towers");

            migrationBuilder.RenameTable(
                name: "Towers",
                newName: "Armies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Armies",
                table: "Armies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Castles_Armies_ArmyId",
                table: "Castles",
                column: "ArmyId",
                principalTable: "Armies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Castles_Armies_ArmyId",
                table: "Castles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Armies",
                table: "Armies");

            migrationBuilder.RenameTable(
                name: "Armies",
                newName: "Towers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Towers",
                table: "Towers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Castles_Towers_ArmyId",
                table: "Castles",
                column: "ArmyId",
                principalTable: "Towers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
