using UrmetJournal.Models;

namespace UrmetJournal.Services
{
    public interface IAuthService
    {
        User Authenticate(string username, string password);
        string GenerateJwtToken(User user);
    }
}