using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripEssentialClient.BLL;
using TripEssentialClient.BLL.DataContract;

namespace TripEssentialClient.Controllers
{
    public class TripItem : Controller
    {
        [HttpGet]
        public async Task<IActionResult> ManageTripItem()
        {
            try
            {
                //if (!_tripItemResps.Any())
                //    ViewBag.GridViewMessage = "Search yielded no results...";

                //PartialView("TripItemGrid", ControllerHelper.TripItemHelper.FillTripItemGrid(_tripItemResps));

                //PartialView("CurrentTripItemGrid", new List<CurrentTripItemGrid>());

                return View(ControllerHelper.TripItemHelper.FillManageTripItem
                    (await TripEssentialClientBLL.TripItemHelper.GetKnapsacktems(),
                    await TripEssentialClientBLL.TripItemHelper.GetTripItems()));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOrRemoveKnapsackItem(Guid tripItemId, bool isAdd)
        {
            try
            {
                await TripEssentialClientBLL.TripItemHelper.AddOrRemoveKnapsackItem(new AddOrRemoveKnapsackItemReq() { TripItemId = tripItemId });

                if (isAdd)
                {
                    return PartialView("CurrentTripItemGrid", ControllerHelper.TripItemHelper.FillCurrentTripItemGrid(await TripEssentialClientBLL.TripItemHelper.GetKnapsacktems()));
                }
                else
                {
                    return PartialView("TripItemGrid", ControllerHelper.TripItemHelper.FillCurrentTripItemGrid(await TripEssentialClientBLL.TripItemHelper.GetTripItems()));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetKnapsackCapacity()
        {
            try
            {
                return Json(await TripEssentialClientBLL.TripItemHelper.GetKnapsackCapacity());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
