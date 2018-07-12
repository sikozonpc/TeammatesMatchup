using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeammatesMatchupLibrary.Models
{
    public class SummonerRankedInfoModel
    {
        public MiniSeriesDTO MiniSeries { get; set; }
        public string LeagueName { get; set; }
        public string Tier { get; set; }
        public string QueueType { get; set; }
        public string Rank { get; set; }
        public bool HotStreak { get; set; }
        public int LeaguePoints { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }

    public class MiniSeriesDTO
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Target { get; set; }
        public string Progress { get; set; }
    }
}
