using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeammatesMatchupLibrary.Models
{
    public class JsonSummonerRankedInfoModel
    {
        public class MiniSeriesDTO
        {
            public int wins { get; set; }
            public int losses { get; set; }
            public int target { get; set; }
            public string progress { get; set; }
        }

        public class Root
        {
            public List<MiniSeriesDTO> MiniSeries { get; set; }
            public string leagueName { get; set; }
            public string tier { get; set; }
            public string queueType { get; set; }
            public string rank { get; set; }
            public bool hotStreak { get; set; }
            public int leaguePoints { get; set; }
            public int wins { get; set; }
            public int losses { get; set; }
        }

    }
}
