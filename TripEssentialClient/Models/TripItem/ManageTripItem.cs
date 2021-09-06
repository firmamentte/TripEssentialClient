using System.Collections.Generic;

namespace TripEssentialClient.Models.TripItem
{
    public class ManageTripItem
    {
        public List<TripItemGrid> CurrentTripItemGrid { get; set; } = new();
        public List<TripItemGrid> TripItemGrid { get; set; } = new();
    }
}
