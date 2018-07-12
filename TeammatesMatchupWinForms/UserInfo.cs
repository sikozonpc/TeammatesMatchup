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

namespace TeammatesMatchupWinForms
{
    public partial class UserInfo : Form
    {
        private string summonerName = "";
        private string lane;
        private string region;


        public UserInfo()
        {
            InitializeComponent();

        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            // New instance of the dashboard
            dashboardForm dashboard = new dashboardForm();
            
            // Reset the error message label
            errorMessageLabel.Text = "";

            //Enum.TryParse( (string)regionsComboBox.SelectedItem, out RegionsEnum region);
            region = (string)regionsComboBox.SelectedItem;
            if (region == null)
            {
                errorMessageLabel.Text = "Please select your region!";
            }

            summonerName = summonerNameTextBox.Text;

            if (Helper.ValidateSummonerName(summonerName, region) == true)
            {
                lane = (string)lanesListBox.SelectedItem;

                if (lane == null)
                {
                    errorMessageLabel.Text =  "Please choose your lane!";
                    return;
                }
                else
                {
                    errorMessageLabel.Text = "Confirmed!";
                }

                dashboard.Show();
                dashboard.StartNewDashboardWindow(lane, summonerNameTextBox.Text, region);
            }
            else
            {
                errorMessageLabel.Text = summonerNameTextBox.Text + " name does not exist in this region.";
            }

        }

    }
}
