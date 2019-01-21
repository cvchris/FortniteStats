using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortniteStats.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FortniteStats.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SoloDuoSquadPage : ContentPage
	{
		public SoloDuoSquadPage (string mode,GetStats stats)
		{
			InitializeComponent ();
            Title = mode;
            double hours;
            if(mode == "Solo")
            {
                Top1.Text = stats.stats.placetop1_solo.ToString();
                Top2.Text = stats.stats.placetop10_solo.ToString();
                Top2Text.Text = "Top 10";
                Top3.Text = stats.stats.placetop25_solo.ToString();
                Top3Text.Text = "Top 25";
                kills.Text = stats.stats.kills_solo.ToString();
                winrate.Text = stats.stats.winrate_solo.ToString() + "%";
                KD.Text = stats.stats.kd_solo.ToString();
                MatchesPlayed.Text = stats.stats.matchesplayed_solo.ToString();
                hours = stats.stats.minutesplayed_solo / 60.0;
                if (hours < 1)
                {
                    HoursPlayed.Text = "Data Error";
                }
                else
                {
                    HoursPlayed.Text = (hours).ToString();
                }
                
                Score.Text = stats.stats.score_solo.ToString();


            }
            else if(mode == "Duo")
            {
                Top1.Text = stats.stats.placetop1_duo.ToString();
                Top2.Text = stats.stats.placetop5_duo.ToString();
                Top2Text.Text = "Top 5";
                Top3.Text = stats.stats.placetop12_duo.ToString();
                Top3Text.Text = "Top 12";
                kills.Text = stats.stats.kills_duo.ToString();
                winrate.Text = stats.stats.winrate_duo.ToString() + "%";
                KD.Text = stats.stats.kd_duo.ToString();
                MatchesPlayed.Text = stats.stats.matchesplayed_duo.ToString();
                hours = stats.stats.minutesplayed_duo / 60.0;
                if (hours < 1)
                {
                    HoursPlayed.Text = "Data Error";
                }
                else
                {
                    HoursPlayed.Text = (hours).ToString();
                }
                Score.Text = stats.stats.score_duo.ToString();
            }
            else
            {
                Top1.Text = stats.stats.placetop1_squad.ToString();
                Top2.Text = stats.stats.placetop3_squad.ToString();
                Top2Text.Text = "Top 3";
                Top3.Text = stats.stats.placetop6_squad.ToString();
                Top3Text.Text = "Top 6";
                kills.Text = stats.stats.kills_squad.ToString();
                winrate.Text = stats.stats.winrate_squad.ToString() + "%";
                KD.Text = stats.stats.kd_squad.ToString();
                MatchesPlayed.Text = stats.stats.matchesplayed_squad.ToString();
                hours = stats.stats.minutesplayed_squad / 60.0;
                if (hours < 1)
                {
                    HoursPlayed.Text = "Data Error";
                }
                else
                {
                    HoursPlayed.Text = (hours).ToString();
                }
                Score.Text = stats.stats.score_squad.ToString();
            }

		}
	}
}