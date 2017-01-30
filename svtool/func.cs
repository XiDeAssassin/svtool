using System;
using System.IO;
using Microsoft.Win32;
using System.Security.Cryptography;
namespace svtool
{
    class Func
    {
        string keyValue = "";
        string steamlibrary = "";
        public string GetDefaultSteamLibraryPath()
        {
            using (RegistryKey currentKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Valve\\Steam", false))
            {
                keyValue = currentKey.GetValue("SteamPath").ToString();
            }
            steamlibrary = keyValue + "/steamapps";
            return steamlibrary.Replace("/","\\");
        }

        public bool LanguageJudge()
        {
            string acfpath = "";
            string text = "";
            acfpath = steamlibrary + "/appmanifest_453480.acf";
            using (StreamReader file = new StreamReader(acfpath))
            {
                text = file.ReadToEnd();
            }
            return text.Contains("english");
        }
        public string MD5file(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                }
            }
        }

        public bool VoiceJudge()
        {
            string voicefilemd5 = "";
            voicefilemd5 = MD5file(steamlibrary + "/common/Shadowverse/Shadowverse_Data/StreamingAssets/v/vo_101_000_001.acb");
            if(voicefilemd5 == "3EF567DE7D68B57F80C5890AC50145AF")// EN is D6CF6E4066CDB28FA198B69F8900129D
            {
                return false;
            }
            else
            {
                return true;
            }
        
        }

        public void backupfile(string path,bool d)//d=true 目前是EN备份去EN| d=false则是JP
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
            if (Directory.Exists(targetPath))
            {
                string[] filenames = Directory.GetFiles(sourcePath);
                foreach (string s in filenames)
                {
                    filename = Path.GetFileName(s);
                    destFile = Path.Combine(targetPath, filename);
                    File.Copy(s, destFile, true);
                }
            }
        }

        public void overwritefile()
        {

        }
    }
}