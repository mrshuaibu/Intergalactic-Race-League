using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntergalacticRaceLeague.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SelectedRacerIds",
                table: "Tournaments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "SelectedTournamentIds",
                table: "Racers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedRacerIds",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "SelectedTournamentIds",
                table: "Racers");
        }
    }
}
