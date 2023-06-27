using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Departments_departmentId",
                table: "Sellers");

            migrationBuilder.RenameColumn(
                name: "departmentId",
                table: "Sellers",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Sellers_departmentId",
                table: "Sellers",
                newName: "IX_Sellers_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Departments_DepartmentId",
                table: "Sellers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Departments_DepartmentId",
                table: "Sellers");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Sellers",
                newName: "departmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Sellers_DepartmentId",
                table: "Sellers",
                newName: "IX_Sellers_departmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Departments_departmentId",
                table: "Sellers",
                column: "departmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
