using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class titleaddedintquestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionDescription",
                table: "questions",
                newName: "Tilte");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "questions");

            migrationBuilder.RenameColumn(
                name: "Tilte",
                table: "questions",
                newName: "QuestionDescription");
        }
    }
}
