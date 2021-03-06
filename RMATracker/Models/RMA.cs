﻿using System;

namespace RMATracker.Models
{
    public class RMA
    {
        public int Id { get; set; }
        public string RMANumber { get; set; }
        public string Description { get; set; }
        public string TrackingNumber { get; set; }
        public string RepairVendor { get; set; }
        public string RepairDepot { get; set; }
        public string ShippingVendor { get; set; }
        public string SerialNumberSent { get; set; }
        public string SerialNumberReceived { get; set; }
        public int PartId { get; set; }
        public Part Part { get; set; }

        public DateTime DateSent { get; set; }
        public DateTime? DateReceived { get; set; }

        public int DaysOut()
        {
            return (DateTime.Now - DateSent).Days;
        }

        public int DaysToCompletion()
        {
            if (DateReceived is null)
            {
                return 0;
            }
            var daysToCompletion = Math.Abs(((DateTime)DateReceived - DateSent).Days);
            return daysToCompletion == 0 ? 1 : daysToCompletion;
        }
    }
}
