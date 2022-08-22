using Contract.ViewModels.User;

namespace Ticketing.Extensions
{
    public interface IJWTExtension
    {
        Task<AuthenticationViewModel> GenerateAuthenticationToken(UserViewModel model, ushort days);
        Task<UserViewModel> IsTokenValid(string token);
    }
}
