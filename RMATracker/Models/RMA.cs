using System.Collections.Generic;

namespace RMATracker.Models
{
    public class RMA
    {
        public RMA()
        {
            Parts = new List<Part>();
        }
        public int Id { get; set; }
        public string RMANumber { get; set; }
        public List<Part> Parts { get; set; }
    }
}
