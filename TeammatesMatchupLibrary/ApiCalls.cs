using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TeammatesMatchupLibrary.Models;

namespace TeammatesMatchupLibrary
{
    public class ApiCalls
    {
        private const string API_KEY = " !!!! YOUR RIOT API KEY !!!!";

        private string summonerProfileInfoCall = ".api.riotgames.com/lol/summoner/v3/summoners/by-name/";
        private string summonerRankedInfoCall = ".api.riotgames.com/lol/league/v3/positions/by-summoner/";
        


        public SummonerModel getSummonerInfo(string summonerName, string region)
        {
            using (WebClient web = new WebClient())
            {
                string call = "https://" + region + summonerProfileInfoCall + summonerName + "?api_key=" + API_KEY;

                string json = web.DownloadString(call);

                var result = JsonConvert.DeserializeObject<JsonSummonerModel.SummonerDTO>(json);
                var convertedResult = Helper.Helper.ConvertSummonerInfoData(result);

                return convertedResult;
            }
        }

        public List<SummonerRankedInfoModel> getSummonerRankedInfo(long summonerId, string region)
        {
            using (WebClient web = new WebClient())
            {
                string call = "https://" + region + summonerRankedInfoCall + summonerId + "?api_key=" + API_KEY;

                string json = web.DownloadString(call);

                var result = JsonConvert.DeserializeObject<List<JsonSummonerRankedInfoModel.Root>>(json);
                var convertedResult = Helper.Helper.ConvertSummonerRankedInfoData(result);

                return convertedResult;
            }
        }
    }
}
