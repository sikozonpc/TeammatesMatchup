using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeammatesMatchupLibrary;
using TeammatesMatchupLibrary.Helper;
using TeammatesMatchupLibrary.Models;

namespace TeammatesMatchupWinForms
{
    public partial class dashboardForm : Form
    {
        public string userLane;
        public string REGION;

        private string imageDefaultLibraryIcon = "https://ddragon.leagueoflegends.com/cdn/8.13.1/img/profileicon/";


        public dashboardForm()
        {
            InitializeComponent();

            HideAllBeforeSearchButton();
        
        }

        public void HideAllBeforeSearchButton()
        {
            topLaneProfileIconImage.Visible = false;
            toplaneInfo.Visible = false;
            junglerProfileIconImage.Visible = false;
            jungleInfo.Visible = false;
            midLanerProfileIconImage.Visible = false;
            midlaneInfo.Visible = false;
            bottomProfileIconImage.Visible = false;
            bottomInfo.Visible = false;
            supportProfileIconImage.Visible = false;
            supportInfo.Visible = false;
        }
        public void ShowAllPanels()
        {
            topLaneProfileIconImage.Visible = true;
            toplaneInfo.Visible = true;
            junglerProfileIconImage.Visible = true;
            jungleInfo.Visible = true;
            midLanerProfileIconImage.Visible = true;
            midlaneInfo.Visible = true;
            bottomProfileIconImage.Visible = true;
            bottomInfo.Visible = true;
            supportProfileIconImage.Visible = true;
            supportInfo.Visible = true;
        }

        public void StartNewDashboardWindow(string lane, string userName,string region)
        {
            userLane = lane;
            REGION = region;

            if (lane == "Top Lane")
            {
                toplaneInfo.Visible = false;
                toplanerTextBox.Visible = false;
                lvl1.Visible = false;
                topLaneLvlLabel.Visible = false;

                toplanerLabel.Text = userName;
                toplanerTextBox.Text = userName;
                toplanerLabel.ForeColor = Color.ForestGreen;

                SetTopLanerInfo(userName);

            }
            else if (lane == "Jungle")
            {
                jungleInfo.Visible = false;
                junglerTextBox.Visible = false;
                lvl2.Visible = false;
                junglerLvlLabel.Visible = false;

                junglerLabel.Text = userName;
                junglerTextBox.Text = userName;
                junglerLabel.ForeColor = Color.ForestGreen;

                SetJunglerInfo(userName);
            }
            else if (lane == "Mid Lane")
            {
                midlaneInfo.Visible = false;
                midLanerTextBox.Visible = false;
                lvl3.Visible = false;
                midLanerLvlLabel.Visible = false;

                midlanerLabel.ForeColor = Color.ForestGreen;
                midLanerTextBox.Text = userName;
                midlanerLabel.Text = userName;

                SetMidLanerInfo(userName);
            }
            else if (lane == "Bottom")
            {
                bottomInfo.Visible = false;
                bottomInfo.Visible = false;
                bottomTextBox.Visible = false;
                lvl4.Visible = false;
                bottomLvlLabel.Visible = false;

                bottomLabel.ForeColor = Color.ForestGreen;
                bottomTextBox.Text = userName;
                bottomLabel.Text = userName;

                SetBottomInfo(userName);
            }
            else if (lane == "Support")
            {
                supportInfo.Visible = false;
                supportInfo.Visible = false;
                supportTextBox.Visible = false;
                lvl5.Visible = false;
                supportLvlLabel.Visible = false;

                supportLabel.ForeColor = Color.ForestGreen;
                supportLabel.Text = "Support";
                supportTextBox.Text = userName;

                SetSupportInfo(userName);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {   
            if (userLane != "Top Lane")
            {
                SetTopLanerInfo();
            }
            if (userLane != "Jungle")
            {
                SetJunglerInfo();
            }
            if(userLane != "Mid Lane")
            {
                SetMidLanerInfo();
               
            }
            if(userLane != "Bottom")
            {
                SetBottomInfo();
            }
            if(userLane != "Support")
            {
                SetSupportInfo();
            }

            ShowAllPanels();

            // Checks if the user didn't want the information of some roles so it doesn't show the panels
            if ( toplanerTextBox.Text == "")
            {
                topLaneProfileIconImage.Visible = false;
                toplaneInfo.Visible = false;
            }
            if ( junglerTextBox.Text == "")
            {
                junglerProfileIconImage.Visible = false;
                jungleInfo.Visible = false;
            }
            if ( midLanerTextBox.Text == "")
            {
                midLanerProfileIconImage.Visible = false;
                midlaneInfo.Visible = false;
            }
            if ( bottomTextBox.Text == "")
            {
                bottomProfileIconImage.Visible = false;
                bottomInfo.Visible = false;
            }
            if ( supportTextBox.Text == "")
            {
                supportProfileIconImage.Visible = false;
                supportInfo.Visible = false;
            }
 
        }

        public void SetTopLanerInfo(string userName ="default")
        {
            ApiCalls api = new ApiCalls();
            // Top Laner 
            if (userName== "default")
            {
                userName = toplanerTextBox.Text;
            }

            if (Helper.ValidateSummonerName(userName, REGION) == true)
            {
                SummonerModel summoner1 = api.getSummonerInfo(userName, REGION);
                long topLanerId = api.getSummonerInfo(userName, REGION).Id;
                List<SummonerRankedInfoModel> list = api.getSummonerRankedInfo(topLanerId, REGION);

                string topLanerSoloRank;
                string topLanerSoloDivision;

                string topLanerFlexRank;
                string topLanerFlexDivision;

                topLaneLvlLabel.Text = summoner1.Level.ToString();
                topLaneProfileIconImage.SizeMode = PictureBoxSizeMode.StretchImage;
                topLaneProfileIconImage.ImageLocation = imageDefaultLibraryIcon + summoner1.ProfileIconId + ".png";


                foreach (var i in list)
                {
                    if (i.QueueType == "RANKED_FLEX_SR")
                    {
                        topLanerFlexDivision = i.Rank;
                        topLanerFlexRank = i.Tier;

                        topLanerFlexRankLabel.Text = topLanerFlexRank + " " + topLanerFlexDivision;
                        topLanerFlexRankImage.ImageLocation = SetImageRank(topLanerFlexRank);
                        topLaneFlexWinsLabel.Text = i.Wins.ToString();
                        topLaneFlexLossesLabel.Text = i.Losses.ToString();

                        if (i.HotStreak)
                        {
                            topLaneFlexHotSteak.Text = "(Hot Streak)";
                        }
                        topLaneFlexLeaguePointsLabel.Text = i.LeaguePoints.ToString() + " LP";

                    }
                    else if (i.QueueType == "RANKED_SOLO_5x5")
                    {
                        topLanerSoloRank = i.Tier;
                        topLanerSoloDivision = i.Rank;

                        topLanerSoloRankLabel.Text = topLanerSoloRank + " " + topLanerSoloDivision;
                        topLanerSoloRankImage.ImageLocation = SetImageRank(topLanerSoloRank);
                        topLaneSoloWinLabel.Text = i.Wins.ToString();
                        topLaneSoloLossesLabel.Text = i.Losses.ToString();

                        if (i.HotStreak)
                        {
                            topLaneSoloHotSteak.Text = "(Hot Streak)";
                        }
                        topLaneSoloLeaguePointsLabel.Text = i.LeaguePoints.ToString() + " LP";
                    }
                }
            }
            else
            {
                errorMessageLabel.Text = "Top Lane Summoner name does't exist.";
            }
        }
        public void SetJunglerInfo(string userName = "default")
        {
            ApiCalls api = new ApiCalls();
            // Jungle
            if (userName == "default")
            {
                userName = junglerTextBox.Text;
            }

            if (Helper.ValidateSummonerName(userName, REGION) == true)
            {
                SummonerModel summoner2 = api.getSummonerInfo(userName, REGION);
                long junlgerId = api.getSummonerInfo(userName, REGION).Id;
                List<SummonerRankedInfoModel> list = api.getSummonerRankedInfo(junlgerId, REGION);

                string junglerSoloRank;
                string junglerSoloDivision;

                string junglerFlexRank;
                string junglerFlexDivision;

                junglerLvlLabel.Text = summoner2.Level.ToString();
                junglerProfileIconImage.SizeMode = PictureBoxSizeMode.StretchImage;
                junglerProfileIconImage.ImageLocation = imageDefaultLibraryIcon + summoner2.ProfileIconId + ".png";


                foreach (var i in list)
                {
                    if (i.QueueType == "RANKED_FLEX_SR")
                    {
                        junglerFlexDivision = i.Rank;
                        junglerFlexRank = i.Tier;

                        junglerFlexRankLabel.Text = junglerFlexRank + " " + junglerFlexDivision;
                        junglerFlexRankImage.ImageLocation = SetImageRank(junglerFlexRank);
                        junglerFlexWinsLabel.Text = i.Wins.ToString();
                        junglerFlexLossesLabel.Text = i.Losses.ToString();

                        if (i.HotStreak)
                        {
                            junglerFlexHotSteak.Text = "(Hot Streak)";
                        }
                        junglerFlexLeaguePointsLabel.Text = i.LeaguePoints.ToString() + " LP";

                    }
                    else if (i.QueueType == "RANKED_SOLO_5x5")
                    {
                        junglerSoloRank = i.Tier;
                        junglerSoloDivision = i.Rank;

                        junglerSoloRankLabel.Text = junglerSoloRank + " " + junglerSoloDivision;
                        junglerSoloRankImage.ImageLocation = SetImageRank(junglerSoloRank);
                        junglerSoloWinLabel.Text = i.Wins.ToString();
                        junglerSoloLossesLabel.Text = i.Losses.ToString();

                        if (i.HotStreak)
                        {
                            junglerSoloHotSteak.Text = "(Hot Streak)";
                        }
                        junglerSoloLeaguePointsLabel.Text = i.LeaguePoints.ToString() + " LP";
                    }
                }
            }
            else
            {
                errorMessageLabel.Text = "Jungler Summoner name does't exist.";
            }
        }
        public void SetMidLanerInfo(string userName = "default")
        {
            ApiCalls api = new ApiCalls();
            // Mid Lane 
            if (userName == "default")
            {
                userName = midLanerTextBox.Text;
            }


            if (Helper.ValidateSummonerName(userName, REGION) == true)
            {
                SummonerModel summoner3 = api.getSummonerInfo(userName, REGION);
                long midLanerId = api.getSummonerInfo(userName, REGION).Id;
                List<SummonerRankedInfoModel> list = api.getSummonerRankedInfo(midLanerId, REGION);

                string midLanerSoloRank;
                string midLanerSoloDivision;

                string midLanerFlexRank;
                string midLanerFlexDivision;

                midLanerLvlLabel.Text = summoner3.Level.ToString();
                midLanerProfileIconImage.SizeMode = PictureBoxSizeMode.StretchImage;
                midLanerProfileIconImage.ImageLocation = imageDefaultLibraryIcon + summoner3.ProfileIconId + ".png";


                foreach (var i in list)
                {
                    if (i.QueueType == "RANKED_FLEX_SR")
                    {
                        midLanerFlexDivision = i.Rank;
                        midLanerFlexRank = i.Tier;

                        midLanerFlexRankLabel.Text = midLanerFlexRank + " " + midLanerFlexDivision;
                        midLanerFlexRankImage.ImageLocation = SetImageRank(midLanerFlexRank);
                        midLanerFlexWinsLabel.Text = i.Wins.ToString();
                        midLanerFlexLossesLabel.Text = i.Losses.ToString();

                        if (i.HotStreak)
                        {
                            midLanerFlexHotSteak.Text = "(Hot Streak)";
                        }
                        midLanerFlexLeaguePointsLabel.Text = i.LeaguePoints.ToString() + " LP";

                    }
                    else if (i.QueueType == "RANKED_SOLO_5x5")
                    {
                        midLanerSoloRank = i.Tier;
                        midLanerSoloDivision = i.Rank;

                        midLanerSoloRankLabel.Text = midLanerSoloRank + " " + midLanerSoloDivision;
                        midLanerSoloRankImage.ImageLocation = SetImageRank(midLanerSoloRank);
                        midLanerSoloWinLabel.Text = i.Wins.ToString();
                        midLanerSoloLossesLabel.Text = i.Losses.ToString();

                        if (i.HotStreak)
                        {
                            midLanerSoloHotSteak.Text = "(Hot Streak)";
                        }
                        midLanerSoloLeaguePointsLabel.Text = i.LeaguePoints.ToString() + " LP";
                    }
                }
            }
            else
            {
                errorMessageLabel.Text = "Mid Laner Summoner name does't exist.";
            }
        }
        public void SetBottomInfo(string userName = "default")
        {
            ApiCalls api = new ApiCalls();
            // Bottom  
            if (userName == "default")
            {
                userName = bottomTextBox.Text;
            }

            if (Helper.ValidateSummonerName(userName, REGION) == true)
            {
                SummonerModel summoner4 = api.getSummonerInfo(userName, REGION);
                long bottomId = api.getSummonerInfo(userName,  REGION).Id;
                List<SummonerRankedInfoModel> list = api.getSummonerRankedInfo(bottomId, REGION);

                string bottomSoloRank;
                string bottomSoloDivision;

                string bottomFlexRank;
                string bottomFlexDivision;

                bottomLvlLabel.Text = summoner4.Level.ToString();
                bottomProfileIconImage.SizeMode = PictureBoxSizeMode.StretchImage;
                bottomProfileIconImage.ImageLocation = imageDefaultLibraryIcon + summoner4.ProfileIconId + ".png";


                foreach (var i in list)
                {
                    if (i.QueueType == "RANKED_FLEX_SR")
                    {
                        bottomFlexDivision = i.Rank;
                        bottomFlexRank = i.Tier;

                        bottomFlexRankLabel.Text = bottomFlexRank + " " + bottomFlexDivision;
                        bottomFlexRankImage.ImageLocation = SetImageRank(bottomFlexRank);
                        bottomFlexWinsLabel.Text = i.Wins.ToString();
                        bottomFlexLossesLabel.Text = i.Losses.ToString();

                        if (i.HotStreak)
                        {
                            bottomFlexHotSteak.Text = "(Hot Streak)";
                        }
                        bottomFlexLeaguePointsLabel.Text = i.LeaguePoints.ToString() + " LP";

                    }
                    else if (i.QueueType == "RANKED_SOLO_5x5")
                    {
                        bottomSoloRank = i.Tier;
                        bottomSoloDivision = i.Rank;

                        bottomSoloRankLabel.Text = bottomSoloRank + " " + bottomSoloDivision;
                        bottomSoloRankImage.ImageLocation = SetImageRank(bottomSoloRank);
                        bottomSoloWinLabel.Text = i.Wins.ToString();
                        bottomSoloLossesLabel.Text = i.Losses.ToString();

                        if (i.HotStreak)
                        {
                            bottomSoloHotSteak.Text = "(Hot Streak)";
                        }
                        bottomSoloLeaguePointsLabel.Text = i.LeaguePoints.ToString() + " LP";
                    }
                }
            }
            else
            {
                errorMessageLabel.Text = "Bottom Summoner name does't exist.";
            }
        }
        public void SetSupportInfo(string userName = "default")
        {
            ApiCalls api = new ApiCalls();
            // Suppport  
            if (userName == "default")
            {
                userName = supportTextBox.Text;
            }
            if (Helper.ValidateSummonerName(userName, REGION) == true)
            {
                SummonerModel summoner5 = api.getSummonerInfo(userName, REGION);
                long supportId = api.getSummonerInfo(userName, REGION).Id;
                List<SummonerRankedInfoModel> list = api.getSummonerRankedInfo(supportId, REGION);

                string supportSoloRank;
                string supportSoloDivision;

                string supportFlexRank;
                string supportFlexDivision;

                supportLvlLabel.Text = summoner5.Level.ToString();
                supportProfileIconImage.SizeMode = PictureBoxSizeMode.StretchImage;
                supportProfileIconImage.ImageLocation = imageDefaultLibraryIcon + summoner5.ProfileIconId + ".png";


                foreach (var i in list)
                {
                    if (i.QueueType == "RANKED_FLEX_SR")
                    {
                        supportFlexDivision = i.Rank;
                        supportFlexRank = i.Tier;

                        supportFlexRankLabel.Text = supportFlexRank + " " + supportFlexDivision;
                        supportFlexRankImage.ImageLocation = SetImageRank(supportFlexRank);
                        supportFlexWinsLabel.Text = i.Wins.ToString();
                        supportFlexLossesLabel.Text = i.Losses.ToString();

                        if (i.HotStreak)
                        {
                            supportFlexHotSteak.Text = "(Hot Streak)";
                        }
                        supportFlexLeaguePointsLabel.Text = i.LeaguePoints.ToString() + " LP";

                    }
                    else if (i.QueueType == "RANKED_SOLO_5x5")
                    {
                        supportSoloRank = i.Tier;
                        supportSoloDivision = i.Rank;

                        supportSoloRankLabel.Text = supportSoloRank + " " + supportSoloDivision;
                        supportSoloRankImage.ImageLocation = SetImageRank(supportSoloRank);
                        supportSoloWinLabel.Text = i.Wins.ToString();
                        supportSoloLossesLabel.Text = i.Losses.ToString();

                        if (i.HotStreak)
                        {
                            supportSoloHotSteak.Text = "(Hot Streak)";
                        }
                        supportSoloLeaguePointsLabel.Text = i.LeaguePoints.ToString() + " LP";
                    }
                }
            }
            else
            {
                errorMessageLabel.Text = "Support Summoner name does't exist.";
            }
        }

        public string SetImageRank(string rankName)
        {
            string imagePath;

            if (rankName == "UNRANKED")
            {
                imagePath = "https://i.imgur.com/uqlB4il.png";
                return imagePath;
            }

            else if (rankName == "BRONZE")
            {
                imagePath = "https://i.imgur.com/0kEqPrP.png";
                return imagePath;
            }
            else if (rankName == "SILVER")
            {
                imagePath = "https://i.imgur.com/8HzUceJ.png";
                return imagePath;
            }
            else if (rankName == "GOLD")
            {
                imagePath = "https://i.imgur.com/7czjuc3.png";
                return imagePath;
            }
            else if (rankName == "PLATINUM")
            {
                imagePath = "https://i.imgur.com/OE0Ood4.png";
                return imagePath;
            }
            else if (rankName == "DIAMOND")
            {
                imagePath = "https://i.imgur.com/JoHiJcv.png";
                return imagePath;
            }
            // TODO - set the rest of the images paths 
            else if (rankName == "MASTER")
            {
                imagePath = "";
                return imagePath;
            }
            else
            {
                imagePath = "https://i.imgur.com/uqlB4il.png";
                return imagePath;
            }
        }
    }


    }
