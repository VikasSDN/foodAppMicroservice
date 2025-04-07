using AuthService.Model;

namespace AuthService.Service
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
        Task<User> AuthenticateUser(RequestDto loginUser);
    }
}
