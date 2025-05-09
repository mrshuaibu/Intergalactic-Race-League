using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntergalacticRaceLeague.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RaceResultRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racers_RaceResults_RaceResultId",
                table: "Racers");

            migrationBuilder.DropIndex(
                name: "IX_Racers_RaceResultId",
                table: "Racers");

            migrationBuilder.DropColumn(
                name: "RaceResultId",
                table: "Racers");

            migrationBuilder.CreateTable(
                name: "RacerRaceResults",
                columns: table => new
                {
                    RacerId = table.Column<int>(type: "int", nullable: false),
                    RaceResultId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacerRaceResults", x => new { x.RacerId, x.RaceResultId });
                    table.ForeignKey(
                        name: "FK_RacerRaceResults_RaceResults_RaceResultId",
                        column: x => x.RaceResultId,
                        principalTable: "RaceResults",
                        principalColumn: "RaceResultId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacerRaceResults_Racers_RacerId",
                        column: x => x.RacerId,
                        principalTable: "Racers",
                        principalColumn: "RacerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RacerRaceResults_RaceResultId",
                table: "RacerRaceResults",
                column: "RaceResultId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RacerRaceResults");

            migrationBuilder.AddColumn<int>(
                name: "RaceResultId",
                table: "Racers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Racers_RaceResultId",
                table: "Racers",
                column: "RaceResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Racers_RaceResults_RaceResultId",
                table: "Racers",
                column: "RaceResultId",
                principalTable: "RaceResults",
                principalColumn: "RaceResultId");
        }
    }
}
