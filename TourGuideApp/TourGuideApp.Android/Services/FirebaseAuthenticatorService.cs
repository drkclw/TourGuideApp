using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Auth;
using Microsoft.AppCenter.Crashes;
using TourGuideApp.Services;

namespace TourGuideApp.Droid.Services
{
    public class FirebaseAuthenticatorService : IAuthenticatorService
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;
            }catch(FirebaseAuthInvalidUserException faiuex)
            {
                var properties = new Dictionary<string, string>();
                if (faiuex.Message.Contains("There is no user record corresponding to this identifier"))
                {
                    properties.Add("Where", "Login with email and password.");
                    properties.Add("Issue", "User does not exist.");                    
                }
                else
                {
                    properties.Add("Where", "Login with email and password.");
                    properties.Add("Issue", "Unknown issue.");
                }
                Crashes.TrackError(faiuex, properties);

                return string.Empty;
            }
        }

        public async Task<string> CreateUserWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;
            }
            catch (Exception ex)
            {
                var properties = new Dictionary<string, string>();
                
                    properties.Add("Where", "Create user with email and password.");
                    properties.Add("Issue", "Unknown issue.");
                
                Crashes.TrackError(ex, properties);

                return string.Empty;
            }
        }
    }
}