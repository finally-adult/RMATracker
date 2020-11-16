using Microsoft.AspNetCore.Mvc;
using RMATracker.Interfaces;
using RMATracker.Models;

namespace RMATracker.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RMAsController : ControllerBase
    {
        private readonly IRMATrackerRepository repository;
        public RMAsController(IRMATrackerRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public RMA GetRMA(int id)
        {
            return repository.GetRMA(id);
        }

        [HttpGet("{id}")]
        public Part GetPart(int id)
        {
            return repository.GetPart(id);
        }
    }
}
