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
        public Form1()
        {
            InitializeComponent();  
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Controls.Add(pictureBox2);
            pictureBox2.Location = new System.Drawing.Point(0, 0);
            pictureBox2.BackColor = Color.Transparent;
        }

        private void ResetValues()
        {
            label2.Text = "-";
            label4.Text = "-";
            label7.Text = "-";
            label8.Text = "-";
            label10.Text = "-";
        }

        private async void SetChampionInformationAsync()
        {
            try
            {
                // Grab Information
                await SummonerInformationClass.GetLeagueRanks();
                await SummonerInformationClass.GetChampionMasteries();
                await SummonerInformationClass.GrabSummonerIconID();
                SummonerInformationClass.GetLeagueStats();

                // Set Information
                label2.Text = Convert.ToString(await SummonerInformationClass.GrabSummonerLevel());
                label4.Text = $"{ChampionIdentifierClass.Identifier(SummonerInformationClass.championMasteries[0].ChampionId)} - {SummonerInformationClass.championMasteries[0].ChampionPoints.ToString("##,#")} - (Mastery: {SummonerInformationClass.championMasteries[0].ChampionLevel})";
                CheckRanks();

                // Set Image
                pictureBox1.Load($"https://ddragon.leagueoflegends.com/cdn/9.2.1/img/profileicon/{SummonerInformationClass.summonerIconID}.png");               
            }
            catch
            {
                pictureBox1.Load($"https://ddragon.leagueoflegends.com/cdn/9.2.1/img/profileicon/0.png");
            }
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
                }

                if (SummonerInformationClass.leagueRanks[i].QueueType.Contains("RANKED_SOLO_5x5"))
                {
                    double a = SummonerInformationClass.leagueRanks[i].Wins;
                    double b = SummonerInformationClass.leagueRanks[i].Losses;
                    double c = a / (a + b) * 100;
                    label8.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(SummonerInformationClass.leagueRanks[i].Tier.ToLower()) + " " + SummonerInformationClass.leagueRanks[i].Rank + " - " + $"({a} / {b}) - " + Math.Round(c, 0) + "%";
                }

                if (SummonerInformationClass.leagueRanks[i].QueueType.Contains("RANKED_FLEX_SR"))
                {
                    double a = SummonerInformationClass.leagueRanks[i].Wins;
                    double b = SummonerInformationClass.leagueRanks[i].Losses;
                    double c = a / (a + b) * 100;
                    label10.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(SummonerInformationClass.leagueRanks[i].Tier.ToLower()) + " " + SummonerInformationClass.leagueRanks[i].Rank + " - " + $"({a} / {b}) - " + Math.Round(c, 0) + "%";
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ResetValues();
            SummonerInformationClass.summonerName = textBox1.Text;
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
    }
}
