using BowlingAPI.BowlingData;
using Microsoft.AspNetCore.Mvc;

namespace BowlingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BowlerController : ControllerBase
    {
        private IBowlingRepository _bowlingRepository;

        public BowlerController(IBowlingRepository temp)
        {
            _bowlingRepository = temp;
        }

        [HttpGet]
        public IEnumerable<BowlerTeam> Get()
        {
            var bowlerdata = _bowlingRepository.getBowlersWithTeamName().ToList();
            return bowlerdata;
        }
    }
}
