using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace AddOnSimulator
{
    public class BinaryReader
    {
        public delegate void DataGetEventHandler(string data);
        public DataGetEventHandler DataSendEvent;

        private string folderPath { get; set; }

        public BinaryReader(string _folderPath)
        {
            folderPath = _folderPath;
        }

        private byte[] ReadBinaryFile(string filePath)
        {
            // 파일을 바이너리 형태로 읽기
            byte[] fileContent = File.ReadAllBytes(filePath);
            return fileContent;
        }

        public void ReadFile(Func<byte[], bool> sendMethods)
        {
            // 해당 폴더의 모든 .bin 파일을 읽어옴
            string[] fileEntries = Directory.GetFiles(folderPath, "*.bin");
            while (true)
            {
                foreach (string fileName in fileEntries)
                {
                    // 각 파일을 처리 (예: 파일 내용 읽기)
                    var packets = ReadBinaryFile(fileName);
                    while (true)
                    {
                        try
                        {
                            bool r = sendMethods(packets);
                            DataSendEvent(DateTime.Now + " - " + "데이터를 송신했습니다.");
                            if (!r) break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("오류 발생: " + e.ToString());
                        }
                    }
                }
            }
        }



        public void ReadFile(Func<byte[], bool> sendMethods, int folderIdx)
        {
            var directories = Directory.GetDirectories(folderPath);
            var depthFolderPath = directories[folderIdx];
            // 해당 폴더의 모든 .bin 파일을 읽어옴
            string[] fileEntries = Directory.GetFiles(depthFolderPath, "*.bin");
            while (true)
            {
                foreach (string fileName in fileEntries)
                {
                    // 각 파일을 처리 (예: 파일 내용 읽기)


                    try
                    {
                        var packets = ReadBinaryFile(fileName);
                        bool r = sendMethods(packets);
                        DataSendEvent(DateTime.Now + " - " + $"{fileName}데이터를 송신했습니다.");
                        if (!r) break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("오류 발생: " + e.ToString());
                    }

                }
            }
        }

        public async void ReadFileAsync(Func<byte[], int, Task<bool>> sendMethods, int idx, string _folderPath = null)
        {
            // 해당 폴더의 모든 .bin 파일을 읽어옴
            string[] fileEntries = Directory.GetFiles(_folderPath ?? folderPath, "*.bin");
            while (true)
            {
                foreach (string fileName in fileEntries)
                {
                    // 각 파일을 처리 (예: 파일 내용 읽기)
                    var packets = ReadBinaryFile(fileName);
                    while (true)
                    {
                        try
                        {
                            var r = await sendMethods(packets, idx);
                            DataSendEvent(DateTime.Now + " - " + "데이터를 송신했습니다.");
                            if (!r) break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("오류 발생: " + e.ToString());
                        }
                    }
                }
            }
        }
    }
}