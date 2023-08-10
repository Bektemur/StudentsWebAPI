using System.Net;

namespace WebAPI.Service
{
    public interface IServiceException
    {
        public HttpStatusCode StatusCode { get; }
        public string Message { get; }
    }
}
