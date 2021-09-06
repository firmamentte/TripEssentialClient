using System;

namespace TripEssentialClient.Models.TripItem
{
    public class TripItemGrid
    {
        public Guid TripItemId { get; set; }
        public string ItemName { get; set; }
        public decimal WeightInKgs { get; set; }
        public int Ranking { get; set; }
    }
}
