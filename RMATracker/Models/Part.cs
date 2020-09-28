using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RMATracker.Models
{
    public class Part
    {
        public Part()
        {
            SerialNumbers = new List<SerialNumber>();
        }
        [Key]
        public int Id { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public List<SerialNumber> SerialNumbers { get; set; }

        public int Quantity()
        {
            return SerialNumbers.Count;
        }
    }
}
