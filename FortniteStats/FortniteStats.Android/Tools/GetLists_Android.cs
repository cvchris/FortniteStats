using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FortniteStats.Droid.Tools;
using FortniteStats.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetLists_Android))]
namespace FortniteStats.Droid.Tools
{
    class GetLists_Android : IGetLists
    {
        public static string folderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal));
        string favoritesPath = Path.Combine(folderPath, "favorites.txt");
        string recentsPath = Path.Combine(folderPath, "recents.txt");

        public List<String> GetRecents()
        {
            if (File.Exists(recentsPath))
            {
                string recentsString = File.ReadAllText(recentsPath);
                List<string> recents = recentsString.Split(',').ToList<string>();
                recents.Reverse();
                return recents;
            }
            else
            {
                //we create an empty list.
                List<string> recents = new List<String>();
                return recents;
            }
            

        }



        public List<String> GetFavorites()
        {

            if (File.Exists(favoritesPath))
            {
                string favoritesString = File.ReadAllText(favoritesPath);
                List<string> favorites = favoritesString.Split(',').ToList<string>();
                favorites.Reverse();
                return favorites;
            }
            else
            {
                //we create an empty list.
                List<string> favorites = new List<String>();
                return favorites;
            }
                
        }

        public bool SetRecents(List<String> l)
        {
            string recentsString = string.Join(",", l);
            File.WriteAllText(recentsPath, recentsString);
            //for debug purposes to clear the recent searches.
            //File.WriteAllText(recentsPath, null);
            return true;
        }
        public bool SetFavorites(List<String> l)
        {
            string favoritesString = string.Join(",", l);
            File.WriteAllText(favoritesPath, favoritesString);
            return true;
        }

    }
}