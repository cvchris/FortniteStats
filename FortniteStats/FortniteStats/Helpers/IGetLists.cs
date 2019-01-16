using System;
using System.Collections.Generic;
using System.Text;

namespace FortniteStats.Helpers
{
    public interface IGetLists
    {
        List<String> GetRecents();
        List<String> GetFavorites();
        bool SetRecents(List<String> l);
        bool SetFavorites(List<String> l);
    }
}
