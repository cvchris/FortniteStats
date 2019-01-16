using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Foundation;
using UIKit;
using FortniteStats.iOS;
using Xamarin.Forms;
using FortniteStats.Helpers;

[assembly: Dependency(typeof(GetLists_iOS))]
namespace FortniteStats.iOS
{
    class GetLists_iOS : IGetLists
    {
        public static string folderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "..", "Library");
        //public static string fullPath = Path.Combine(folderPath, "config.txt");

        public List<String> GetRecents()
        {
            string recentsPath = Path.Combine(folderPath, "recents.txt");
            string recentsString = File.ReadAllText(recentsPath);
            List<string> recents = recentsString.Split(',').ToList<string>();
            recents.Reverse();
            return recents;
        } 
            
            

    public List<String> GetFavorites()
        {
            string favoritesPath = Path.Combine(folderPath, "favorites.txt");
            string favoritesString = File.ReadAllText(favoritesPath);
            List<string> favorites = favoritesString.Split(',').ToList<string>();
            favorites.Reverse();
            return favorites;
        }

        public bool SetRecents(List<String> l)
        {
            

            return true;
        }
        public bool SetFavorites(List<String> l)
        {

            return true;
        }

        //public bool Set(string baseurl,string webappurl)
        //{
            
        //    string[] config = { baseurl, webappurl };

        //    if (!File.Exists(fullPath))
        //    {
        //        //File.WriteAllLines(fullPath, config);
        //        File.WriteAllLines(fullPath, config, Encoding.UTF8);
        //        //we have to create it and add the values
        //    }
        //    else
        //    {
        //        File.WriteAllLines(fullPath, config);
        //        return true;
        //    }

            
            

        //}
        //public string[] Get()
        //{
        //    if (File.Exists(fullPath))
        //    {
        //        string[] config = File.ReadAllLines(fullPath);
        //        return config;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        //public bool HasConfig()
        //{
        //    if(File.Exists(fullPath))
        //    {
        //        if(File.ReadAllLines(fullPath) != null)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    return false;
        //}
        
    }
}