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
    }
}
