using RMATracker.Models;
using System.Collections.Generic;

namespace RMATracker.ViewModels
{
    public class RMAViewModel
    {
        public IEnumerable<RMA> RMAs { get; set; }
        public IEnumerable<Part> Parts { get; set; }
        public IEnumerable<SerialNumber> SerialNumbers { get; set; }
    }
}
