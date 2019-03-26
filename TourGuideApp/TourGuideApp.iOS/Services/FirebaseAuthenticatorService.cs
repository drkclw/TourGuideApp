using System.Threading.Tasks;
using Firebase.Auth;
using TourGuideApp.Services;

namespace TourGuideApp.iOS.Services
{
    public class FirebaseAuthenticatorService : IAuthenticatorService
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
            return await user.User.GetIdTokenAsync(false);
        }
    }
}