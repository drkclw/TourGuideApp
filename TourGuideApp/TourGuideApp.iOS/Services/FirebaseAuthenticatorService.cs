using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Auth;
using Microsoft.AppCenter.Crashes;
using TourGuideApp.Services;

namespace TourGuideApp.iOS.Services
{
    public class FirebaseAuthenticatorService : IAuthenticatorService
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync(false);
            }
            catch (Exception ex)
            {
                var properties = new Dictionary<string, string>();
                if (ex.Message.Contains("There is no user record corresponding to this identifier"))
                {
                    properties.Add("Where", "Login with email and password.");
                    properties.Add("Issue", "User does not exist.");
                }
                else
                {
                    properties.Add("Where", "Login with email and password.");
                    properties.Add("Issue", "Unknown issue.");
                }
                Crashes.TrackError(ex, properties);

                return string.Empty;
            }
        }

        public async Task<string> CreateUserWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync(false);
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