using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddOnSimulator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            String iniPath = Application.StartupPath + @"\config.ini";
            
            IniFile.adsbIP = IniFile.GetValue(iniPath, "adsb", "ip", "192.168.100.200");
            IniFile.adsbPort = IniFile.GetValue(iniPath, "adsb", "port", "9000");
            IniFile.ocusyncIP = IniFile.GetValue(iniPath, "ocusync", "ip", "192.168.0.10");
            IniFile.ocusyncPort = IniFile.GetValue(iniPath, "ocusync", "port", "20000");
            IniFile.loopIP = IniFile.GetValue(iniPath, "loop", "ip", "127.0.0.1");
            IniFile.loopPort = IniFile.GetValue(iniPath, "loop", "port", "20011");
            IniFile.nodeIP = IniFile.GetValue(iniPath, "spiderShield", "ip", "127.0.0.1");
            IniFile.nodePort = IniFile.GetValue(iniPath, "spiderShield", "port", "21000");
            Application.Run(new Form1());
        }
    }
}