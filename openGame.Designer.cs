namespace GAMEPROJECTBYCLEAVELANDO
{
    partial class openGame
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
            this.components = new System.ComponentModel.Container();
            this.prbaropengame = new Guna.UI.WinForms.GunaCircleProgressBar();
            this.btnstart = new Guna.UI.WinForms.GunaButton();
            this.prgbarswitch = new Guna.UI.WinForms.GunaWinSwitch();
            this.prbaropengameTimer = new System.Windows.Forms.Timer(this.components);
            this.btnLaunch = new Guna.UI.WinForms.GunaButton();
            this.SuspendLayout();
            // 
            // prbaropengame
            // 
            this.prbaropengame.AnimationSpeed = 0.6F;
            this.prbaropengame.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.prbaropengame.Font = new System.Drawing.Font("Century Gothic", 50.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prbaropengame.ForeColor = System.Drawing.Color.White;
            this.prbaropengame.IdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(19)))), ((int)(((byte)(35)))));
            this.prbaropengame.IdleOffset = 21;
            this.prbaropengame.IdleThickness = 10;
            this.prbaropengame.Image = null;
            this.prbaropengame.ImageSize = new System.Drawing.Size(52, 52);
            this.prbaropengame.LineEndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.prbaropengame.LineStartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.prbaropengame.Location = new System.Drawing.Point(58, 12);
            this.prbaropengame.Maximum = 300;
            this.prbaropengame.Name = "prbaropengame";
            this.prbaropengame.ProgressMaxColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.prbaropengame.ProgressMinColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.prbaropengame.ProgressOffset = 20;
            this.prbaropengame.ProgressThickness = 40;
            this.prbaropengame.Size = new System.Drawing.Size(350, 350);
            this.prbaropengame.TabIndex = 1;
            this.prbaropengame.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.ClearTypeGridFit;
            this.prbaropengame.UseProgressPercentText = true;
            this.prbaropengame.Value = 200;
            // 
            // btnstart
            // 
            this.btnstart.AnimationHoverSpeed = 0.07F;
            this.btnstart.AnimationSpeed = 0.03F;
            this.btnstart.BackColor = System.Drawing.Color.Transparent;
            this.btnstart.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.btnstart.BorderColor = System.Drawing.Color.Black;
            this.btnstart.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnstart.FocusedColor = System.Drawing.Color.Empty;
            this.btnstart.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstart.ForeColor = System.Drawing.Color.Black;
            this.btnstart.Image = null;
            this.btnstart.ImageSize = new System.Drawing.Size(20, 20);
            this.btnstart.Location = new System.Drawing.Point(12, 382);
            this.btnstart.Name = "btnstart";
            this.btnstart.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnstart.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnstart.OnHoverForeColor = System.Drawing.Color.White;
            this.btnstart.OnHoverImage = null;
            this.btnstart.OnPressedColor = System.Drawing.Color.Black;
            this.btnstart.Radius = 21;
            this.btnstart.Size = new System.Drawing.Size(154, 42);
            this.btnstart.TabIndex = 2;
            this.btnstart.Text = "START GAME";
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // prgbarswitch
            // 
            this.prgbarswitch.BaseColor = System.Drawing.SystemColors.Control;
            this.prgbarswitch.Checked = true;
            this.prgbarswitch.CheckedOffColor = System.Drawing.Color.Black;
            this.prgbarswitch.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.prgbarswitch.FillColor = System.Drawing.Color.White;
            this.prgbarswitch.Location = new System.Drawing.Point(12, 12);
            this.prgbarswitch.Name = "prgbarswitch";
            this.prgbarswitch.Size = new System.Drawing.Size(40, 22);
            this.prgbarswitch.TabIndex = 3;
            this.prgbarswitch.CheckedChanged += new System.EventHandler(this.prgbarswitch_CheckedChanged);
            // 
            // prbaropengameTimer
            // 
            this.prbaropengameTimer.Interval = 50;
            this.prbaropengameTimer.Tick += new System.EventHandler(this.prbaropengameTimer_Tick);
            // 
            // btnLaunch
            // 
            this.btnLaunch.AnimationHoverSpeed = 0.07F;
            this.btnLaunch.AnimationSpeed = 0.03F;
            this.btnLaunch.BackColor = System.Drawing.Color.Transparent;
            this.btnLaunch.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.btnLaunch.BorderColor = System.Drawing.Color.Black;
            this.btnLaunch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLaunch.FocusedColor = System.Drawing.Color.Empty;
            this.btnLaunch.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.ForeColor = System.Drawing.Color.Black;
            this.btnLaunch.Image = null;
            this.btnLaunch.ImageSize = new System.Drawing.Size(20, 20);
            this.btnLaunch.Location = new System.Drawing.Point(262, 382);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnLaunch.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLaunch.OnHoverForeColor = System.Drawing.Color.White;
            this.btnLaunch.OnHoverImage = null;
            this.btnLaunch.OnPressedColor = System.Drawing.Color.Black;
            this.btnLaunch.Radius = 21;
            this.btnLaunch.Size = new System.Drawing.Size(181, 42);
            this.btnLaunch.TabIndex = 4;
            this.btnLaunch.Text = "LAUNCH GAME";
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // openGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(455, 450);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.prgbarswitch);
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.prbaropengame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "openGame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "openGame";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaCircleProgressBar prbaropengame;
        private Guna.UI.WinForms.GunaButton btnstart;
        private Guna.UI.WinForms.GunaWinSwitch prgbarswitch;
        private System.Windows.Forms.Timer prbaropengameTimer;
        private Guna.UI.WinForms.GunaButton btnLaunch;
    }
}