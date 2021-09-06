using Microsoft.AspNetCore.Mvc;
using TripEssentialClient.Models.Shared;

namespace TripEssentialClient.Controllers
{
    public class Shared : Controller
    {
        [HttpGet]
        public IActionResult Ok(string okMessage, string messageSymbol)
        {
            return PartialView("_Ok", new OkModel() { OkMessage = okMessage, MessageSymbol = messageSymbol });
        }
    }
}
