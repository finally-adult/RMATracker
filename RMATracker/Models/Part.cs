using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMATracker.Models
{
    // create archive parts as well
    // can potentially get different part numbers
    // which repair depot it was sent to
    public class Part
    {
        // add functionality to check out into field
        [Key]
        public int Id { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        // manufacturer info
        public int QuantityOnHand { get; set; }
        public int QuantityOutForRepair { get; set; }
        public int QuantityInField { get; set; }
    }
}
