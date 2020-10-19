using Microsoft.EntityFrameworkCore;
using RMATracker.Data;
using RMATracker.Interfaces;
using RMATracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RMATracker.Repositories
{
    public class RMATrackerRepository : IRMATrackerRepository
    {
        private readonly RMATrackerContext db;
        public RMATrackerRepository(RMATrackerContext db)
        {
            this.db = db;
        }

        public void Commit()
        {
            db.SaveChanges();
        }

        public void AddRMA(RMA rma)
        {
            rma.DateSent = DateTime.Now;
            db.Add(rma);
        }

        public void AddPart(Part part)
        {
            db.Add(part);
        }

        public IEnumerable<Part> GetAllParts()
        {
            return db.Parts
                .Include(part => part.SerialNumbers)
                .ToList();
        }

        public IEnumerable<RMA> GetAllRMAs()
        {
            return db.RMAs.Include(rma => rma.SerialNumber).ToList();
        }

        public IEnumerable<SerialNumber> GetAllSerialNumbers()
        {
            return db.SerialNumbers.ToList();
        }

        public void AddSerialNumber(SerialNumber serialNumber)
        {
            db.Add(serialNumber);
        }

        public RMA GetRMA(int id)
        {
            return db.RMAs.Include(rma => rma.SerialNumber).FirstOrDefault(rma => rma.Id == id);
        }

        public void UpdateSerialNumber(SerialNumber serialNumber)
        {
            var entity = db.SerialNumbers.Attach(serialNumber);
            entity.State = EntityState.Modified;
        }

        public SerialNumber GetSerialNumberById(int id)
        {
            return db.SerialNumbers.Find(id);
        }

        public void UpdateRMA(RMA rma)
        {
            var entity = db.RMAs.Attach(rma);
            entity.State = EntityState.Modified;
        }

        public void DeleteRMA(int id)
        {
            var rma = db.RMAs.Find(id);
            if (rma is RMA)
            {
                db.Remove(rma);
            }
        }

        public void RemoveSerialNumberByRMAId(int id)
        {
            var serialNumber = db.SerialNumbers.Single(s => s.RMAId == id);
            serialNumber.RMAId = null;
            serialNumber.OutForRepair = false;
        }
    }
}
