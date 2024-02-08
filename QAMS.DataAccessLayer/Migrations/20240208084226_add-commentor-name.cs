using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAMS.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class addcommentorname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentorName",
                table: "comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentorName",
                table: "comments");
        }
    }
}
