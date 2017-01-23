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
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Func acf = new Func();
            acf.GetDefaultSteamPath();
            label4.Text = (acf.GetDefaultSteamPath() + "/common/Shadowverse").Replace("/","\\");
            if (acf.LanguageJudge())
            {
                label2.Text = "English";
            }
            else
            {
                label2.Text = "Japanese";
            }

            if (acf.VoiceJudge())
            {
                label5.Text = "English";
            }
            else
            {
                label5.Text = "Japanese";
            }

            if (!acf.VoiceJudge())
            {
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }
    }
}
