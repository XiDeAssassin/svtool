using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace svtool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Func acf = new Func();
            acf.GetDefaultSteamPath();
            if(acf.LanguageJudge())
            {
                label1.Text = "English";
            }
            else
            {
                label1.Text = "Japanese";
            }
        }
    }
}
