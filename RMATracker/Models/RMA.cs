using System;
using System.Collections.Generic;

namespace RMATracker.Models
{
    public class RMA
    {
        public RMA()
        {
            SerialNumbers = new List<SerialNumber>();
        }
        public int Id { get; set; }
        public string RMANumber { get; set; }
        public List<SerialNumber> SerialNumbers { get; set; }
        public DateTime DateSent { get; set; }
        public DateTime? DateReceived { get; set; }

        public int DaysOut()
        {
            return (DateTime.Now - DateSent).Days;
        }
    }
}
