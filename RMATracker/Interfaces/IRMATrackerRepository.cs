using RMATracker.Models;
using System.Collections.Generic;

namespace RMATracker.Interfaces
{
    public interface IRMATrackerRepository
    {
        public IEnumerable<RMA> GetAllRMAs();
        public RMA GetRMA(int id);
        public void AddRMA(RMA rma);
        public void UpdateRMA(RMA rma);
        public void DeleteRMA(int id);
        public IEnumerable<Part> GetAllParts();
        public Part GetPart(int id);
        public void AddPart(Part part);
        public void UpdatePart(Part part);
        public void DeletePart(int id);
        public void Commit();
    }
}
