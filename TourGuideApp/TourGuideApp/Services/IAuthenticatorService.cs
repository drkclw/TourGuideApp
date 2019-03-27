using System.Threading.Tasks;

namespace TourGuideApp.Services
{
    public interface IAuthenticatorService
    {
        /// <summary>
        /// Login with email and password.
        /// </summary>
        /// <returns>OAuth token</returns>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        Task<string> LoginWithEmailPassword(string email, string password);

        /// <summary>
        /// Create user with email and password.
        /// </summary>
        /// <returns>OAuth token</returns>
        /// <param name="email">Email</param>
        /// <param name="password">Password</param>
        Task<string> CreateUserWithEmailPassword(string email, string password);
    }
}
