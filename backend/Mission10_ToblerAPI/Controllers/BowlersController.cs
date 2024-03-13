using Microsoft.AspNetCore.Mvc;
using Mission10_ToblerAPI.Models;
using Microsoft.AspNetCore.Http;

namespace Mission10_ToblerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BowlersController : ControllerBase
    {
        private readonly IBowlingRepository _repository;

        public BowlersController(IBowlingRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<BowlerDto> Get()
        {
            var bowlers = _repository.GetAllBowlersWithTeams();
            return bowlers;
        }


    }

}
