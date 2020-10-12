using Microsoft.AspNetCore.Mvc.Rendering;
using RMATracker.Models;
using System.Collections.Generic;

namespace RMATracker.ViewModels
{
    public class ActiveViewModel
    {
        public RMA RMA { get; set; }
        public IEnumerable<RMA> RMAs { get; set; }
        public SelectList Parts { get; set; }
        public int SerialId { get; set; }
    }
}
