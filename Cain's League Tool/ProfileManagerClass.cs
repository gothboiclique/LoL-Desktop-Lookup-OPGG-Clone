using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cain_s_League_Tool
{
    class ProfileManagerClass
    {
        // Summoner Information
        public static List<string> summonerNamesMG { get; set; } = new List<string>();
        public static List<string> summonerLevelsMG { get; set; } = new List<string>();
        public static List<string> summonerIconLinkMG { get; set; } = new List<string>();

        // Summoner TimeStamp (When the profile was saved!)
        public static List<string> summonerProfileTimeStampMG { get; set; } = new List<string>();

        // Champion Information
        public static List<string> topChampionNameMG { get; set; } = new List<string>();
        public static List<string> topChampionPointsMG { get; set; } = new List<string>();
        public static List<string> topChampionLevelMG { get; set; } = new List<string>();

        // Ranked Information
        public static List<string> soloQueueRankMG { get; set; } = new List<string>();
        public static List<string> soloQueueWRMG { get; set; } = new List<string>();

        public static List<string> flexFiveQueueRankMG { get; set; } = new List<string>();
        public static List<string> flexFiveQueueWRMG { get; set; } = new List<string>();

        public static List<string> flexThreeQueueRankMG { get; set; } = new List<string>();
        public static List<string> flexThreeQueueWRMG { get; set; } = new List<string>();

        public static void SaveProfile()
        {
            // Profile
            summonerNamesMG.Add(SummonerInformationClass.summonerName);
            summonerLevelsMG.Add(Convert.ToString(SummonerInformationClass.summonerLevel));
            summonerIconLinkMG.Add(SummonerInformationClass.summonerIconFullLink);

            // Timestamp
            summonerProfileTimeStampMG.Add(DateTime.Now.ToString("dd/mm/yyyy, HH:mm:ss tt"));

            // Champion Mastery
            topChampionNameMG.Add(ChampionIdentifierClass.Identifier(SummonerInformationClass.championMasteries[0].ChampionId));
            topChampionPointsMG.Add(Convert.ToString(SummonerInformationClass.championMasteries[0].ChampionPoints.ToString("##,#")));
            topChampionLevelMG.Add($"Mastery Level: {Convert.ToString(SummonerInformationClass.championMasteries[0].ChampionLevel)}");

            // Ranked
            if (string.IsNullOrEmpty(SummonerInformationClass.soloQRank) || string.IsNullOrEmpty(SummonerInformationClass.soloQWR))
            {
                soloQueueRankMG.Add("-");
                soloQueueWRMG.Add("-");
            }
            else
            {
                soloQueueRankMG.Add(SummonerInformationClass.soloQRank);
                soloQueueWRMG.Add(SummonerInformationClass.soloQWR);
            }

            if (string.IsNullOrEmpty(SummonerInformationClass.flexFiveRank) || string.IsNullOrEmpty(SummonerInformationClass.flexFiveWR))
            {
                flexFiveQueueRankMG.Add("-");
                flexFiveQueueWRMG.Add("-");
            }
            else
            {
                flexFiveQueueRankMG.Add(SummonerInformationClass.flexFiveRank);
                flexFiveQueueWRMG.Add(SummonerInformationClass.flexFiveWR);
            }

            if (string.IsNullOrEmpty(SummonerInformationClass.flexThreeRank) || string.IsNullOrEmpty(SummonerInformationClass.flexThreeWR))
            {
                flexThreeQueueRankMG.Add("-");
                flexThreeQueueWRMG.Add("-");
            }
            else
            {
                flexThreeQueueRankMG.Add(SummonerInformationClass.flexThreeRank);
                flexThreeQueueWRMG.Add(SummonerInformationClass.flexThreeWR);
            }

            System.Windows.Forms.MessageBox.Show("Profile successfully saved!", "Saved!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        //public static void LoadProfile(int i)
        //{
        //    // Not good enough to implement cross class WinForm control :(
        //}

        public static void DeleteProfile(int i)
        {
            summonerNamesMG.RemoveAt(i);
            summonerLevelsMG.RemoveAt(i);
            summonerIconLinkMG.RemoveAt(i);

            summonerProfileTimeStampMG.RemoveAt(i);

            topChampionNameMG.RemoveAt(i);
            topChampionPointsMG.RemoveAt(i);
            topChampionLevelMG.RemoveAt(i);

            soloQueueRankMG.RemoveAt(i);
            soloQueueWRMG.RemoveAt(i);

            flexFiveQueueRankMG.RemoveAt(i);
            flexFiveQueueWRMG.RemoveAt(i);

            flexThreeQueueRankMG.RemoveAt(i);
            flexThreeQueueWRMG.RemoveAt(i);

            System.Windows.Forms.MessageBox.Show("Profile successfully removed!", "Removed!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }
    }
}
