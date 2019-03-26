using Autofac;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using TourGuideApp.Services;
using TourGuideApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TourGuideApp
{
    public partial class App : Application
    {
        public IContainer Container { get; }
        public string AuthToken { get; set; }

        public App(Module module)
        {
            InitializeComponent();
            Container = BuildContainer(module);
            MainPage = new NavigationPage(new LoginPage());
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            AppCenter.Start("android={Your Android App secret here};" + 
                "uwp={Your UWP App secret here};" + "ios={Your iOS App secret here}", 
                typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        IContainer BuildContainer(Module module)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<LoginViewModel>().AsSelf();
            builder.RegisterType<NavigationService>().AsSelf().SingleInstance();
            builder.RegisterModule(module);
            return builder.Build();
        }
    }
}
