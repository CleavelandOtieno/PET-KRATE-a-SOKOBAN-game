using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GAMEPROJECTBYCLEAVELANDO
{
    public partial class openGame : Form
    {
        public openGame()
        {
            InitializeComponent();
            btnLaunch.Visible = false;
        }

        private void prbaropengameTimer_Tick(object sender, EventArgs e)
        {
            prbaropengame.Increment(1);
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            prbaropengame.Value = 0;
            prbaropengameTimer.Start();
            prbaropengame.Animated = prgbarswitch.Checked;
            btnstart.Visible = false;
            btnLaunch.Visible = true;

        }

        private void prgbarswitch_CheckedChanged(object sender, EventArgs e)
        {
            prbaropengame.Animated = prgbarswitch.Checked;
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Application.Run(new GameUI());
        }
    }
}
