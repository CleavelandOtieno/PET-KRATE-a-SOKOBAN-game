using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Tulpep.NotificationWindow;

namespace GAMEPROJECTBYCLEAVELANDO
{
	public class GameUI : System.Windows.Forms.Form
    {
        private IContainer components;
        private PlayerData playerData;
        private LevelSet levelSet;
        private Level level;
		private PictureBox screen;
		private Image img;
        private System.Windows.Forms.Label lblMvs;
        private System.Windows.Forms.Label lblMoves;
        private System.Windows.Forms.Label lblPushes;
        private System.Windows.Forms.GroupBox grpMoves;
        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.Label lblLevelNr;
        private Label btnrestart;
        private Label btnendgame;
        private ToolTip gameUITips;
        private System.Windows.Forms.Label lblPshs;
		public GameUI()
		{
			InitializeComponent();
			screen = new PictureBox();
			Controls.AddRange(new Control[] {screen});
            
            InitializeGame();
        }
        private void InitializeGame()
        {
           
            levelSet = new LevelSet();
			FormSelectPlayer formPlayers = new FormSelectPlayer();
			formPlayers.ShowDialog();
            playerData = new PlayerData(formPlayers.PlayerName);
			if (formPlayers.ContinueExistingGame)
			{
			    playerData.LoadLastGameInfo();
			    levelSet.SetLevelSet(playerData.LastPlayedSet);
			    levelSet.CurrentLevel = playerData.LastFinishedLevel + 1;
			    if (levelSet.CurrentLevel > levelSet.NrOfLevelsInSet)
			        levelSet.CurrentLevel = levelSet.NrOfLevelsInSet;

			    levelSet.LastFinishedLevel = playerData.LastFinishedLevel;
			}
			else
			{
                FormSelectLevel formLevels = new FormSelectLevel();
                formLevels.ShowDialog();
                levelSet.SetLevelSet(formLevels.FilenameLevelSet);
                levelSet.CurrentLevel = 1;
                if (formPlayers.NewPlayer)
                    playerData.CreatePlayer(levelSet);
                else
                {
			        playerData.LoadPlayerInfo(levelSet);
		    	    playerData.SaveLevelSet(levelSet);
		    	}
		    }

            lblPlayerName.Text = playerData.Name;
			levelSet.SetLevelsInLevelSet(levelSet.Filename);
			level = (Level)levelSet[levelSet.CurrentLevel - 1];
            DrawLevel();
		}
		private void DrawLevel()
		{
		    int levelWidth = (level.Width + 2) * Level.ITEM_SIZE;
		    int levelHeight = (level.Height + 2) * Level.ITEM_SIZE;
            
            this.ClientSize = new Size(levelWidth + 150, levelHeight);
            screen.Size = new System.Drawing.Size(levelWidth, levelHeight);

            img = level.DrawLevel();
			screen.Image = img;

			lblPlayerName.Location = new Point(levelWidth, 25);
			lblLevelNr.Location = new Point(levelWidth, 65);
			
			grpMoves.Location = new Point(levelWidth + 15, 90);
            lblMvs.Location = new Point(15, 20);
            lblPshs.Location = new Point(15, 36);
            lblMoves.Location = new Point(70, 20);
            lblPushes.Location = new Point(70, 36);
            
            lblMoves.Text = "0";
            lblPushes.Text = "0";
            lblLevelNr.Text = "Level: " + level.LevelNr;
		}
        private void DrawChanges()
        {
            img = level.DrawChanges();
            screen.Image = img;
            lblMoves.Text = level.Moves.ToString();
            lblPushes.Text = level.Pushes.ToString();
        }
        
        
        
        private void DrawUndo()
        {
            if (level.IsUndoable)
            {
                img = level.Undo();
                screen.Image = img;
                lblMoves.Text = level.Moves.ToString();
                lblPushes.Text = level.Pushes.ToString();
            }
        }
		private void AKeyDown(object sender, KeyEventArgs e)
		{
		    string result = e.KeyData.ToString();
		    
		    switch (result)
		    {
		        case "Up":
		            MoveSokoban(MoveDirection.Up);
		            break;
                case "Down":
                    MoveSokoban(MoveDirection.Down);
                    break;
                case "Right":
                    MoveSokoban(MoveDirection.Right);
                    break;
                case "Left":
                    MoveSokoban(MoveDirection.Left);
                    break;
                case "U":
                    DrawUndo();
                    break;
		    }
		}
		public void MoveSokoban(MoveDirection direction)
		{
            
            if (direction == MoveDirection.Up)
            {
                level.MoveSokoban(MoveDirection.Up);
                PopupNotifier pop = new PopupNotifier();
                pop.Image = Properties.Resources.info;
                pop.TitleText = "Pressing Command Key";
                pop.ContentText = "Moving Player Avatar Up!";
                pop.Popup();
            }
            else if (direction == MoveDirection.Down)
            {
                level.MoveSokoban(MoveDirection.Down);
                PopupNotifier pop = new PopupNotifier();
                pop.Image = Properties.Resources.info;
                pop.TitleText = "Pressing Command Key";
                pop.ContentText = "Moving Player Avatar Down!";
                pop.Popup();
            }
            else if (direction == MoveDirection.Right)
            {
                level.MoveSokoban(MoveDirection.Right);
                PopupNotifier pop = new PopupNotifier();
                pop.Image = Properties.Resources.info;
                pop.TitleText = "Pressing Command Keys";
                pop.ContentText = "Moving Player Avatar Right!";
                pop.Popup();
            }
            else if (direction == MoveDirection.Left)
            {
                level.MoveSokoban(MoveDirection.Left);
                PopupNotifier pop = new PopupNotifier();
                pop.Image = Properties.Resources.info;
                pop.TitleText = "Pressing Command Keys";
                pop.ContentText = "Moving Player  Avatar Left!";
                pop.Popup();
            }
            DrawChanges();
		    if (level.IsFinished())
		    {
		        levelSet.LastFinishedLevel = levelSet.CurrentLevel;
	            playerData.SaveLevel(level);
		        
		        if (levelSet.CurrentLevel < levelSet.NrOfLevelsInSet)
		        {
		            MessageBox.Show("Well done!!New Level");
		            levelSet.CurrentLevel++;
		            level = (Level)levelSet[levelSet.CurrentLevel - 1];
		            DrawLevel();
		        }
		        else
		        {
		            MessageBox.Show("That was the last level!");
		            this.Close();
		        }
		    }
		}
        [STAThread]
        static void Main() 
        {
            Application.Run(new GameUI());

        }
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameUI));
            this.lblMvs = new System.Windows.Forms.Label();
            this.lblPshs = new System.Windows.Forms.Label();
            this.lblMoves = new System.Windows.Forms.Label();
            this.lblPushes = new System.Windows.Forms.Label();
            this.grpMoves = new System.Windows.Forms.GroupBox();
            this.btnendgame = new System.Windows.Forms.Label();
            this.btnrestart = new System.Windows.Forms.Label();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.lblLevelNr = new System.Windows.Forms.Label();
            this.gameUITips = new System.Windows.Forms.ToolTip(this.components);
            this.grpMoves.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMvs
            // 
            this.lblMvs.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMvs.ForeColor = System.Drawing.Color.Black;
            this.lblMvs.Location = new System.Drawing.Point(16, 24);
            this.lblMvs.Name = "lblMvs";
            this.lblMvs.Size = new System.Drawing.Size(52, 17);
            this.lblMvs.TabIndex = 0;
            this.lblMvs.Text = "Moves:";
            // 
            // lblPshs
            // 
            this.lblPshs.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPshs.ForeColor = System.Drawing.Color.Black;
            this.lblPshs.Location = new System.Drawing.Point(16, 40);
            this.lblPshs.Name = "lblPshs";
            this.lblPshs.Size = new System.Drawing.Size(52, 16);
            this.lblPshs.TabIndex = 1;
            this.lblPshs.Text = "Pushes:";
            // 
            // lblMoves
            // 
            this.lblMoves.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoves.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMoves.Location = new System.Drawing.Point(72, 24);
            this.lblMoves.Name = "lblMoves";
            this.lblMoves.Size = new System.Drawing.Size(44, 16);
            this.lblMoves.TabIndex = 2;
            this.lblMoves.Click += new System.EventHandler(this.lblMoves_Click);
            this.lblMoves.MouseHover += new System.EventHandler(this.lblMoves_MouseHover);
            // 
            // lblPushes
            // 
            this.lblPushes.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPushes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPushes.Location = new System.Drawing.Point(64, 40);
            this.lblPushes.Name = "lblPushes";
            this.lblPushes.Size = new System.Drawing.Size(44, 16);
            this.lblPushes.TabIndex = 3;
            this.lblPushes.Click += new System.EventHandler(this.lblPushes_Click);
            this.lblPushes.MouseHover += new System.EventHandler(this.lblPushes_MouseHover);
            // 
            // grpMoves
            // 
            this.grpMoves.Controls.Add(this.btnendgame);
            this.grpMoves.Controls.Add(this.btnrestart);
            this.grpMoves.Controls.Add(this.lblPshs);
            this.grpMoves.Controls.Add(this.lblMvs);
            this.grpMoves.Controls.Add(this.lblMoves);
            this.grpMoves.Controls.Add(this.lblPushes);
            this.grpMoves.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMoves.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.grpMoves.Location = new System.Drawing.Point(40, 56);
            this.grpMoves.Name = "grpMoves";
            this.grpMoves.Size = new System.Drawing.Size(140, 142);
            this.grpMoves.TabIndex = 4;
            this.grpMoves.TabStop = false;
            // 
            // btnendgame
            // 
            this.btnendgame.AutoSize = true;
            this.btnendgame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnendgame.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnendgame.Font = new System.Drawing.Font("Copperplate Gothic Bold", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnendgame.ForeColor = System.Drawing.Color.Black;
            this.btnendgame.Image = ((System.Drawing.Image)(resources.GetObject("btnendgame.Image")));
            this.btnendgame.Location = new System.Drawing.Point(7, 102);
            this.btnendgame.Name = "btnendgame";
            this.btnendgame.Size = new System.Drawing.Size(127, 23);
            this.btnendgame.TabIndex = 6;
            this.btnendgame.Text = "END GAME";
            this.btnendgame.Click += new System.EventHandler(this.btnendgame_Click);
            // 
            // btnrestart
            // 
            this.btnrestart.AutoSize = true;
            this.btnrestart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnrestart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnrestart.Font = new System.Drawing.Font("Copperplate Gothic Bold", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrestart.ForeColor = System.Drawing.Color.Black;
            this.btnrestart.Image = ((System.Drawing.Image)(resources.GetObject("btnrestart.Image")));
            this.btnrestart.Location = new System.Drawing.Point(11, 66);
            this.btnrestart.Name = "btnrestart";
            this.btnrestart.Size = new System.Drawing.Size(122, 26);
            this.btnrestart.TabIndex = 5;
            this.btnrestart.Text = "RESTART";
            this.btnrestart.Click += new System.EventHandler(this.btnrestart_Click);
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.ForeColor = System.Drawing.Color.Black;
            this.lblPlayerName.Location = new System.Drawing.Point(80, 16);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(150, 24);
            this.lblPlayerName.TabIndex = 4;
            this.lblPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLevelNr
            // 
            this.lblLevelNr.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLevelNr.ForeColor = System.Drawing.Color.Black;
            this.lblLevelNr.Location = new System.Drawing.Point(168, 48);
            this.lblLevelNr.Name = "lblLevelNr";
            this.lblLevelNr.Size = new System.Drawing.Size(150, 16);
            this.lblLevelNr.TabIndex = 4;
            this.lblLevelNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(442, 196);
            this.ControlBox = false;
            this.Controls.Add(this.grpMoves);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.lblLevelNr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameUI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.Load += new System.EventHandler(this.GameUI_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AKeyDown);
            this.grpMoves.ResumeLayout(false);
            this.grpMoves.PerformLayout();
            this.ResumeLayout(false);

        }
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        private void lblMoves_Click(object sender, EventArgs e)
        {
            gameUITips.Show("Number of Moves.", lblMoves);
        }

        private void lblMoves_MouseHover(object sender, EventArgs e)
        {
            gameUITips.Show("Number of Moves.", lblMoves);
        }

        private void lblPushes_Click(object sender, EventArgs e)
        {
            gameUITips.Show("Number of Pushes.", lblPushes);
        }

        private void lblPushes_MouseHover(object sender, EventArgs e)
        {
            gameUITips.Show("Number of Pushes.", lblPushes);
        }

        private void GameUI_Load(object sender, EventArgs e)
        {

        }

        private void btnrestart_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            Application.Run(new GameUI());

        }

        private void btnendgame_Click(object sender, EventArgs e)
        {
            this.Dispose();
            FormSelectPlayer fsp = new FormSelectPlayer();
        }
    }
}
