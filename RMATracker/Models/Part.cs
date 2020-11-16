using System.ComponentModel.DataAnnotations;

namespace RMATracker.Models
{
    public class Part
    {
        [Key]
        public int Id { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public int QuantityOnHand { get; set; }
        public int QuantityOutForRepair { get; set; }
        public int QuantityInField { get; set; }
    }
}
