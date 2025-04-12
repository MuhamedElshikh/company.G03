using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace company.G3.DLL.Data.Migrations
{
    /// <inheritdoc />
    public partial class UBDATE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmpeloyeeType",
                table: "Empeloyees",
                newName: "EmployeeType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeType",
                table: "Empeloyees",
                newName: "EmpeloyeeType");
        }
    }
}
