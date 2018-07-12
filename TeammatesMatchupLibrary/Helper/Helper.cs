using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TeammatesMatchupLibrary.Models;

namespace TeammatesMatchupLibrary.Helper
{
    public static class Helper
    {
        private const string API_KEY = " !!!! YOUR RIOT API KEY !!!!";
        private static string API_CALL = ".api.riotgames.com/lol/summoner/v3/summoners/by-name/";
        static string errorMessage;
        static bool gotError = false;

        public static bool ValidateSummonerName(string summonerName, string region)
        {
            string call = "https://" + region + API_CALL + summonerName + "?api_key=" + API_KEY;

            string json;

            using (WebClient web = new WebClient())
            {
                try
                {
                    json = web.DownloadString(call);
                }
                catch
                {
                    errorMessage = "Summoner name does not exit in this region.";
                    gotError = true;

                    return false;
                }

                return true;
               
            }
        }

        public static SummonerModel ConvertSummonerInfoData(JsonSummonerModel.SummonerDTO rootModel)
        {
            SummonerModel model = new SummonerModel();

            model.Id = rootModel.id;
            model.SummonerName = rootModel.name;
            model.Level = rootModel.summonerLevel;
            model.ProfileIconId = rootModel.profileIconId;

            return model;
        }

        public static List<SummonerRankedInfoModel> ConvertSummonerRankedInfoData(List<JsonSummonerRankedInfoModel.Root> rootModel)
        {
            List<SummonerRankedInfoModel> modelList = new List<SummonerRankedInfoModel>();

            foreach(var t in rootModel)
            {
                SummonerRankedInfoModel model = new SummonerRankedInfoModel();

                model.LeagueName = t.leagueName;
                model.LeaguePoints = t.leaguePoints;
                model.Losses = t.losses;
                model.Tier = t.tier;
                model.HotStreak = t.hotStreak;
                model.QueueType = t.queueType;
                model.Rank = t.rank;
                model.Wins = t.wins;

                modelList.Add(model);
            }
            /*
            List<JsonSummonerRankedInfoModel.MiniSeriesDTO> temList = new List<JsonSummonerRankedInfoModel.MiniSeriesDTO>();
            foreach(var i in temList)
            {
                model.MiniSeries.Losses = i.losses;
                model.MiniSeries.Wins = i.wins;
                model.MiniSeries.Progress = i.progress;
                model.MiniSeries.Target = i.target;
            }
            */
            return modelList;
        }


    }
}
