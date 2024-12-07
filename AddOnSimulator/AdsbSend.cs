using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace AddOnSimulator
{
    public class AdsbSend
    {
        private static IPEndPoint serverEndPoint { get; set; }
        private static UdpClient udpClient { get; set; }

        private const int ADSB_LENGTH = 50;
        private static IPAddress serverIP { get; set; }
        private static int port { get; set; }
        private static int readIndex { get; set; }

        public static void SetNetwork(string _serverIP,int _port)
        {
            serverIP = IPAddress.Parse(_serverIP);
            port = _port;
            
            serverEndPoint = new IPEndPoint(serverIP, port);
            // UDP 클라이언트를 생성합니다.
            udpClient = new UdpClient();
        }
        
        public static bool SendADSB(byte[] packets)
        {
            byte[] dataToSend = new byte[ADSB_LENGTH];
            int count = packets.Length - readIndex < ADSB_LENGTH ? packets.Length - readIndex : ADSB_LENGTH;
            Buffer.BlockCopy(packets,readIndex,dataToSend,0,count);
            
            udpClient.Send(dataToSend, count, serverEndPoint);
            
            // Console.WriteLine($"{readIndex} : {DUMMY.Length}");
            // Console.WriteLine(DateTime.Now + " - " + "ADSB 데이터를 송신했습니다.");
            
            // 원하는 대기 시간을 설정한 후에 반복 송신
            Thread.Sleep(100); // 0.1초 대기
            readIndex += 50;
            if (packets.Length < readIndex + 50)
            {
                readIndex = 0;
                return false;
            }
            return true;
        }
    }
}