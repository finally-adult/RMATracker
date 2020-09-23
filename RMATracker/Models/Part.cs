using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMATracker.Models
{
    public class Part
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("RMA")]
        public int RMAId { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public List<SerialNumber> SerialNumbers { get; set; }
    }
}
