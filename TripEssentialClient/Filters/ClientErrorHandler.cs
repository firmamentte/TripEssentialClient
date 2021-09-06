using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TripEssentialClient.Filters
{
    public class ClientErrorHandler : IAsyncExceptionFilter
    {
        public async Task OnExceptionAsync(ExceptionContext filterContext)
        {
            var response = filterContext.HttpContext.Response;
            response.StatusCode = 500;
            await response.WriteAsync(filterContext.Exception.Message.Replace("\n", "<br />"));
            response.ContentType = MediaTypeNames.Text.Plain;
            filterContext.ExceptionHandled = true;
        }
    }
}
