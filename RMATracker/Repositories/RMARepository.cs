using RMATracker.Data;
using RMATracker.Interfaces;

namespace RMATracker.Repositories
{
    public class RMARepository : IRMARepository
    {
        private readonly RMATrackerContext db;
        public RMARepository(RMATrackerContext db)
        {
            this.db = db;
        }


    }
}
