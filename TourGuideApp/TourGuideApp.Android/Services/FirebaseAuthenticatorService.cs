using System.Threading.Tasks;
using Firebase.Auth;
using TourGuideApp.Services;

namespace TourGuideApp.Droid.Services
{
    public class FirebaseAuthenticatorService : IAuthenticatorService
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var token = await user.User.GetIdTokenAsync(false);
            return token.Token;
        }
    }
}