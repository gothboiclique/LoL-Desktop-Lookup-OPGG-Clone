using RiotNet.Models;
using RiotNet;
using RiotNet.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cain_s_League_Tool
{
    class SummonerInformationClass
    { 
        public static List<ChampionMastery> championMasteries;
        public static List<LeagueEntry> leagueRanks;
        public static string summonerID { get; set; }
        public static long summonerLevel { get; set; }
        public static string summonerPuuid { get; set; }
        public static string summonerName { get; set; }
        public static int summonerLosses { get; set; }
        public static int summonerIconID { get; set; }
        public static int summonerWins { get; set; }
        public static double summonerWinPercentage { get; set; }

        public static async Task<string> GrabSummonerID()
        {
            try
            {
                var summonerid = await RiotClientSetUpClass.client.GetSummonerBySummonerNameAsync(summonerName, PlatformId.EUW1);
                summonerID = summonerid.Id;
                return summonerid.Id;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("There was an error when retrieving information, make sure your name is correct!", "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                return null;
            } 
        }

        public static async Task<long> GrabSummonerLevel()
        {
            var summonerlevel = await RiotClientSetUpClass.client.GetSummonerBySummonerNameAsync(summonerName, PlatformId.EUW1);
            summonerLevel = summonerlevel.SummonerLevel;
            return summonerlevel.SummonerLevel;
        }

        public static async Task<string> GrabSummonerPuuid()
        {
            var summonerpuuid = await RiotClientSetUpClass.client.GetSummonerBySummonerNameAsync(summonerName, PlatformId.EUW1);
            summonerPuuid = summonerpuuid.Puuid;
            return summonerpuuid.Puuid; 
        }
        public static async Task<int> GrabSummonerIconID()
        {
            var summonericon = await RiotClientSetUpClass.client.GetSummonerBySummonerNameAsync(summonerName, PlatformId.EUW1);
            summonerIconID = summonericon.ProfileIconId;
            return summonericon.ProfileIconId;
        }
        public static async Task GetChampionMasteries()
        {
            championMasteries = await RiotClientSetUpClass.client.GetChampionMasteriesAsync(await GrabSummonerID(), PlatformId.EUW1);
        }

        public static async Task GetLeagueRanks()
        {
            leagueRanks = await RiotClientSetUpClass.client.GetLeagueEntriesBySummonerIdAsync(await GrabSummonerID(), PlatformId.EUW1);
        }

        public static void GetLeagueStats()
        {
            summonerLosses = leagueRanks[0].Losses;
            summonerWins = leagueRanks[0].Wins;
            double summonerTotal = summonerWins + summonerLosses;

            summonerWinPercentage = (Convert.ToDouble(summonerWins) / summonerTotal) * 100;
        }
    }
}
