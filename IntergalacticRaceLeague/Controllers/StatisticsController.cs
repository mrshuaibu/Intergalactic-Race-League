using Microsoft.AspNetCore.Mvc;
using IntergalacticRaceLeague.BLL;
using IntergalacticRaceLeague.Models;


namespace IntergalacticRaceLeague.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly StatisticsService _statisticsService;

        public StatisticsController(StatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public IActionResult Index()
        {
            Statistics statistics = _statisticsService.GetStatistics();

            return View(statistics);
        }
    }
}
