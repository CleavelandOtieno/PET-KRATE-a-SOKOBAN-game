using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAMEPROJECTBYCLEAVELANDO
{
    static class program
    {
        [STAThread]
        static void Main3()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new openGame());
        }
    }
}

