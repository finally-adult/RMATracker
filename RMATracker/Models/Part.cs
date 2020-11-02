using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMATracker.Models
{
    // create arcive parts as well
    // can potentially get different part numbers
    // which repair depot it was sent to
    // tracking number
    public class Part
    {
        // add functionality to check out into field
        public Part()
        {
            SerialNumbers = new List<SerialNumber>();
        }
        [Key]
        public int Id { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public List<SerialNumber> SerialNumbers { get; set; }
        // manufacturer info

        public int Quantity()
        {
            return SerialNumbers.Count;
        }
    }
}
