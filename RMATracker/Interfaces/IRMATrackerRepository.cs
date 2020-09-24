using RMATracker.Models;
using System.Collections.Generic;

namespace RMATracker.Interfaces
{
    public interface IRMATrackerRepository
    {
        public IEnumerable<RMA> GetAllRMAs();
        public IEnumerable<Part> GetAllParts();
        public IEnumerable<SerialNumber> GetAllSerialNumbers();
    }
}
