using Microsoft.EntityFrameworkCore.Migrations;

namespace TheCastle.Infrastructure.Migrations
{
    public partial class CorrectionCastle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Castles_Armies_ArmyId",
                table: "Castles");

            migrationBuilder.AlterColumn<int>(
                name: "ArmyId",
                table: "Castles",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Castles_Armies_ArmyId",
                table: "Castles",
                column: "ArmyId",
                principalTable: "Armies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Castles_Armies_ArmyId",
                table: "Castles");

            migrationBuilder.AlterColumn<int>(
                name: "ArmyId",
                table: "Castles",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Castles_Armies_ArmyId",
                table: "Castles",
                column: "ArmyId",
                principalTable: "Armies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
