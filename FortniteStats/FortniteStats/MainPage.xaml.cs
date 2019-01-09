using FortniteStats.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FortniteStats
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.search.Clicked += Button_Clicked; 
            //recentSearchesList.SeparatorVisibility = SeparatorVisibility.None;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            search.IsEnabled = false;
            activityIndicator.IsRunning = true;
            var user = username.Text;
            var id = await GetDataLogic.GetUserStats(user);
            activityIndicator.IsRunning = false;
            if (id.uid == "error")
            {
                await DisplayAlert("Error", "Could not find username: " + user, "OK");
                search.IsEnabled = true;
            }
            else if(id.uid == "errornointernet")
            {
                await DisplayAlert("Error", "Could not connect to the Internet. Please check your connection and try again.", "OK");
                search.IsEnabled = true;
            }
            else
            {
                
                await Navigation.PushAsync(new Stats(id));
            }
            


        }

        private void More_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            search.IsEnabled = true;
        }
    }
}
