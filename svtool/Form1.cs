using System;
using System.IO;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            gamepath = (acf.GetDefaultSteamLibraryPath() + "/common/Shadowverse").Replace("/","\\");
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
                Button1.Text = "备份语音";
            }
            else
            {
                Button1.Text = "还原语音";
            }
        }

        public void Backupfile(string path, bool d)//d=true 目前是EN备份去EN| d=false则是JP
        {
            string sourcePath = path;
            string targetPath = "";
            string filename = "";
            string destFile = "";
            if (d)
            {
                targetPath = path + "_EN";
            }
            else
            {
                targetPath = path + "_JP";
            }
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            else
            {
                string[] filenames = Directory.GetFiles(sourcePath);
                int progressvalue = 0;
                progressBar1.Maximum = filenames.Length;
                foreach (string s in filenames)
                {
                    filename = Path.GetFileName(s);
                    destFile = Path.Combine(targetPath, filename);
                    File.Copy(s, destFile, true);
                    progressvalue++;
                    progressBar1.Value = progressvalue;
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog()
            {
                RootFolder = Environment.SpecialFolder.ProgramFilesX86
            };
            if (folder.ShowDialog() == DialogResult.OK)
            {
                gamepath = folder.SelectedPath.ToString();
                label4.Text = gamepath;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //按下后先检查目前按钮文字是啥然后决定调用的方法
            if (Button1.Text == "备份语音")
            {//还要检查现在的语言环境
                if (label5.Text == "English")
                {
                    Backupfile(gamepath + "\\Shadowverse_Data\\StreamingAssets\\v", true);
                }
                else
                {
                    Backupfile(gamepath + "\\Shadowverse_Data\\StreamingAssets\\v", false);
                }

            }
            label7.Text = "备份已完成";
        }




    }
}
