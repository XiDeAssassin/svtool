using System;
using System.IO;
using Microsoft.Win32;
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
            Console.WriteLine("Your Steam Path is {0}", keyValue);
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

    }
}