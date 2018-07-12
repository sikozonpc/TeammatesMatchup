using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeammatesMatchupLibrary.Models
{
    public class SummonerModel
    {
        public long Id { get; set; }
        public string SummonerName { get; set; }
        public int ProfileIconId { get; set; }
        public long Level { get; set; }
    }
}
