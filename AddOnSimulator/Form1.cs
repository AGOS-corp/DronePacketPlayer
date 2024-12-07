using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddOnSimulator
{
    public partial class Form1 : Form
    {
        private BinaryReader adsbReader;
        private BinaryReader ocusyncReader;
        private BinaryReader loopReader;
        private BinaryReader spiderShieldReader;
        private bool isStart = false;
        private Thread AdsbThread;
        private Thread OcusyncThread;
        private Thread SpiderShieldThread;
        private Thread LoopThread;
        private Thread LoopThread2;
        private WebSocketServer _webSocketServer;

        private string ocusyncIP { get; set; }
        private int ocusyncPort { get; set; }

        private string adsbIP { get; set; }
        private int adsbPort { get; set; }
        
        private string loopIP { get; set; }
        private int loopPort { get; set; }
        
        private string spiderShieldIP { get; set; }
        private int spiderShieldPort { get; set; }

        public Form1()
        {
            InitializeComponent();
            InitializeControls();
            
            var spiderShieldDirectories = Directory.GetDirectories(@"./SpiderShield_Packets");
            foreach (var directory in spiderShieldDirectories)
                cb_sp_folder.Items.Add(directory);

            var ocusyncDirectories = Directory.GetDirectories(@"./Ocusync_Packets");
            foreach (var directory in ocusyncDirectories)
                cb_ocusyncFolder.Items.Add(directory);

            cb_sp_folder.SelectedIndex = 0;
            cb_ocusyncFolder.SelectedIndex = 0;

            adsbReader = new BinaryReader(@"./ADSB_Packets");
            AdsbSend.SetNetwork(adsbIP, adsbPort);

            ocusyncReader = new BinaryReader(@"./Ocusync_Packets");
            OcusyncSend.SetNetwork(ocusyncIP, adsbPort);

            loopReader = new BinaryReader(@"./Loop_Packets/240526");
            // LoopSend.SetNetwork(loopIP, loopPort);

            spiderShieldReader = new BinaryReader(@"./SpiderShield_Packets");
            SpiderShieldSend.SetNetwork(spiderShieldIP,spiderShieldPort);

            adsbReader.DataSendEvent = (string log) =>
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    string _log = "[adsb]" + log;
                    if (listBox1.Items.Count > 100) listBox1.Items[100] = _log;
                    else listBox1.Items.Add(_log);
                }));
            };
            ocusyncReader.DataSendEvent = (string log) =>
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    string _log = "[Ocusync]" + log;
                    if (listBox1.Items.Count > 100) listBox1.Items[100] = _log;
                    else listBox1.Items.Add(_log);
                }));
            };
            loopReader.DataSendEvent = (string log) =>
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    string _log = "[loop]" + log;
                    if (listBox1.Items.Count > 100) listBox1.Items[100] = _log;
                    else listBox1.Items.Add(_log);
                }));
            };
            
            spiderShieldReader.DataSendEvent = (string log) =>
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    string _log = "[spiderShield]" + log;
                    if (listBox1.Items.Count > 100) listBox1.Items[100] = _log;
                    else listBox1.Items.Add(_log);
                }));
            };
            _webSocketServer = WebSocketServer.GetInstance();
            _webSocketServer.StartAsync(loopPort);
        }

        private void InitializeControls()
        {
            tb_ocusync_IP.Text = IniFile.ocusyncIP;
            tb_ocusync_port.Text = IniFile.ocusyncPort;
            tb_adsb_ip.Text = IniFile.adsbIP;
            tb_adsb_port.Text = IniFile.adsbPort;
            tb_loop_ip.Text = IniFile.loopIP;
            tb_loop_port.Text = IniFile.loopPort;
            tb_node_ip.Text = IniFile.nodeIP;
            tb_node_port.Text = IniFile.nodePort;

            ocusyncIP = tb_ocusync_IP.Text;
            ocusyncPort = Int32.Parse(tb_ocusync_port.Text);

            adsbIP = tb_adsb_ip.Text;
            adsbPort = Int32.Parse(tb_adsb_port.Text);

            loopIP = tb_loop_ip.Text;
            loopPort = Int32.Parse(tb_loop_port.Text);

            spiderShieldIP = tb_node_ip.Text;
            spiderShieldPort = Int32.Parse(tb_node_port.Text);
        }

        private void PlayMode()
        {
            if (isStart)
                button1.Text = "중지";
            else
                button1.Text = "전송";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            isStart = !isStart;
            PlayMode();

            if (isStart)
            {
                ocusyncIP = tb_ocusync_IP.Text;
                ocusyncPort = Int32.Parse(tb_ocusync_port.Text);

                adsbIP = tb_adsb_ip.Text;
                adsbPort = Int32.Parse(tb_adsb_port.Text);

                spiderShieldIP = tb_node_ip.Text;
                spiderShieldPort = Int32.Parse(tb_node_port.Text);
                
                AdsbSend.SetNetwork(adsbIP, adsbPort);
                OcusyncSend.SetNetwork(ocusyncIP, ocusyncPort);
                SpiderShieldSend.SetNetwork(spiderShieldIP,spiderShieldPort);
                var sp_idx = cb_sp_folder.SelectedIndex;
                var ocu_idx = cb_ocusyncFolder.SelectedIndex;

                if (cb_adsb.Checked)
                {
                    AdsbThread = new Thread(() => adsbReader.ReadFile(AdsbSend.SendADSB));
                    AdsbThread.Start();
                }

                if (cb_ocusync.Checked)
                {
                    OcusyncThread = new Thread(() => ocusyncReader.ReadFile(OcusyncSend.SendOcusync, ocu_idx));
                    OcusyncThread.Start();
                }

                if (cb_loop.Checked)
                {
                    LoopThread = new Thread(() => loopReader.ReadFileAsync(LoopSend.SendLoop,1));
                    LoopThread2 = new Thread(() => loopReader.ReadFileAsync(LoopSend.SendLoop,2,@"./Loop_Packets/240801"));
                    
                    LoopThread.Start();
                    LoopThread2.Start();
                }

                if (cb_direction.Checked)
                {
                    SpiderShieldThread =
                        new Thread(() => spiderShieldReader.ReadFile(SpiderShieldSend.SendSpiderShield,sp_idx));
                    
                    SpiderShieldThread.Start();
                }
            }
            else
            {
                AdsbThread?.Abort();
                LoopThread?.Abort();
                LoopThread2?.Abort();
                OcusyncThread?.Abort();
                SpiderShieldThread?.Abort();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _webSocketServer.DisconnectClient();
        }
    }
}