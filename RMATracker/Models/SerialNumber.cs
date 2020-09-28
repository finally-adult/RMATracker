using System.ComponentModel.DataAnnotations;

namespace RMATracker.Models
{
    public class SerialNumber
    {
        [Key]
        public int Id { get; set; }
        public int PartId { get; set; }
        public string Serial { get; set; }
        public int? RMAId { get; set; }
    }
}
