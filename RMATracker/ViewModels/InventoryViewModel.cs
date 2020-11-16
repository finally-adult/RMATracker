using RMATracker.Models;
using System.Collections.Generic;

namespace RMATracker.ViewModels
{
    public class InventoryViewModel
    {
        public IEnumerable<Part> Parts { get; set; }
        public Part Part { get; set; }
    }
}
