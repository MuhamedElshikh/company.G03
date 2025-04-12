using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace company.G3.DLL.Data.Migrations
{
    /// <inheritdoc />
    public partial class edite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Empeloyees",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Empeloyees",
                newName: "Adress");
        }
    }
}
