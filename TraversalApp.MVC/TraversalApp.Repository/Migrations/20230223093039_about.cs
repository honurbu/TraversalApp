using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class about : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Abouts",
                newName: "Title1");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "Abouts",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description1",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "Description1",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "Title1",
                table: "Abouts",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Abouts",
                newName: "Details");
        }
    }
}
