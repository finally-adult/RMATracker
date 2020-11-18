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

        public IEnumerable<RMA> GetAllRMAs()
        {
            var rmas = db.RMAs.Include(r => r.Part).ToList();
            return rmas;
        }

        public RMA GetRMA(int id)
        {
            return db.RMAs.FirstOrDefault(rma => rma.Id == id);
        }

        public void AddRMA(RMA rma)
        {
            var part = db.Parts.FirstOrDefault(p => p.Id == rma.PartId);
            part.QuantityOnHand -= 1;
            part.QuantityOutForRepair += 1;
            rma.DateSent = DateTime.Now;
            db.Add(rma);
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
                var part = db.Parts.FirstOrDefault(p => p.Id == rma.PartId);
                part.QuantityOnHand += 1;
                part.QuantityOutForRepair -= 1;
                db.Remove(rma);
            }
        }

        public IEnumerable<Part> GetAllParts()
        {
            return db.Parts.ToList();
        }

        public Part GetPart(int id)
        {
            return db.Parts.FirstOrDefault(part => part.Id == id);
        }

        public void AddPart(Part part)
        {
            db.Add(part);
        }

        public void UpdatePart(Part part)
        {
            var entity = db.Parts.Attach(part);
            entity.State = EntityState.Modified;
        }

        public void DeletePart(int id)
        {
            var part = db.Parts.FirstOrDefault(p => p.Id == id);
            if (part is Part)
            {
                db.Remove(part);
            }
        }

        public void Commit()
        {
            db.SaveChanges();
        }
    }
}
