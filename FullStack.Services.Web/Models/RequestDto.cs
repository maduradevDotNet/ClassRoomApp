using System.Security.AccessControl;
using static FullStack.Services.Web.Utility.SD;

namespace FullStack.Services.Web.Models
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }

    }
}
