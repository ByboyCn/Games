using System.Net.WebSockets;

namespace Games
{
    internal class WsHelper
    {
        static string wsurl = "wss://wxgamedfw.1gamer.cn/200s530/ws";
        static ClientWebSocket ws = new ClientWebSocket();
        static byte[] buffer = new byte[1024 * 4];
        internal static async Task<bool> Connect()
        {
            try {
                await ws.ConnectAsync(new Uri(wsurl),CancellationToken.None);
                _ = Task.Run(Receive);

                return true;
            } catch (Exception ex) {
                //连接失败
                Console.WriteLine($"链接失败{ex}");
            }
            return false;
        }
        internal async static Task Send(WsPacket wsPacket)
        {
            await Send(wsPacket.Enabled());
        }
        private async static Task Send(byte[] msg)
        {
            await ws.SendAsync(new ArraySegment<byte>(msg),WebSocketMessageType.Binary,true,CancellationToken.None);
            Console.WriteLine("发送成功");
        }
        private static void Receive()
        {
            //持续接受数据
            while (true) {
                var result = ws.ReceiveAsync(new ArraySegment<byte>(buffer),CancellationToken.None).Result;
                if (result.MessageType == WebSocketMessageType.Close) {
                    ws.CloseAsync(WebSocketCloseStatus.NormalClosure,string.Empty,CancellationToken.None).Wait();
                    break;
                } else {
                    //Console.WriteLine("收到了数据");
                    //处理数据
                    var data = buffer[..result.Count];
                    //处理数据
                    Task.Run(() => Do(data));
                }
            }

        }

        private static void Do(byte[] data)
        {
            WsPacket packet = new();
            packet.Denabled(data);
            Events.OnReceive(packet);
        }
    }

}
