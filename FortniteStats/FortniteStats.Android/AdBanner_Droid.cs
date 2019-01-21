﻿using System;
using FortniteStats;
using Android.Gms.Ads;
using FortniteStats.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;

[assembly: ExportRenderer(typeof(AdBanner), typeof(AdBanner_Droid))]
namespace FortniteStats.Droid
{
    public class AdBanner_Droid : ViewRenderer
    {
        public AdBanner_Droid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var adView = new AdView(Context);

                switch ((Element as AdBanner).Size)
                {
                    case AdBanner.Sizes.Standardbanner:
                        adView.AdSize = AdSize.Banner;
                        break;
                    case AdBanner.Sizes.LargeBanner:
                        adView.AdSize = AdSize.LargeBanner;
                        break;
                    case AdBanner.Sizes.MediumRectangle:
                        adView.AdSize = AdSize.MediumRectangle;
                        break;
                    case AdBanner.Sizes.FullBanner:
                        adView.AdSize = AdSize.FullBanner;
                        break;
                    case AdBanner.Sizes.Leaderboard:
                        adView.AdSize = AdSize.Leaderboard;
                        break;
                    case AdBanner.Sizes.SmartBannerPortrait:
                        adView.AdSize = AdSize.SmartBanner;
                        break;
                    default:
                        adView.AdSize = AdSize.Banner;
                        break;
                }

                // TODO: change this id to your admob id
                 adView.AdUnitId = "ca-app-pub-2860697859082710/2092089339";

                //this one below is the demo one
                //adView.AdUnitId = "ca-app-pub-3940256099942544/6300978111";

                var requestbuilder = new AdRequest.Builder();
                requestbuilder.AddTestDevice("8E7EBEA7A3C191F6C58B3B24977A9BE8");
                adView.LoadAd(requestbuilder.Build());

                SetNativeControl(adView);
            }
        }
    }
}
