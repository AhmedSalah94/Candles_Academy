using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Candles_Academy.Migrations
{
    public partial class Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Courses_CourseId1",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_CourseId1",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "CourseId1",
                table: "Teachers",
                newName: "Rate");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Teachers",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CourseId",
                table: "Teachers",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Courses_CourseId",
                table: "Teachers",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Courses_CourseId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_CourseId",
                table: "Teachers");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "Teachers",
                newName: "CourseId1");

            migrationBuilder.AlterColumn<byte>(
                name: "CourseId",
                table: "Teachers",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CourseId1",
                table: "Teachers",
                column: "CourseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Courses_CourseId1",
                table: "Teachers",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
