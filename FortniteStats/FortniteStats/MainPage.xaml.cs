using FortniteStats.Helpers;
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
        //IAdInterstitial adInterstitial;
        public List<String> favorites = new List<string>();
        public List<String> recents = new List<string>();

        public MainPage()
        {
            InitializeComponent();

            this.search.Clicked += Button_Clicked;
            //recentSearchesList.SeparatorVisibility = SeparatorVisibility.None;
            //adInterstitial = DependencyService.Get<IAdInterstitial>();
        }

        

        private void Button_Clicked(object sender, EventArgs e)
        {
            var user = username.Text;
            searchStats(user);


        }

        public async void searchStats(string usernameText)
        {
            search.IsEnabled = false;
            //adInterstitial.ShowAd();
            activityIndicator.IsRunning = true;
            var id = await GetDataLogic.GetUserStats(usernameText);
            activityIndicator.IsRunning = false;
            if (id.uid == "error")
            {
                await DisplayAlert("Error", "Could not find username: " + usernameText, "OK");
                search.IsEnabled = true;
            }
            else if (id.uid == "errornointernet")
            {
                await DisplayAlert("Error", "Could not connect to the Internet. Please check your connection and try again.", "OK");
                search.IsEnabled = true;
            }
            else
            {
                var resultsearch = recents.Contains(id.username);
                if(!resultsearch)
                {
                    recents.Add(id.username);
                    DependencyService.Get<IGetLists>().SetRecents(recents);
                }
                
                await Navigation.PushAsync(new Stats(id,favorites));
            }

        }

        private void More_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //StatusBox.Color = Color.Green;
            //Status.Text = "UP";
            search.IsEnabled = true;
            recents = DependencyService.Get<IGetLists>().GetRecents();
            recentSearchesList.ItemsSource = recents;
            favorites = DependencyService.Get<IGetLists>().GetFavorites();
            FavoritesListView.ItemsSource = favorites;
        }

        private void RecentSearchesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            recentSearchesList.SelectedItem = null;
        }

        private void FavoritesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            FavoritesListView.SelectedItem = null;
        }

        private void SearchfromList(object sender, ItemTappedEventArgs e)
        {
            var imported = e.Item;
            searchStats(imported.ToString());
        }
    }
}