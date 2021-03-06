﻿using FortniteStats.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortniteStats.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FortniteStats.Helpers;

namespace FortniteStats
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Stats : ContentPage
	{
        public GetStats statspublic = new GetStats();
        public List<String> favoritespublic = new List<string>();


		public Stats (GetStats stats,List<String> favorites)
		{
			
			InitializeComponent ();
            statspublic = stats;
            user.Text = stats.username;
            //platformsList.ItemsSource = ;

            favoritespublic = favorites;
            if(favorites.Contains(stats.username))
            {
                FavoriteToolbar.Icon = "starwhite.png";
            }
            else
            {
                FavoriteToolbar.Icon = "starblack.png";
            }



			//if(stats.platforms.Contains("pc"))
   //         {
   //             pc.IsVisible = true;
   //         }
   //         if(stats.platforms.Contains("ps4"))
   //         {
   //             ps4.IsVisible = true;
   //         }
   //         if(stats.platforms.Contains("xbox"))
   //         {
   //             xbox.IsVisible = true;
   //         }


			//for (i = 0; i < stats.platforms.Count(); i++)
			//{
			//	PlatformsGrid.ColumnDefinitions.Add(new ColumnDefinition());
			//}

			//for (i = 0; i < stats.platforms.Count(); i++)
			//{
			//	Grid.SetColumn(pc, i);
			//}


			#region Totals
			WinsTotal.Text = stats.totals.wins.ToString();
			WinrateTotal.Text = stats.totals.winrate.ToString() + "%";
			KillsTotal.Text = stats.totals.kills.ToString();
			KDTotal.Text = stats.totals.kd.ToString();

			#endregion

			#region Solos

			Top1solo.Text = stats.stats.placetop1_solo.ToString();
			Top10solo.Text = stats.stats.placetop10_solo.ToString();
			Killssolo.Text = stats.stats.kills_solo.ToString();
			Winratesolo.Text = stats.stats.winrate_solo.ToString() + "%";
			KDsolo.Text = stats.stats.kd_solo.ToString();


			#endregion

			#region Duos

			Top1duo.Text = stats.stats.placetop1_duo.ToString();
			Top5duo.Text = stats.stats.placetop5_duo.ToString();
			Killsduo.Text = stats.stats.kills_duo.ToString();
			Winrateduo.Text = stats.stats.winrate_duo.ToString() + "%";
			KDduo.Text = stats.stats.kd_duo.ToString();

			#endregion

			#region Squads

			Top1squad.Text = stats.stats.placetop1_squad.ToString();
			Top3squad.Text = stats.stats.placetop3_squad.ToString();
			Killssquad.Text = stats.stats.kills_squad.ToString();
			Winratesquad.Text = stats.stats.winrate_squad.ToString() + "%";
			KDsquad.Text = stats.stats.kd_squad.ToString();

			#endregion

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }

        private void Totals_Tapped(object sender, EventArgs e)
		{
			Navigation.PushAsync(new TotalsPage(statspublic));
		}

        private void Solo_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SoloDuoSquadPage("Solo", statspublic));
        }

        private void Duo_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SoloDuoSquadPage("Duo", statspublic));
        }

        private void Squad_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SoloDuoSquadPage("Squad", statspublic));
        }

        private void FavoriteToolbar_Clicked(object sender, EventArgs e)
        {
            //otherw
            if (favoritespublic.Contains(statspublic.username))
            {
                int countElements = favoritespublic.Count();
                for (int i = 0; i < countElements; i++)
                {
                    //KNOWN BUG: IF THERE IS ONE ELEMENT LEFT AND YOU DELETE THAT THEN IT WILL LEAVE ONE ELEMENT WHICH IS "" AND IF YOU TRY AND DELETE ANOTHER ONE IT WILL CRASH WILL INDEX OUT OF RANGE)
                    if (favoritespublic[i].Equals(statspublic.username))
                    {
                        favoritespublic.RemoveAt(i);
                    }
                }
                
                FavoriteToolbar.Icon = "starblack.png";
            }
            else
            {
                favoritespublic.Add(statspublic.username);
                FavoriteToolbar.Icon = "starwhite.png";
            }
               DependencyService.Get<IGetLists>().SetFavorites(favoritespublic);
        }
    }
}