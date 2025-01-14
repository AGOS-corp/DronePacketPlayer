﻿using System.Runtime.InteropServices;
using System.Text;

namespace AddOnSimulator
{
    public class IniFile
    {
        public static string adsbIP;
        public static string adsbPort;
        public static string ocusyncIP;
        public static string ocusyncPort;
        public static string loopIP;
        public static string loopPort;
        public static string nodeIP;
        public static string nodePort;
        
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
 
        public static void SetValue(string path, string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }
 
        public static string GetValue(string path, string Section, string Key, string Default)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, Default, temp, 255, path);
            if (temp != null && temp.Length > 0) return temp.ToString();
            else return Default;
        }
        
        
    }
}