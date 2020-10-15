using RMATracker.Models;
using System.Collections.Generic;

namespace RMATracker.Interfaces
{
    public interface IRMATrackerRepository
    {
        public IEnumerable<RMA> GetAllRMAs();
        public IEnumerable<Part> GetAllParts();
        public IEnumerable<SerialNumber> GetAllSerialNumbers();
        public void AddRMA(RMA rma);
        public void AddPart(Part part);
        public void Commit();
        public void AddSerialNumber(SerialNumber serialNumber);
        RMA GetRMA(int id);
        public void UpdateSerialNumber(SerialNumber serialNumber);
        public void UpdateRMA(RMA rma);
        public SerialNumber GetSerialNumberById(int id);
        public void DeleteRMA(int id);
        void RemoveSerialNumberByRMAId(int id);
    }
}
