using FortniteStats.Helpers;
using FortniteStats.Logic;
using FortniteStats.Model;
using FortniteStats.Views;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
            var id = await GetDataLogic.GetID(usernameText);
            activityIndicator.IsRunning = false;
            
            if (id.uid == "error")
            {
                await DisplayAlert("Error", "Could not find username: " + usernameText, "OK");
                search.IsEnabled = true;
                return;
            }
            else if (id.uid == "errornointernet")
            {
                await DisplayAlert("Error", "Could not connect to the Internet. Please check your connection and try again.", "OK");
                search.IsEnabled = true;
                return;
            }
            else
            {
                if(id.platforms.Count > 1)
                {
                    //we have to show alert to choose platform and then call get user stats.
                    await PopupNavigation.Instance.PushAsync(new PlatformPopupPage(id.platforms));
                    var userstats = await GetDataLogic.GetStats(id, PlatformSelected.selectedPlatform);
                    await Navigation.PushAsync(new Stats(userstats, favorites));

                }
                else
                {
                    //we call it without asking because there is only one platform.
                    var userstats = await GetDataLogic.GetStats(id, 0);
                    await Navigation.PushAsync(new Stats(userstats, favorites));
                }
                

                var resultsearch = recents.Contains(id.username);
                if(!resultsearch)
                {
                    recents.Add(id.username);
                    DependencyService.Get<IGetLists>().SetRecents(recents);
                }
                
                
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