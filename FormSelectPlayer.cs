
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GAMEPROJECTBYCLEAVELANDO
{
	public class FormSelectPlayer : System.Windows.Forms.Form
	{
        private System.Windows.Forms.GroupBox pnlNewPlayer;
        private System.Windows.Forms.GroupBox pnlExisitngPlayer;
        private System.Windows.Forms.ListBox lstofPlayers;
        private System.Windows.Forms.CheckBox chkPrevGame;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private IContainer components;
        private string playerName = string.Empty;
        private bool continueExistingGame = true;
        private Guna.UI.WinForms.GunaButton btnStartPrevGame1;
        private Button btnStartPrevGame;
        private Guna.UI.WinForms.GunaButton btnStartNewGame1;
        private ToolTip playerFormTips;
        private bool newPlayer = false;
		public FormSelectPlayer()
		{
			InitializeComponent();
			
			ArrayList players = PlayerData.GetPlayeruserNames();
			if (players.Count == 0)
			    btnStartPrevGame.Enabled = false;
			else
			    lstofPlayers.DataSource = players;
		}
        
        private void gunaButton1_Click(object sender, System.EventArgs e)
        {
            {
                playerName = lstofPlayers.SelectedItem.ToString();
                continueExistingGame = chkPrevGame.Checked ? true : false;
                playerFormTips.Show("YOU WILL PROCEED AS THE SELECTED PLAYER",btnStartPrevGame1);
                this.Close();

            }
        }
      
        private void btnStartNewGame1_Click(object sender, EventArgs e)
        {
            playerName = txtUserName.Text;
            continueExistingGame = false;

            if (txtUserName.Text == "")
                MessageBox.Show("enter username.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                newPlayer = true;
                playerFormTips.Show("Kindly read through the Instructions", btnStartNewGame1);
                this.Close();
            }
        }

        public string PlayerName
        {
            get { return playerName; }
        }
		
        public bool ContinueExistingGame
        {
            get { return continueExistingGame; }
        }
        
        public bool NewPlayer
        {
            get { return newPlayer; }
        }
        
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.pnlNewPlayer = new System.Windows.Forms.GroupBox();
            this.btnStartNewGame1 = new Guna.UI.WinForms.GunaButton();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pnlExisitngPlayer = new System.Windows.Forms.GroupBox();
            this.btnStartPrevGame1 = new Guna.UI.WinForms.GunaButton();
            this.btnStartPrevGame = new System.Windows.Forms.Button();
            this.chkPrevGame = new System.Windows.Forms.CheckBox();
            this.lstofPlayers = new System.Windows.Forms.ListBox();
            this.playerFormTips = new System.Windows.Forms.ToolTip(this.components);
            this.pnlNewPlayer.SuspendLayout();
            this.pnlExisitngPlayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNewPlayer
            // 
            this.pnlNewPlayer.Controls.Add(this.btnStartNewGame1);
            this.pnlNewPlayer.Controls.Add(this.txtUserName);
            this.pnlNewPlayer.Controls.Add(this.lblUserName);
            this.pnlNewPlayer.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlNewPlayer.Location = new System.Drawing.Point(258, 24);
            this.pnlNewPlayer.Name = "pnlNewPlayer";
            this.pnlNewPlayer.Size = new System.Drawing.Size(258, 241);
            this.pnlNewPlayer.TabIndex = 0;
            this.pnlNewPlayer.TabStop = false;
            this.pnlNewPlayer.Text = "NEW PLAYER PROFILE";
            // 
            // btnStartNewGame1
            // 
            this.btnStartNewGame1.AnimationHoverSpeed = 0.07F;
            this.btnStartNewGame1.AnimationSpeed = 0.03F;
            this.btnStartNewGame1.BackColor = System.Drawing.Color.Transparent;
            this.btnStartNewGame1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnStartNewGame1.BorderColor = System.Drawing.Color.Black;
            this.btnStartNewGame1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStartNewGame1.FocusedColor = System.Drawing.Color.Empty;
            this.btnStartNewGame1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartNewGame1.ForeColor = System.Drawing.Color.Black;
            this.btnStartNewGame1.Image = null;
            this.btnStartNewGame1.ImageSize = new System.Drawing.Size(20, 20);
            this.btnStartNewGame1.Location = new System.Drawing.Point(57, 179);
            this.btnStartNewGame1.Name = "btnStartNewGame1";
            this.btnStartNewGame1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnStartNewGame1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnStartNewGame1.OnHoverForeColor = System.Drawing.Color.White;
            this.btnStartNewGame1.OnHoverImage = null;
            this.btnStartNewGame1.OnPressedColor = System.Drawing.Color.Black;
            this.btnStartNewGame1.Radius = 23;
            this.btnStartNewGame1.Size = new System.Drawing.Size(151, 42);
            this.btnStartNewGame1.TabIndex = 4;
            this.btnStartNewGame1.Text = "PROCEED";
            this.btnStartNewGame1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnStartNewGame1.Click += new System.EventHandler(this.btnStartNewGame1_Click);
            this.btnStartNewGame1.MouseHover += new System.EventHandler(this.btnStartNewGame1_MouseHover);
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(19, 67);
            this.txtUserName.MaxLength = 30;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(233, 23);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Click += new System.EventHandler(this.txtUserName_Click);
            this.txtUserName.MouseHover += new System.EventHandler(this.txtUserName_MouseHover);
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(90, 32);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(80, 16);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User Name:";
            // 
            // pnlExisitngPlayer
            // 
            this.pnlExisitngPlayer.Controls.Add(this.btnStartPrevGame1);
            this.pnlExisitngPlayer.Controls.Add(this.btnStartPrevGame);
            this.pnlExisitngPlayer.Controls.Add(this.chkPrevGame);
            this.pnlExisitngPlayer.Controls.Add(this.lstofPlayers);
            this.pnlExisitngPlayer.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlExisitngPlayer.Location = new System.Drawing.Point(12, 24);
            this.pnlExisitngPlayer.Name = "pnlExisitngPlayer";
            this.pnlExisitngPlayer.Size = new System.Drawing.Size(225, 241);
            this.pnlExisitngPlayer.TabIndex = 1;
            this.pnlExisitngPlayer.TabStop = false;
            this.pnlExisitngPlayer.Text = "EXISTING PLAYER PROFILE";
            this.pnlExisitngPlayer.MouseHover += new System.EventHandler(this.pnlExisitngPlayer_MouseHover);
            // 
            // btnStartPrevGame1
            // 
            this.btnStartPrevGame1.AnimationHoverSpeed = 0.07F;
            this.btnStartPrevGame1.AnimationSpeed = 0.03F;
            this.btnStartPrevGame1.BackColor = System.Drawing.Color.Transparent;
            this.btnStartPrevGame1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnStartPrevGame1.BorderColor = System.Drawing.Color.Black;
            this.btnStartPrevGame1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStartPrevGame1.FocusedColor = System.Drawing.Color.Empty;
            this.btnStartPrevGame1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartPrevGame1.ForeColor = System.Drawing.Color.Black;
            this.btnStartPrevGame1.Image = null;
            this.btnStartPrevGame1.ImageSize = new System.Drawing.Size(20, 20);
            this.btnStartPrevGame1.Location = new System.Drawing.Point(45, 179);
            this.btnStartPrevGame1.Name = "btnStartPrevGame1";
            this.btnStartPrevGame1.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnStartPrevGame1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnStartPrevGame1.OnHoverForeColor = System.Drawing.Color.White;
            this.btnStartPrevGame1.OnHoverImage = null;
            this.btnStartPrevGame1.OnPressedColor = System.Drawing.Color.Black;
            this.btnStartPrevGame1.Radius = 23;
            this.btnStartPrevGame1.Size = new System.Drawing.Size(137, 42);
            this.btnStartPrevGame1.TabIndex = 2;
            this.btnStartPrevGame1.Text = "PROCEED";
            this.btnStartPrevGame1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnStartPrevGame1.Click += new System.EventHandler(this.gunaButton1_Click);
            this.btnStartPrevGame1.MouseHover += new System.EventHandler(this.btnStartPrevGame1_MouseHover);
            // 
            // btnStartPrevGame
            // 
            this.btnStartPrevGame.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartPrevGame.Location = new System.Drawing.Point(101, 188);
            this.btnStartPrevGame.Name = "btnStartPrevGame";
            this.btnStartPrevGame.Size = new System.Drawing.Size(10, 33);
            this.btnStartPrevGame.TabIndex = 2;
            this.btnStartPrevGame.Text = "Start game";
            // 
            // chkPrevGame
            // 
            this.chkPrevGame.Checked = true;
            this.chkPrevGame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrevGame.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrevGame.Location = new System.Drawing.Point(16, 142);
            this.chkPrevGame.Name = "chkPrevGame";
            this.chkPrevGame.Size = new System.Drawing.Size(193, 24);
            this.chkPrevGame.TabIndex = 1;
            this.chkPrevGame.Text = "Continue previous game";
            this.chkPrevGame.CheckedChanged += new System.EventHandler(this.chkPrevGame_CheckedChanged);
            this.chkPrevGame.MouseHover += new System.EventHandler(this.chkPrevGame_MouseHover);
            // 
            // lstofPlayers
            // 
            this.lstofPlayers.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstofPlayers.ItemHeight = 16;
            this.lstofPlayers.Location = new System.Drawing.Point(16, 32);
            this.lstofPlayers.Name = "lstofPlayers";
            this.lstofPlayers.Size = new System.Drawing.Size(193, 84);
            this.lstofPlayers.TabIndex = 0;
            this.lstofPlayers.SelectedIndexChanged += new System.EventHandler(this.lstofPlayers_SelectedIndexChanged);
            this.lstofPlayers.MouseHover += new System.EventHandler(this.lstofPlayers_MouseHover);
            // 
            // FormSelectPlayer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(525, 282);
            this.ControlBox = false;
            this.Controls.Add(this.pnlNewPlayer);
            this.Controls.Add(this.pnlExisitngPlayer);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSelectPlayer";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Player";
            this.pnlNewPlayer.ResumeLayout(false);
            this.pnlNewPlayer.PerformLayout();
            this.pnlExisitngPlayer.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        private void lstofPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstofPlayers_MouseHover(object sender, EventArgs e)
        {
            playerFormTips.Show("list of previous Player profiles", lstofPlayers);
        }

        private void txtUserName_MouseHover(object sender, EventArgs e)
        {
            playerFormTips.Show("Provide a UserName", txtUserName);
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            playerFormTips.Show("Provide a UserName", txtUserName);
        }

        private void pnlExisitngPlayer_MouseHover(object sender, EventArgs e)
        {

        }

        private void btnStartPrevGame1_MouseHover(object sender, EventArgs e)
        {
            playerFormTips.Show("YOU WILL PROCEED AS THE SELECTED PLAYER", btnStartPrevGame1);
        }

        private void btnStartNewGame1_MouseHover(object sender, EventArgs e)
        {
            playerFormTips.Show("Kindly read through the Instructions", btnStartNewGame1);
        }

        private void chkPrevGame_MouseHover(object sender, EventArgs e)
        {
            playerFormTips.Show("continue or begin from level 1", chkPrevGame);
        }

        private void chkPrevGame_CheckedChanged(object sender, EventArgs e)
        {
            playerFormTips.Show("Click Proceed to launch game", chkPrevGame);
        }
    }
}
