using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class changetitlecolumnname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tilte",
                table: "questions",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "questions",
                newName: "Tilte");
        }
    }
}
