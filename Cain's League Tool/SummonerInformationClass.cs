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
        // Needs Sorted Info
        public static List<ChampionMastery> championMasteries;
        public static List<LeagueEntry> leagueRanks;
        public static string summonerID { get; set; }
        public static long summonerLevel { get; set; }
        public static string summonerName { get; set; }
        public static int summonerLosses { get; set; }
        public static int summonerIconID { get; set; }
        public static string summonerIconFullLink { get; set; }
        public static int summonerWins { get; set; }

        // Data Grid Info
        public static string soloQRank { get; set; }
        public static string soloQWR { get; set; }

        public static string flexThreeRank { get; set; }
        public static string flexThreeWR { get; set; }

        public static string flexFiveRank { get; set; }
        public static string flexFiveWR { get; set; }


        public static async Task GrabEverything()
        {
            await GrabSummonerID();
            await GrabSummonerLevel();
            await GrabSummonerIconID();
            await GetChampionMasteries();
            await GetLeagueRanks();
        }
        private static async Task<string> GrabSummonerID()
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
        private static async Task<long> GrabSummonerLevel()
        {
            var summonerlevel = await RiotClientSetUpClass.client.GetSummonerBySummonerNameAsync(summonerName, PlatformId.EUW1);
            summonerLevel = summonerlevel.SummonerLevel;
            return summonerlevel.SummonerLevel;
        }
        private static async Task<int> GrabSummonerIconID()
        {
            var summonericon = await RiotClientSetUpClass.client.GetSummonerBySummonerNameAsync(summonerName, PlatformId.EUW1);
            summonerIconID = summonericon.ProfileIconId;
            summonerIconFullLink = $"https://ddragon.leagueoflegends.com/cdn/9.2.1/img/profileicon/{SummonerInformationClass.summonerIconID}.png";
            return summonericon.ProfileIconId;
        }
        private static async Task GetChampionMasteries()
        {
            championMasteries = await RiotClientSetUpClass.client.GetChampionMasteriesAsync(await GrabSummonerID(), PlatformId.EUW1);
        }
        private static async Task GetLeagueRanks()
        {
            leagueRanks = await RiotClientSetUpClass.client.GetLeagueEntriesBySummonerIdAsync(await GrabSummonerID(), PlatformId.EUW1);
        }
    }
}
