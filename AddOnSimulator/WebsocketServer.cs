using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AddOnSimulator
{
    public class WebSocketServer
    {
        public Action<string> writeLog;
        public Action<string> CameraReceiveDataProcessAction;

        private HttpListener _listener;

        private Dictionary<string, ListCollection<System.Net.WebSockets.WebSocket>> wsClientsDict;

        private static WebSocketServer instance;
        private System.Net.WebSockets.WebSocket socket;
        private bool status;

        private readonly int DATA_LENGTH = 1024 * 5;

        private WebSocketServer()
        {
            _listener = new HttpListener();
            wsClientsDict = new Dictionary<string, ListCollection<System.Net.WebSockets.WebSocket>>();
        }

        public static WebSocketServer GetInstance()
        {
            if (instance == null)
                instance = new WebSocketServer();
            return instance;
        }

        public async void StartAsync(int port)
        {
            try
            {
                _listener.Prefixes.Clear();
                _listener.Prefixes.Add($"http://*:{port}/");
                _listener.Start();
                status = true;

                while (status)
                {
                    var context = await _listener.GetContextAsync();
                    if (context.Request.IsWebSocketRequest)
                    {
                        await HandleHttpRequest(context);
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //writeLog(e.Message);
            }
        }

        private async Task HandleHttpRequest(HttpListenerContext context)
        {
            var requestUrl = context.Request.Url;
            var path = requestUrl.AbsolutePath;

            var webSocketContext = await context.AcceptWebSocketAsync(subProtocol: null);
            socket = webSocketContext.WebSocket;

            // await SendMessageAsync(socket, "Websocket Connect!"); // 클라이언트에게 메세지 보내기

            switch (path) //TODO 외부에서 주입하는 방식으로 변경 필요. 완전 모듈화
            {
                case "/sources":
                    var message =
                        "{\n    \"sources\": [\n        {\n            \"id\": 1,\n            \"name\": \"Radar\",\n            \"state\": \"error\",\n            \"type\": \"radar\"\n        }\n   ]\n}";
                        // "{\n    \"sources\": [\n            {\n            \"id\": 2,\n            \"name\": \"DJI\",\n            \"state\": \"ok\",\n            \"type\": \"dji\"\n        }\n    ]\n}";/
                        // "{\n    \"sources\": [\n        {\n            \"id\": 1,\n            \"name\": \"Radar\",\n            \"state\": \"error\",\n            \"type\": \"radar\"\n        },\n        {\n            \"id\": 2,\n            \"name\": \"DJI\",\n            \"state\": \"ok\",\n            \"type\": \"dji\"\n        }\n    ]\n}";
                    
                    await SendMessageAsync(socket, message);
                    break;
                case "/sources/1/trajectories":
                    if (!wsClientsDict.ContainsKey(path))
                        wsClientsDict[path] = new ListCollection<System.Net.WebSockets.WebSocket>();

                    //await SendMessageAsync(socket, path); // 클라이언트에게 메세지 보내기
                    wsClientsDict[path].Add(webSocketContext.WebSocket);
                    break;

                case "/sources/2/trajectories":
                    if (!wsClientsDict.ContainsKey(path))
                        wsClientsDict[path] = new ListCollection<System.Net.WebSockets.WebSocket>();

                    //await SendMessageAsync(socket, path); // 클라이언트에게 메세지 보내기
                    wsClientsDict[path].Add(webSocketContext.WebSocket);
                    break;
                default:
                    context.Response.StatusCode = 400;
                    context.Response.Close();
                    // Handle unknown endpoint
                    break;
            }

            try
            {
                var r = Task.Run(() => RequestFromClient(webSocketContext.WebSocket, path));
                Debug.WriteLine(r);
            }
            catch (Exception e)
            {
                writeLog(e.Message);
            }
        }

        public async Task RequestFromClient(System.Net.WebSockets.WebSocket sock, string path)
        {
            var buffer = new byte[DATA_LENGTH];
            while (status)
            {
                try
                {
                    var result = await sock.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    if (result.MessageType == WebSocketMessageType.Close) // 클라이언트가 연결을 종료한 경우
                    {
                        wsClientsDict[path].RemoveItem(sock);
                        sock.Dispose();
                        break;
                    }

                    if (result.MessageType == WebSocketMessageType.Text) // Text 형식의 메시지인 경우
                    {
                        string receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                        if (path == "/camera")
                        {
                            CameraReceiveDataProcessAction?.Invoke(receivedMessage);
                        }
                        else if (path == "/agos/light")
                        {
                            /*//경광등 Model 속성 (header만 사용)
                            // 0-경광등 사용 / 1-경광등 사용 중지 / ?-경광등 상태 질의

                            try
                            {
                                model = JsonConvert.DeserializeObject<WarningLightModel>(receivedMessage);
                                string head = model.header;
                                int mode;

                                if (head.Equals("?"))
                                    mode = 2;
                                else
                                    mode = int.Parse(head);


                                receivedMessage = HandleWarningLightRequest(mode, model);
                            }
                            catch (JsonReaderException)
                            {
                                Debug.WriteLine("잘못된 JSON형식 수신");
                                receivedMessage = "Wrong Format JSON was Sending to AddON";
                            }
                            await SendMessageToSocket(receivedMessage, path, sock);*/
                        }
                        else if (path == "/sources")
                        {
                            var message =
                                "{\n    \"sources\": [\n        {\n            \"id\": 1,\n            \"name\": \"Radar\",\n            \"state\": \"error\",\n            \"type\": \"radar\"\n        },\n        {\n            \"id\": 2,\n            \"name\": \"DJI\",\n            \"state\": \"ok\",\n            \"type\": \"dji\"\n        }\n    ]\n}";
                            await SendMessageAsync(sock, message);
                        }
                        else
                        {
                            //들어온 문자열을 기준으로 응답을 해줘야겠지?
                            await SendMessageAsync(sock, receivedMessage);
                        }
                    }
                }
                catch (WebSocketException ex) when (ex.WebSocketErrorCode == WebSocketError.ConnectionClosedPrematurely)
                {
                    // 비정상 종료가 감지된 경우 처리할 코드 추가
                    // 예: 연결 종료 로그 남기기, 연결 재시도 등
                    wsClientsDict[path].RemoveItem(sock);
                    sock.Dispose();
                    Console.WriteLine("???");
                }
                finally
                {
                    Console.WriteLine("뭐야");
                    wsClientsDict[path].RemoveItem(sock);
                    sock.Dispose();
                }
            }
        }

        public void StopWs()
        {
            status = false;
            foreach (var pair in wsClientsDict)
            {
                foreach (var client in pair.Value)
                    client.Dispose();

                pair.Value.ClearAll();
            }
        }

        private async Task SendMessageAsync(System.Net.WebSockets.WebSocket socket, string message)
        {
            var buffer = Encoding.UTF8.GetBytes(message);
            await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true,
                CancellationToken.None);
        }

        /// <summary>
        /// 붙어있는 모~~~~~~든 socket에 메세지를 보냄 (/agos)
        /// </summary>
        /// <param name="message"></param>
        public async Task SendMessageToAll(string message)
        {
            var buffer = Encoding.UTF8.GetBytes(message);
            foreach (var key in wsClientsDict.Keys)
            {
                if (key.Contains("/agos"))
                {
                    foreach (var s in wsClientsDict[key])
                    {
                        await s.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true,
                            CancellationToken.None);
                    }
                }
            }
        }


        /// <summary>
        ///  특정 path로 붙은 socket 전체에 메세지를 보냄
        /// </summary>
        /// <param name="message"></param>
        /// <param name="path"></param>
        public async Task SendMessageToAll_Path(string message, string path)
        {
            var buffer = Encoding.UTF8.GetBytes(message);
            //Console.WriteLine(path);
            if (wsClientsDict.ContainsKey(path))
            {
                try
                {
                    foreach (var s in wsClientsDict[path])
                        await s.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true,
                            CancellationToken.None);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        ///나한테 요청한 socket에만 message를 보낼수도 있겠네?? -> 은성씨 해라~
        public async Task SendMessageToSocket(string message, string path, System.Net.WebSockets.WebSocket socket)
        {
            var buffer = Encoding.UTF8.GetBytes(message);
            if (wsClientsDict.ContainsKey(path))
            {
                foreach (var s in wsClientsDict[path])
                {
                    if (s == socket) //해당 소켓 있으면
                    {
                        await s.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true,
                            CancellationToken.None);
                    }
                }
            }
        }


        public void DisconnectClient()
        {
            foreach (var key in wsClientsDict.Keys)
            {
                foreach (var s in wsClientsDict[key])
                {
                    if (s.State == WebSocketState.Open)
                    {
                        s.Abort();
                        Console.WriteLine("Client disconnected due to inactivity.");
                    }
                }
            }
        }
    }
}