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
        Func acf = new Func();
        string gamepath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gamepath = (acf.GetDefaultSteamLibraryPath() + "/common/Shadowverse/").Replace("/","\\");
            label4.Text = gamepath;
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

            if(label2.Text==label5.Text)
            {
                button1.Text = "修改语音";
            }
            else
            {
                button1.Text = "还原语音";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.RootFolder = Environment.SpecialFolder.ProgramFilesX86;
            if (folder.ShowDialog() == DialogResult.OK)
            {
                gamepath = folder.SelectedPath.ToString();
                label4.Text = gamepath;
            }
        }
            

    
    }
}
