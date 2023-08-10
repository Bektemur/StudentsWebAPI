using System.Net;
using WebAPI.Service;

namespace WebAPI.CustomException
{
    public class DuplicateEmailException : Exception, IServiceException
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
        public DuplicateEmailException(string? email) : base(String.Format("Email already exists {0}", email))
        {
        }
    }
}
