using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourGuideApp.Models;
using TourGuideApp.Services;
using TourGuideApp.Validators;
using Xamarin.Forms;

namespace TourGuideApp.ViewModels
{
    public class LoginViewModel : BaseModel
    {
        public ValidatableModel<string> Email { get; }
        public ValidatableModel<string> Password { get; }
        public ICommand LoginCmd { get; }
        public bool UserExists { get; set; }

        readonly IAuthenticatorService firebaseAuthenticator;
        readonly NavigationService navigationService;

        Action PropChangedCallBack => (LoginCmd as Command).ChangeCanExecute;

        public LoginViewModel(
            IAuthenticatorService firebaseAuthenticator,
            NavigationService navigationService)
        {
            this.firebaseAuthenticator = firebaseAuthenticator;
            this.navigationService = navigationService;
            UserExists = true;

            LoginCmd = new Command(async () => await Login(), () => Email.IsValid && Password.IsValid && !IsBusy);

            Email = new ValidatableModel<string>(PropChangedCallBack, new EmailValidator()) { Value = "myuser@service.com" };
            Password = new ValidatableModel<string>(PropChangedCallBack, new PasswordValidator()) { Value = "Qwerty123" };            
        }

        async Task Login()
        {
            IsBusy = true;
            PropChangedCallBack();
            var authToken = await firebaseAuthenticator.LoginWithEmailPassword(Email.Value, Password.Value);
            if (string.IsNullOrEmpty(authToken) == false)
            {
                (Application.Current as App).AuthToken = authToken;
                await navigationService.PushAsync(new TourGuidePage());
            }
            else
            {
                UserExists = false;
            }         
            IsBusy = false;
            PropChangedCallBack();
        }

    }
}
