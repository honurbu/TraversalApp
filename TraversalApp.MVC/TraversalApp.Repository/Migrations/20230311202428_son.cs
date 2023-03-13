using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class son : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RStatus_RStatusId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "RStatus");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RStatusId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RStatusId",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "RStatusId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RStatusId",
                table: "Reservations",
                column: "RStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_RStatus_RStatusId",
                table: "Reservations",
                column: "RStatusId",
                principalTable: "RStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
