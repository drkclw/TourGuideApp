using Autofac;
using TourGuideApp.ViewModels;
using Xamarin.Forms;

namespace TourGuideApp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = (Application.Current as App).Container.Resolve<LoginViewModel>();
        }
    }
}
