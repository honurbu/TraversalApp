using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraversalApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class rstatus_reservation_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RStatusId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Defination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RStatusId",
                table: "Reservations",
                column: "RStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_RStatuses_RStatusId",
                table: "Reservations",
                column: "RStatusId",
                principalTable: "RStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_RStatuses_RStatusId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "RStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RStatusId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RStatusId",
                table: "Reservations");
        }
    }
}
