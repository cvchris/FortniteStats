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
	public partial class TotalsPage : ContentPage
	{
		public TotalsPage (GetStats stats)
		{
			InitializeComponent ();
            WinsTotal.Text = stats.totals.wins.ToString();
            WinrateTotal.Text = stats.totals.winrate.ToString() + "%";
            MatchesPlayedTotal.Text = stats.totals.matchesplayed.ToString();
            ScoreTotal.Text = stats.totals.score.ToString();
            KillsTotal.Text = stats.totals.kills.ToString();
            KDTotal.Text = stats.totals.kd.ToString();
            double hours = Convert.ToDouble(stats.totals.hoursplayed + stats.totals.minutesplayed / 60.0);
            if (hours < 1 )
            {
                HoursPlayedTotal.Text = "Data Error";
            }
            else
            {
                HoursPlayedTotal.Text = hours.ToString();
            }
            
        }
	}
}