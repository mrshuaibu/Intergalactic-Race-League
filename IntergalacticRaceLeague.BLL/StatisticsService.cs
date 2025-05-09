using IntergalacticRaceLeague.DAL;
using IntergalacticRaceLeague.Models;

public class StatisticsService
{
    private readonly StatisticsRepository _statisticsRepository;

    public StatisticsService(StatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }

    public Statistics GetStatistics()
    {
        return _statisticsRepository.GetStatistics();
    }
}
