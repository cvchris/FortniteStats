using FortniteStats.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace FortniteStats.Model
{
    public class Data
    {
        public static string GenerateURLID(string username)
        {
            return string.Format(Constants.USER_ID, username);
        }

        public static string GenerateURLStats(string id, string platform)
        {
            return string.Format(Constants.USER_STATS, id, platform);
        }
    }

    public class GetID
    {
        public string uid { get; set; }
        public string username { get; set; }
        public IList<string> platforms { get; set; }
        public IList<string> seasons { get; set; }
    }

    public class Stats
    {
        public int kills_solo { get; set; }
        public int placetop1_solo { get; set; }
        public int placetop10_solo { get; set; }
        public int placetop25_solo { get; set; }
        public int matchesplayed_solo { get; set; }
        public double kd_solo { get; set; }
        public double winrate_solo { get; set; }
        public int score_solo { get; set; }
        public int minutesplayed_solo { get; set; }
        public int lastmodified_solo { get; set; }
        public int kills_duo { get; set; }
        public int placetop1_duo { get; set; }
        public int placetop5_duo { get; set; }
        public int placetop12_duo { get; set; }
        public int matchesplayed_duo { get; set; }
        public double kd_duo { get; set; }
        public double winrate_duo { get; set; }
        public int score_duo { get; set; }
        public int minutesplayed_duo { get; set; }
        public int lastmodified_duo { get; set; }
        public int kills_squad { get; set; }
        public int placetop1_squad { get; set; }
        public int placetop3_squad { get; set; }
        public int placetop6_squad { get; set; }
        public int matchesplayed_squad { get; set; }
        public double kd_squad { get; set; }
        public double winrate_squad { get; set; }
        public int score_squad { get; set; }
        public int minutesplayed_squad { get; set; }
        public int lastmodified_squad { get; set; }
    }

    public class Totals
    {
        public int kills { get; set; }
        public int wins { get; set; }
        public int matchesplayed { get; set; }
        public int minutesplayed { get; set; }
        public int hoursplayed { get; set; }
        public int score { get; set; }
        public double winrate { get; set; }
        public double kd { get; set; }
        public int lastupdate { get; set; }
    }

    public class GetStats
    {
        public bool cached { get; set; }
        public string uid { get; set; }
        public string username { get; set; }
        public string platform { get; set; }
        public int timestamp { get; set; }
        public string window { get; set; }
        public Stats stats { get; set; }
        public Totals totals { get; set; }
        public IList<string> platforms { get; set; }
    }

}
