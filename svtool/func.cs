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
        public string GetDefaultSteamPath()
        {
            using (RegistryKey currentKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Valve\\Steam", false))
            {
                keyValue = currentKey.GetValue("SteamPath").ToString();
            }
            steamlibrary = keyValue + "/steamapps";
            return keyValue;
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
    }
}