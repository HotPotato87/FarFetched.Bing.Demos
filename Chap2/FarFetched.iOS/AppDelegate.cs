using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Touch.Platform;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace FarFetched.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate
    {
        UIWindow window;
        MyViewController viewController;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            viewController = new MyViewController(); 
            window.RootViewController = viewController;

            window.MakeKeyAndVisible();

            return true;
        }
    }
}

