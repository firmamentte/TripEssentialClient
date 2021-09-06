using System;
using System.Collections.Generic;
using System.Linq;
using TripEssentialClient.BLL.DataContract;
using TripEssentialClient.Models.TripItem;

namespace TripEssentialClient.Controllers
{
    public class ControllerHelper
    {
        public static class TripItemHelper
        {
            public static List<TripItemGrid> FillCurrentTripItemGrid(List<TripItemResp> tripItemResps)
            {
                try
                {
                    if (tripItemResps is null)
                        tripItemResps = new List<TripItemResp>();

                    List<TripItemGrid> _tripItemGrids = new();

                    foreach (var tripItemResp in tripItemResps.OrderByDescending(tripItemResp => tripItemResp.Ranking).
                                                                       ThenBy(tripItemResp => tripItemResp.ItemName))
                    {
                        _tripItemGrids.Add(new TripItemGrid()
                        {
                            TripItemId = tripItemResp.TripItemId,
                            ItemName = tripItemResp.ItemName,
                            WeightInKgs = tripItemResp.WeightInKgs,
                            Ranking = tripItemResp.Ranking
                        });
                    }

                    return _tripItemGrids;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public static List<TripItemGrid> FillTripItemGrid(List<TripItemResp> tripItemResps)
            {
                try
                {
                    if (tripItemResps is null)
                        tripItemResps = new List<TripItemResp>();

                    List<TripItemGrid> _tripItemGrids = new();

                    foreach (var tripItemResp in tripItemResps.OrderByDescending(tripItemResp => tripItemResp.Ranking).
                                                                       ThenBy(tripItemResp => tripItemResp.ItemName))
                    {
                        _tripItemGrids.Add(new TripItemGrid()
                        {
                            TripItemId = tripItemResp.TripItemId,
                            ItemName = tripItemResp.ItemName,
                            WeightInKgs = tripItemResp.WeightInKgs,
                            Ranking = tripItemResp.Ranking
                        });
                    }

                    return _tripItemGrids;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            public static ManageTripItem FillManageTripItem(List<TripItemResp> currentTripItemResps, List<TripItemResp> tripItemResps)
            {
                try
                {
                    if (currentTripItemResps is null)
                        currentTripItemResps = new List<TripItemResp>();

                    if (tripItemResps is null)
                        tripItemResps = new List<TripItemResp>();

                    return new ManageTripItem()
                    {
                        CurrentTripItemGrid = FillCurrentTripItemGrid(currentTripItemResps),
                        TripItemGrid = FillTripItemGrid(tripItemResps)
                    };
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }
    }
}
