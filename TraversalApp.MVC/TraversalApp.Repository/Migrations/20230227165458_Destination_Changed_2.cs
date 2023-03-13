using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class Destination_Changed_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaximAuthor",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaximAuthor",
                table: "Destinations");
        }
    }
}
