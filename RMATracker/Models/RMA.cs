using System;

namespace RMATracker.Models
{
    public class RMA
    {
        public int Id { get; set; }
        public string RMANumber { get; set; }
        public string Description { get; set; }
        public SerialNumber SerialNumber { get; set; }
        public DateTime DateSent { get; set; }
        public DateTime? DateReceived { get; set; }

        public int DaysOut()
        {
            return (DateTime.Now - DateSent).Days;
        }

        public double DaysToCompletion()
        {
            if (DateReceived != null)
            {
                return Math.Abs(DateSent.Subtract((DateTime)DateReceived).TotalDays);
            }
            return 0;
        }
    }
}
