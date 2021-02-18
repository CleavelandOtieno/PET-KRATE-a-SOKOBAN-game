
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace GAMEPROJECTBYCLEAVELANDO
{

	public class FormSelectLevel : System.Windows.Forms.Form
    {
        private IContainer components;
        private System.Windows.Forms.ListBox lstLevelSets;
        private System.Windows.Forms.Label lblDescriptionH;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblNrOfLevels;
        private System.Windows.Forms.Label lblNrOfLevelsH;
		
		private ArrayList levelSets = new ArrayList();
		private string filenameLevelSet = string.Empty;
        private Guna.UI.WinForms.GunaButton btnStartGameplay;
        private ToolTip levelFormTips;
        private string nameLevelSet = string.Empty;
		public FormSelectLevel()
		{
			InitializeComponent();
            levelSets = LevelSet.GetAllLevelSetInfos();
            foreach (LevelSet levelSet in levelSets)
                lstLevelSets.Items.Add(levelSet.Title);
            
            lstLevelSets.SelectedIndex = 0;
		}
        private void lstLevelSets_SelectedIndexChanged(object sender,
            System.EventArgs e)
        {
            int index = lstLevelSets.SelectedIndex;
            LevelSet levelSet = (LevelSet)levelSets[index];
            lblDescription.Text = levelSet.Description;
            lblNrOfLevels.Text = levelSet.NrOfLevelsInSet.ToString();
        }
        
        public string FilenameLevelSet
        {
            get { return filenameLevelSet; }
        }
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.lstLevelSets = new System.Windows.Forms.ListBox();
            this.lblDescriptionH = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblNrOfLevels = new System.Windows.Forms.Label();
            this.lblNrOfLevelsH = new System.Windows.Forms.Label();
            this.btnStartGameplay = new Guna.UI.WinForms.GunaButton();
            this.levelFormTips = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lstLevelSets
            // 
            this.lstLevelSets.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLevelSets.ItemHeight = 16;
            this.lstLevelSets.Location = new System.Drawing.Point(15, 227);
            this.lstLevelSets.Name = "lstLevelSets";
            this.lstLevelSets.Size = new System.Drawing.Size(242, 36);
            this.lstLevelSets.TabIndex = 0;
            this.lstLevelSets.Click += new System.EventHandler(this.lstLevelSets_Click);
            this.lstLevelSets.SelectedIndexChanged += new System.EventHandler(this.lstLevelSets_SelectedIndexChanged);
            this.lstLevelSets.MouseHover += new System.EventHandler(this.lstLevelSets_MouseHover);
            // 
            // lblDescriptionH
            // 
            this.lblDescriptionH.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescriptionH.Location = new System.Drawing.Point(72, 45);
            this.lblDescriptionH.Name = "lblDescriptionH";
            this.lblDescriptionH.Size = new System.Drawing.Size(104, 16);
            this.lblDescriptionH.TabIndex = 3;
            this.lblDescriptionH.Text = "Description:";
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(9, 75);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(248, 88);
            this.lblDescription.TabIndex = 11;
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDescription.Click += new System.EventHandler(this.lblDescription_Click);
            this.lblDescription.MouseHover += new System.EventHandler(this.lblDescription_MouseHover);
            // 
            // lblNrOfLevels
            // 
            this.lblNrOfLevels.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNrOfLevels.Location = new System.Drawing.Point(98, 9);
            this.lblNrOfLevels.Name = "lblNrOfLevels";
            this.lblNrOfLevels.Size = new System.Drawing.Size(145, 16);
            this.lblNrOfLevels.TabIndex = 14;
            this.lblNrOfLevels.Click += new System.EventHandler(this.lblNrOfLevels_Click);
            this.lblNrOfLevels.MouseHover += new System.EventHandler(this.lblNrOfLevels_MouseHover);
            // 
            // lblNrOfLevelsH
            // 
            this.lblNrOfLevelsH.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNrOfLevelsH.Location = new System.Drawing.Point(12, 9);
            this.lblNrOfLevelsH.Name = "lblNrOfLevelsH";
            this.lblNrOfLevelsH.Size = new System.Drawing.Size(80, 16);
            this.lblNrOfLevelsH.TabIndex = 13;
            this.lblNrOfLevelsH.Text = "Level count:";
            // 
            // btnStartGameplay
            // 
            this.btnStartGameplay.AnimationHoverSpeed = 0.07F;
            this.btnStartGameplay.AnimationSpeed = 0.03F;
            this.btnStartGameplay.BackColor = System.Drawing.Color.Transparent;
            this.btnStartGameplay.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.btnStartGameplay.BorderColor = System.Drawing.Color.Black;
            this.btnStartGameplay.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStartGameplay.FocusedColor = System.Drawing.Color.Empty;
            this.btnStartGameplay.Font = new System.Drawing.Font("Copperplate Gothic Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartGameplay.ForeColor = System.Drawing.Color.Black;
            this.btnStartGameplay.Image = null;
            this.btnStartGameplay.ImageSize = new System.Drawing.Size(20, 20);
            this.btnStartGameplay.Location = new System.Drawing.Point(61, 179);
            this.btnStartGameplay.Name = "btnStartGameplay";
            this.btnStartGameplay.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnStartGameplay.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnStartGameplay.OnHoverForeColor = System.Drawing.Color.White;
            this.btnStartGameplay.OnHoverImage = null;
            this.btnStartGameplay.OnPressedColor = System.Drawing.Color.Black;
            this.btnStartGameplay.Radius = 23;
            this.btnStartGameplay.Size = new System.Drawing.Size(137, 42);
            this.btnStartGameplay.TabIndex = 15;
            this.btnStartGameplay.Text = "PLAY";
            this.btnStartGameplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnStartGameplay.Click += new System.EventHandler(this.btnStartGameplay_Click);
            this.btnStartGameplay.MouseHover += new System.EventHandler(this.btnStartGameplay_MouseHover);
            // 
            // FormSelectLevel
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(263, 263);
            this.ControlBox = false;
            this.Controls.Add(this.btnStartGameplay);
            this.Controls.Add(this.lblNrOfLevels);
            this.Controls.Add(this.lblNrOfLevelsH);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblDescriptionH);
            this.Controls.Add(this.lstLevelSets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormSelectLevel";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "selected level";
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

        private void btnStartGameplay_Click(object sender, EventArgs e)
        {
            nameLevelSet = lstLevelSets.SelectedItem.ToString();

            foreach (LevelSet levelSet in levelSets)
            {
                if (levelSet.Title == nameLevelSet)
                {
                    filenameLevelSet = levelSet.Filename;
                    break;
                }
            }

            this.Close();
        }

        private void lblDescription_MouseHover(object sender, EventArgs e)
        {
            levelFormTips.Show("Instructions of how to play the game.", lblDescription);
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {
            levelFormTips.Show("Instructions of how to play the game.", lblDescription);
        }

        private void lblNrOfLevels_Click(object sender, EventArgs e)
        {
            levelFormTips.Show("Number of Levels to be Comleted.", lblNrOfLevels);
        }

        private void lblNrOfLevels_MouseHover(object sender, EventArgs e)
        {
            levelFormTips.Show("Number of Levels to be Comleted.", lblNrOfLevels);
        }

        private void btnStartGameplay_MouseHover(object sender, EventArgs e)
        {
            levelFormTips.Show("Agreed to begin the game.", btnStartGameplay);
        }

        private void lstLevelSets_Click(object sender, EventArgs e)
        {
            levelFormTips.Show("Ownership Copyright.", lstLevelSets);
        }

        private void lstLevelSets_MouseHover(object sender, EventArgs e)
        {
            levelFormTips.Show("Ownership Copyright.", lstLevelSets);
        }
    }
}
