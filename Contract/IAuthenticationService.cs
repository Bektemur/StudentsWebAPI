using WebAPI.DTO;

namespace WebAPI.Contract
{
    public interface IAuthenticationService
    {
        string GenerateToken(UserLoginDTO user);
    }
}
