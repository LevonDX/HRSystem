using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRSystem.Data.Migrations
{
    public partial class MadeDepartmentNulable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departaments_DepartamentId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departaments_DepartamentId",
                table: "Employees",
                column: "DepartamentId",
                principalTable: "Departaments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departaments_DepartamentId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departaments_DepartamentId",
                table: "Employees",
                column: "DepartamentId",
                principalTable: "Departaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
