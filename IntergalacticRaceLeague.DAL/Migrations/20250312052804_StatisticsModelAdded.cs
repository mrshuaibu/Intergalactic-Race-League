using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntergalacticRaceLeague.DAL.Migrations
{
    /// <inheritdoc />
    public partial class StatisticsModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatisticsId",
                table: "Tournaments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatisticsId",
                table: "Racers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    StatisticsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalRacers = table.Column<int>(type: "int", nullable: false),
                    TotalTournaments = table.Column<int>(type: "int", nullable: false),
                    TotalVehicles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.StatisticsId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_StatisticsId",
                table: "Tournaments",
                column: "StatisticsId");

            migrationBuilder.CreateIndex(
                name: "IX_Racers_StatisticsId",
                table: "Racers",
                column: "StatisticsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Racers_Statistics_StatisticsId",
                table: "Racers",
                column: "StatisticsId",
                principalTable: "Statistics",
                principalColumn: "StatisticsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Statistics_StatisticsId",
                table: "Tournaments",
                column: "StatisticsId",
                principalTable: "Statistics",
                principalColumn: "StatisticsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Racers_Statistics_StatisticsId",
                table: "Racers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Statistics_StatisticsId",
                table: "Tournaments");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropIndex(
                name: "IX_Tournaments_StatisticsId",
                table: "Tournaments");

            migrationBuilder.DropIndex(
                name: "IX_Racers_StatisticsId",
                table: "Racers");

            migrationBuilder.DropColumn(
                name: "StatisticsId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "StatisticsId",
                table: "Racers");
        }
    }
}
