using System.Collections.Generic;
using System.Linq;
using IntergalacticRaceLeague.Models;
using IntergalacticRaceLeague.DAL;

namespace IntergalacticRaceLeague.Repositories
{
    public class TournamentRepository
    {
        private readonly IntergalacticRaceLeagueDbContext _context;

        public TournamentRepository(IntergalacticRaceLeagueDbContext context)
        {
            _context = context;
        }

        public List<Tournament> GetAllTournaments()
        {
            return _context.Tournaments.ToList();
        }

        public Tournament? GetTournamentById(int id)
        {
            return _context.Tournaments.FirstOrDefault(t => t.TournamentId == id);
        }

        public void AddTournament(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
            _context.SaveChanges();
        }

        public void UpdateTournament(Tournament tournament)
        {
            Tournament? existingTournament = _context.Tournaments.Find(tournament.TournamentId);
            if (existingTournament != null)
            {
                existingTournament.TournamentName = tournament.TournamentName;
                existingTournament.Location = tournament.Location;
                existingTournament.StartDate = tournament.StartDate;
                existingTournament.EndDate = tournament.EndDate;

                _context.Tournaments.Update(existingTournament);
                _context.SaveChanges();
            }
        }

        public void DeleteTournament(int id)
        {
            Tournament? tournament = _context.Tournaments.FirstOrDefault(t => t.TournamentId == id);
            if (tournament != null)
            {
                _context.Tournaments.Remove(tournament);
                _context.SaveChanges();
            }
        }
    }
}
