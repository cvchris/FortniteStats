﻿using Android.Gms.Ads;
using FortniteStats.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AdInterstitial_Droid))]
namespace FortniteStats.Droid
{
    public class AdInterstitial_Droid : IAdInterstitial
    {
        InterstitialAd interstitialAd;

        public AdInterstitial_Droid()
        {
            interstitialAd = new InterstitialAd(Android.App.Application.Context);

            // TODO: change this id to your admob id
            interstitialAd.AdUnitId = "ca-app-pub-2860697859082710/3399726488";
            LoadAd();
        }

        void LoadAd()
        {
            var requestbuilder = new AdRequest.Builder();
            interstitialAd.LoadAd(requestbuilder.Build());
        }

        public void ShowAd()
        {
            if (interstitialAd.IsLoaded)
                interstitialAd.Show();

            LoadAd();
        }
    }
}
