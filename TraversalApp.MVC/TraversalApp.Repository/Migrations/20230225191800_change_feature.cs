using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class change_feature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Features2",
                newName: "Post1Name");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Features2",
                newName: "Post1Status");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Features2",
                newName: "Post1Image");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Features2",
                newName: "Post1Description");

            migrationBuilder.RenameColumn(
                name: "Post1Status",
                table: "Features",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Post1Name",
                table: "Features",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Post1Image",
                table: "Features",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Post1Description",
                table: "Features",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Post1Status",
                table: "Features2",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Post1Name",
                table: "Features2",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Post1Image",
                table: "Features2",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Post1Description",
                table: "Features2",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Features",
                newName: "Post1Name");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Features",
                newName: "Post1Status");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Features",
                newName: "Post1Image");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Features",
                newName: "Post1Description");
        }
    }
}
