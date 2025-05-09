using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IntergalacticRaceLeague.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MinorUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Racers_RacerId",
                table: "RaceResults");

            migrationBuilder.DropIndex(
                name: "IX_RaceResults_RacerId",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "RaceTime",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "RacerId",
                table: "RaceResults");

            migrationBuilder.AddColumn<int>(
                name: "RaceResultId",
                table: "Racers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedRacersIds",
                table: "RaceResults",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "SelectedRacersIds",
                table: "RaceResults");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "RaceTime",
                table: "RaceResults",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "RacerId",
                table: "RaceResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_RacerId",
                table: "RaceResults",
                column: "RacerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_Racers_RacerId",
                table: "RaceResults",
                column: "RacerId",
                principalTable: "Racers",
                principalColumn: "RacerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
