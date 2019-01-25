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
        public GetID publicid = new GetID();

        public MainPage()
        {
            InitializeComponent();
            platformselect.HeightRequest = 0;
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
            publicid = id;
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
                    platformselect.ItemsSource = publicid.platforms.ToList();
                    //we have to show alert to choose platform and then call get user stats.
                    //await PopupNavigation.Instance.PushAsync(new PlatformPopupPage(id.platforms));
                    //platformselect.HeightRequest = -1;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (platformselect.IsFocused)
                            platformselect.Unfocus();

                        platformselect.Focus();
                    });


                    //platformselect.Focus();
                    //await DisplayAlert("hi", platformselect.SelectedIndex.ToString(), "ok");
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

        private async void Platformselect_SelectedIndexChanged(object sender, EventArgs e)
        {
            //the second time it doesnt show the picker and it automatically enters -1... it returns null exception. Has to be investigated.
            //platformselect.Unfocus();
            var userstats = await GetDataLogic.GetStats(publicid, platformselect.SelectedIndex);
            await Navigation.PushAsync(new Stats(userstats, favorites));
        }
    }
}