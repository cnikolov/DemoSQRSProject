using System.Net;

namespace WebAPI.Response
{
    public record BaseResponse
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public string ErrorMessage { get; set; }
    }
}
