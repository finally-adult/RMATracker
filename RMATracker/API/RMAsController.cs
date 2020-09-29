using Microsoft.AspNetCore.Mvc;
using RMATracker.Interfaces;
using RMATracker.Models;
using System.Collections.Generic;

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

        public IEnumerable<RMA> GetAllRMAs()
        {
            return repository.GetAllRMAs();
        }

        [HttpGet]
        public IEnumerable<Part> GetAllParts()
        {
            return repository.GetAllParts();
        }

        [HttpGet("{id}")]
        public RMA GetRMA(int id)
        {
            return repository.GetRMA(id);
        }
    }
}
