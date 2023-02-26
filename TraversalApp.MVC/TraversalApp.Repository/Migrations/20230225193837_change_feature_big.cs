using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class change_feature_big : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBigArea",
                table: "Features",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBigArea",
                table: "Features");
        }
    }
}
