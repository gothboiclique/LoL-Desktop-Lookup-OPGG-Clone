using RiotNet;
using RiotNet.Models;
using System;
using System.Drawing;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cain_s_League_Tool
{
    public partial class Form1 : Form
    {
        // Form Variables
        private static bool canSaveProfile { get; set; }
        // --
        private void ResetValuesLookUp()
        {
            // Reset Values on each search.
            label2.Text = "-";
            label4.Text = "-";
            label7.Text = "-";
            label8.Text = "-";
            label10.Text = "-";

            // Have to reset these to prevent duplicate data grid data submission
            SummonerInformationClass.soloQRank = "";
            SummonerInformationClass.soloQWR = "";
            SummonerInformationClass.flexThreeRank = "";
            SummonerInformationClass.flexThreeWR = "";
            SummonerInformationClass.flexFiveRank = "";
            SummonerInformationClass.flexFiveWR = "";

            // Makes use of the program easier
            textBox1.Clear();
        }
        private void ResetValuesProfile()
        {
            label24.Text = "-";
            label20.Text = "-";
            label16.Text = "-";
            label14.Text = "-";
            label18.Text = "-";
            label23.Text = "-";
            pictureBox3.Load("https://ddragon.leagueoflegends.com/cdn/9.2.1/img/profileicon/0.png");
        }
        private void CheckRanks()
        {
            for (int i = 0; i < SummonerInformationClass.leagueRanks.Count; i++)
            {
                if (SummonerInformationClass.leagueRanks[i].QueueType.Contains("RANKED_FLEX_TT"))
                {
                    double a = SummonerInformationClass.leagueRanks[i].Wins;
                    double b = SummonerInformationClass.leagueRanks[i].Losses;
                    double c = a / (a + b) * 100;
                    label7.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(SummonerInformationClass.leagueRanks[i].Tier.ToLower()) + " " + SummonerInformationClass.leagueRanks[i].Rank + " - " + $"({a} / {b}) - " + Math.Round(c, 0) + "%";
                    SummonerInformationClass.flexThreeRank = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(SummonerInformationClass.leagueRanks[i].Tier.ToLower()) + " " + SummonerInformationClass.leagueRanks[i].Rank;
                    SummonerInformationClass.flexThreeWR = $"({a} / {b}) - " + Math.Round(c, 0) + "%";
                }

                if (SummonerInformationClass.leagueRanks[i].QueueType.Contains("RANKED_SOLO_5x5"))
                {
                    double a = SummonerInformationClass.leagueRanks[i].Wins;
                    double b = SummonerInformationClass.leagueRanks[i].Losses;
                    double c = a / (a + b) * 100;
                    label8.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(SummonerInformationClass.leagueRanks[i].Tier.ToLower()) + " " + SummonerInformationClass.leagueRanks[i].Rank + " - " + $"({a} / {b}) - " + Math.Round(c, 0) + "%";
                    SummonerInformationClass.soloQRank = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(SummonerInformationClass.leagueRanks[i].Tier.ToLower()) + " " + SummonerInformationClass.leagueRanks[i].Rank;
                    SummonerInformationClass.soloQWR = $"({a} / {b}) - " + Math.Round(c, 0) + "%";
                }

                if (SummonerInformationClass.leagueRanks[i].QueueType.Contains("RANKED_FLEX_SR"))
                {
                    double a = SummonerInformationClass.leagueRanks[i].Wins;
                    double b = SummonerInformationClass.leagueRanks[i].Losses;
                    double c = a / (a + b) * 100;
                    label10.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(SummonerInformationClass.leagueRanks[i].Tier.ToLower()) + " " + SummonerInformationClass.leagueRanks[i].Rank + " - " + $"({a} / {b}) - " + Math.Round(c, 0) + "%";
                    SummonerInformationClass.flexFiveRank = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(SummonerInformationClass.leagueRanks[i].Tier.ToLower()) + " " + SummonerInformationClass.leagueRanks[i].Rank;
                    SummonerInformationClass.flexFiveWR = $"({a} / {b}) - " + Math.Round(c, 0) + "%";
                }
            }
        }
        private void LoadProfile(int i)
        {
            label24.Text = ProfileManagerClass.summonerNamesMG[i];
            label20.Text = $"{ProfileManagerClass.topChampionNameMG[i]} - {ProfileManagerClass.topChampionPointsMG[i]} - {ProfileManagerClass.topChampionLevelMG[i]}";
            label16.Text = $"{ProfileManagerClass.soloQueueRankMG[i]} - {ProfileManagerClass.soloQueueWRMG[i]}";
            label14.Text = $"{ProfileManagerClass.flexFiveQueueRankMG[i]} - {ProfileManagerClass.flexFiveQueueWRMG[i]}";
            label18.Text = $"{ProfileManagerClass.flexThreeQueueRankMG[i]} - {ProfileManagerClass.flexThreeQueueWRMG[i]}";
            label23.Text = $"{ProfileManagerClass.summonerProfileTimeStampMG[i]}";
            pictureBox3.Load($"{ProfileManagerClass.summonerIconLinkMG[i]}");
            MessageBox.Show("Profile succesfully loaded!", "Loaded!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private async void SetChampionInformationAsync()
        {
            try
            {
                // Grab Information
                await SummonerInformationClass.GrabEverything();

                // Set Information
                label2.Text = Convert.ToString(SummonerInformationClass.summonerLevel);
                label4.Text = $"{ChampionIdentifierClass.Identifier(SummonerInformationClass.championMasteries[0].ChampionId)} - {SummonerInformationClass.championMasteries[0].ChampionPoints.ToString("##,#")} - (Mastery: {SummonerInformationClass.championMasteries[0].ChampionLevel})";
                CheckRanks();

                // Set Image
                pictureBox1.Load(SummonerInformationClass.summonerIconFullLink);

                // Adds Info to History
                dataGridView1.Rows.Add($"{SummonerInformationClass.summonerName}", $"{SummonerInformationClass.soloQRank}", $"{SummonerInformationClass.soloQWR}", $"{DateTime.Now.ToString("HH:mm:ss tt")}");
            }
            catch
            {
                pictureBox1.Load($"https://ddragon.leagueoflegends.com/cdn/9.2.1/img/profileicon/0.png");
                canSaveProfile = false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Required work around for WinForms "Transparency" Color, Adds border to Image.
            pictureBox1.Controls.Add(pictureBox2);
            pictureBox2.Location = new System.Drawing.Point(0, 0);
            pictureBox2.BackColor = Color.Transparent;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            canSaveProfile = true;
            SummonerInformationClass.summonerName = textBox1.Text;
            ResetValuesLookUp();
            SetChampionInformationAsync();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            // Profile Save
            if (canSaveProfile)
            {
                try
                {
                    // Set Up List box (Index 0 =>)
                    listBox1.Items.Add(SummonerInformationClass.summonerName);

                    // Save Mass Information
                    ProfileManagerClass.SaveProfile();
                }
                catch { MessageBox.Show("Issue saving profile.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            // Profile Load
            try
            {
                // Clears previous profile
                ResetValuesProfile();

                //Loads Selected Profile
                LoadProfile(listBox1.SelectedIndex);
            }
            catch { MessageBox.Show("Issue loading profile.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            // Profile Delete  
            try
            {
                // Clears previous profile
                ResetValuesProfile();
                
                // Deletes selected profile & removes it form listbox
                ProfileManagerClass.DeleteProfile(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            catch { MessageBox.Show("Issue removing profile.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
