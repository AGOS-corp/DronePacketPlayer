using System;
using System.IO;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AddOnSimulator
{
    public class LoopSend
    {
        private int readIndex = 0;
        private static WebSocketServer _webSocketServer;
        

        public static async Task<bool> SendLoop(byte[] packets,int idx = 1)
        {
            var dataStr = Encoding.Default.GetString(packets);
            var preFixCount = 0;
            var postFixCount = 0;
            var beforeIdx = 0;
            for (int i = 0; i < dataStr.Length; i++)
            {
                if (dataStr[i] == '{')
                {
                    preFixCount++;
                    continue;
                }
                if (dataStr[i] == '}')
                {
                    postFixCount++;
                    if (preFixCount == postFixCount)
                    {
                        var str = dataStr.Substring(beforeIdx,  i - beforeIdx+1);
                        // Console.WriteLine(str);
                        await WebSocketServer.GetInstance().SendMessageToAll_Path(str, $"/sources/{idx}/trajectories");
                        beforeIdx = i + 1;
                        Thread.Sleep(10);
                    }
                }
            }
            return false;
        }
    }
}