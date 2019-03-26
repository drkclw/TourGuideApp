using Autofac;
using TourGuideApp.Droid.Services;
using TourGuideApp.Services;

namespace TourGuideApp.Droid
{
    public class DroidModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FirebaseAuthenticatorService>().As<IAuthenticatorService>().SingleInstance();
        }
    }
}