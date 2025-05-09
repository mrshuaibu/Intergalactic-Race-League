using System.Collections.Generic;
using IntergalacticRaceLeague.Models;
using IntergalacticRaceLeague.Repositories;

namespace IntergalacticRaceLeague.BLL
{
    public class TournamentService
    {
        private readonly TournamentRepository _tournamentRepository;

        public TournamentService(TournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        public List<Tournament> GetAllTournaments()
        {
            return _tournamentRepository.GetAllTournaments();
        }

        public Tournament? GetTournamentById(int id)
        {
            return _tournamentRepository.GetTournamentById(id);
        }

        public void AddTournament(Tournament tournament)
        {
            _tournamentRepository.AddTournament(tournament);
        }

        public void UpdateTournament(Tournament tournament)
        {
            _tournamentRepository.UpdateTournament(tournament);
        }

        public void DeleteTournament(int id)
        {
            _tournamentRepository.DeleteTournament(id);
        }
    }
}
