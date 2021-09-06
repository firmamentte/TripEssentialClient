using System.Collections.Generic;

namespace TripEssentialClient.BLL.DataContract
{
    public class ApiErrorResp
    {
        public string Message { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
