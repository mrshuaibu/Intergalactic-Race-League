using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntergalacticRaceLeague.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTournamentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedRacerIds",
                table: "Tournaments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SelectedRacerIds",
                table: "Tournaments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
