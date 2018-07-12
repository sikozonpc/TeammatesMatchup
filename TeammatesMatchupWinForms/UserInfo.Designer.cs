namespace TeammatesMatchupWinForms
{
    partial class UserInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfo));
            this.userNameLabel = new System.Windows.Forms.Label();
            this.summonerNameTextBox = new System.Windows.Forms.TextBox();
            this.laneLabel = new System.Windows.Forms.Label();
            this.lanesListBox = new System.Windows.Forms.ListBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.errorMessageLabel = new System.Windows.Forms.Label();
            this.regionabel = new System.Windows.Forms.Label();
            this.regionsComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLabel.Location = new System.Drawing.Point(55, 25);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(160, 24);
            this.userNameLabel.TabIndex = 0;
            this.userNameLabel.Text = "Summoner Name";
            // 
            // summonerNameTextBox
            // 
            this.summonerNameTextBox.Location = new System.Drawing.Point(37, 70);
            this.summonerNameTextBox.Name = "summonerNameTextBox";
            this.summonerNameTextBox.Size = new System.Drawing.Size(196, 20);
            this.summonerNameTextBox.TabIndex = 1;
            // 
            // laneLabel
            // 
            this.laneLabel.AutoSize = true;
            this.laneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laneLabel.Location = new System.Drawing.Point(286, 18);
            this.laneLabel.Name = "laneLabel";
            this.laneLabel.Size = new System.Drawing.Size(121, 24);
            this.laneLabel.TabIndex = 2;
            this.laneLabel.Text = "Your Position";
            // 
            // lanesListBox
            // 
            this.lanesListBox.FormattingEnabled = true;
            this.lanesListBox.Items.AddRange(new object[] {
            "Top Lane",
            "Jungle",
            "Mid Lane",
            "Bottom",
            "Support"});
            this.lanesListBox.Location = new System.Drawing.Point(261, 45);
            this.lanesListBox.Name = "lanesListBox";
            this.lanesListBox.Size = new System.Drawing.Size(192, 82);
            this.lanesListBox.TabIndex = 3;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(155, 143);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(152, 31);
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = "Continue";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // errorMessageLabel
            // 
            this.errorMessageLabel.AutoSize = true;
            this.errorMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorMessageLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errorMessageLabel.Location = new System.Drawing.Point(171, 186);
            this.errorMessageLabel.Name = "errorMessageLabel";
            this.errorMessageLabel.Size = new System.Drawing.Size(0, 16);
            this.errorMessageLabel.TabIndex = 5;
            // 
            // regionabel
            // 
            this.regionabel.AutoSize = true;
            this.regionabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regionabel.Location = new System.Drawing.Point(33, 103);
            this.regionabel.Name = "regionabel";
            this.regionabel.Size = new System.Drawing.Size(71, 24);
            this.regionabel.TabIndex = 7;
            this.regionabel.Text = "Region";
            // 
            // regionsComboBox
            // 
            this.regionsComboBox.FormattingEnabled = true;
            this.regionsComboBox.Items.AddRange(new object[] {
            "euw1",
            "na1",
            "br1",
            "eun1",
            "jp1",
            "kr",
            "la1",
            "la2",
            "oc1",
            "tr1",
            "ru",
            "pbe1"});
            this.regionsComboBox.Location = new System.Drawing.Point(111, 105);
            this.regionsComboBox.Name = "regionsComboBox";
            this.regionsComboBox.Size = new System.Drawing.Size(60, 21);
            this.regionsComboBox.TabIndex = 8;
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 228);
            this.Controls.Add(this.regionsComboBox);
            this.Controls.Add(this.regionabel);
            this.Controls.Add(this.errorMessageLabel);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.lanesListBox);
            this.Controls.Add(this.laneLabel);
            this.Controls.Add(this.summonerNameTextBox);
            this.Controls.Add(this.userNameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserInfo";
            this.Text = "UserInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.TextBox summonerNameTextBox;
        private System.Windows.Forms.Label laneLabel;
        private System.Windows.Forms.ListBox lanesListBox;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label errorMessageLabel;
        private System.Windows.Forms.Label regionabel;
        private System.Windows.Forms.ComboBox regionsComboBox;
    }
}