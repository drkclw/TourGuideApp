using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Foundation;
using TourGuideApp.iOS.Services;
using TourGuideApp.Services;
using UIKit;

namespace TourGuideApp.iOS
{
    public class IOSModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FirebaseAuthenticatorService>().As<IAuthenticatorService>().SingleInstance();
        }
    }
}