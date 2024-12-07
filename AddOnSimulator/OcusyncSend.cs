using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace AddOnSimulator
{
    public class OcusyncSend
    {
        private static IPEndPoint serverEndPoint { get; set; }
        private static UdpClient udpClient { get; set; }

        private static int startIdx = 0;
        private static int endIdx = 0;
        private static int readIndex = 0;

        private static IPAddress serverIP { get; set; }
        private static int port { get; set; }   

        public static void SetNetwork(string _serverIP, int _port)
        {
            serverIP = IPAddress.Parse(_serverIP);
            port = _port;

            serverEndPoint = new IPEndPoint(serverIP, port);
            // UDP 클라이언트를 생성합니다.
            udpClient = new UdpClient();
        }

        public static bool SendOcusync(byte[] packets)
        {
            for (int i = 0; i < packets.Length - 3; i++)
            {
                var r = BitConverter.ToInt32(packets, i);
                if (r == 49270187)
                {
                    startIdx = i;
                }

                if (r == 55981074)
                {
                    endIdx = i;
                    try
                    {
                        byte[] sendPackets = new byte[endIdx + 4 - startIdx];
                        Buffer.BlockCopy(packets,startIdx,sendPackets,0,endIdx + 4 - startIdx);
                        udpClient.Send(sendPackets, endIdx + 4 - startIdx, serverEndPoint);
                        Console.WriteLine("데이터를 서버로 송신했습니다.");

                        // 원하는 대기 시간을 설정한 후에 반복 송신
                        Thread.Sleep(1000); // 0.1초 대기
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("오류 발생: " + e.ToString());
                        return false;
                    }
                }
            }
            return true;
        }
    }
}