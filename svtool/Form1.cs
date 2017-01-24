﻿using System;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

            if(acf.LanguageJudge()!=acf.VoiceJudge())
            {
                button1.Text = "还原语音";
            }
            else
            {
                button1.Text = "更改语音";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.InitialDirectory = acf.GetDefaultSteamPath().Replace("/","\\");
            filedialog.ShowDialog();

        }
    }
}
