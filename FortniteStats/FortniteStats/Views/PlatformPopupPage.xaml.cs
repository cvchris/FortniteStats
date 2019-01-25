using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortniteStats.Model;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FortniteStats.Views
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlatformPopupPage : Rg.Plugins.Popup.Pages.PopupPage
	{
        //public int selectedplatform;

		public PlatformPopupPage (IList<string> platforms)
		{
			InitializeComponent ();
            platformPicker.ItemsSource = platforms.ToList();
            platformPicker.Focus();
            //search.Clicked += Button_Clicked;
            

        }

        private async void PlatformPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlatformSelected.selectedPlatform = platformPicker.SelectedIndex;
            await PopupNavigation.Instance.PopAsync();
            //Navigation.PopAsync();
        }
    }
}