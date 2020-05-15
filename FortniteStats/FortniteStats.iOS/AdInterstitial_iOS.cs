using System;
using Google.MobileAds;
using FortniteStats.iOS;
using UIKit;
using Xamarin.Forms;
using System.Linq;
using FortniteStats.Helpers;

[assembly: Dependency(typeof(AdInterstitial_iOS))]
namespace FortniteStats.iOS
{
    public class AdInterstitial_iOS : IAdInterstitial
    {
        Interstitial interstitial;

        public AdInterstitial_iOS()
        {
            LoadAd();
        }

        void LoadAd()
        {
            // TODO: change this id to your admob id
            interstitial = new Interstitial(Secrets.IOS_INTERESTIAL_KEY);

            var request = Request.GetDefaultRequest();
            interstitial.LoadRequest(request);
        }

        public void ShowAd()
        {
            if (interstitial.IsReady)
            {
                interstitial.ScreenDismissed += (s, e) => LoadAd();
                interstitial.PresentFromRootViewController(GetTopViewController());
            }
        }

        public static UIViewController GetTopViewController()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            while (vc.PresentedViewController != null)
                vc = vc.PresentedViewController;

            if (vc is UINavigationController navController)
                vc = navController.ViewControllers.Last();

            return vc;
        }
    }
}
