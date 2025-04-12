using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace company.G3.DLL.Data.Migrations
{
    /// <inheritdoc />
    public partial class relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Empeloyees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empeloyees_DepartmentId",
                table: "Empeloyees",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empeloyees_Department_DepartmentId",
                table: "Empeloyees",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empeloyees_Department_DepartmentId",
                table: "Empeloyees");

            migrationBuilder.DropIndex(
                name: "IX_Empeloyees_DepartmentId",
                table: "Empeloyees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Empeloyees");
        }
    }
}
