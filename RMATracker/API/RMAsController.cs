using Microsoft.AspNetCore.Mvc;
using RMATracker.Interfaces;

namespace RMATracker.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RMAsController : ControllerBase
    {
        private readonly IRMARepository repository;
        public RMAsController(IRMARepository repository)
        {
            this.repository = repository;
        }
    }
}
