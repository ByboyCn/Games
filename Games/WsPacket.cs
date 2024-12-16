using Google.Protobuf;
using System.Collections.Concurrent;

namespace Games
{
    /// <summary>
    /// 包结构
    /// </summary>
    internal class WsPacket
    {
        private static ConcurrentDictionary<int,SmCmData> keyValuePairs = new();
        internal static void InitSmCmData()
        {
            keyValuePairs.Clear();
            keyValuePairs = [];
            keyValuePairs.TryAdd(1,new SmCmData() { SmMsgId = 1,CmMethod = cmLogin.Parser,SmMethod = smLogin.Parser,});
            keyValuePairs.TryAdd(10,new SmCmData() { SmMsgId = 10,CmMethod = cmPing.Parser,SmMethod = smPing.Parser,});
            keyValuePairs.TryAdd(607,new SmCmData() { SmMsgId = 607,CmMethod = cmRecevGold.Parser,SmMethod = smRecevGold.Parser,});
            keyValuePairs.TryAdd(408,new SmCmData() { SmMsgId = 408,CmMethod = null!,SmMethod = smSyncGoldSpeed.Parser,});
        }

        /// <summary>
        /// 包头
        /// </summary>
        private static readonly byte[] head = [0x71,0xab];
        /// <summary>
        /// 包总长度
        /// </summary>
        private int PackLength { get; set; }
        /// <summary>
        /// 包命令
        /// </summary>
        public int Cmd { get; set; }

        /// <summary>
        /// 区组ID
        /// </summary>
        public int ZoneId { get; set; }
        /// <summary>
        /// 账号id
        /// </summary>
        public int AccountId { get; set; }
        /// <summary>
        /// pb数据
        /// </summary>
        public IMessage PbMessage { get; set; } = default!;
        /// <summary>
        /// 加密
        /// </summary>
        /// <returns></returns>
        public byte[] Enabled()
        {
            var result = new List<byte>();
            var bytes = PbMessage.ToByteArray();
            PackLength = bytes.Length + 18;
            result.AddRange(head);
            result.AddRange(PackLength.BigEndian());
            result.AddRange(Cmd.BigEndian());
            result.AddRange(ZoneId.BigEndian());
            result.AddRange(AccountId.BigEndian());
            result.AddRange(bytes);
            return [.. result];
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="parser"></param>
        /// <returns></returns>
        public void Denabled(byte[] bytes)
        {
            var pbMessageData = bytes[18..]; // 获取 PbMessage 的字节数据
            PackLength = bytes[2..6].GetBigInt32();
            Cmd = bytes[6..10].GetBigInt32();
            ZoneId = bytes[10..14].GetBigInt32();
            AccountId = bytes[14..18].GetBigInt32();
            keyValuePairs.TryGetValue(Cmd,out var smCmData);
            if (smCmData != null) {
                PbMessage = smCmData.SmMethod.ParseFrom(pbMessageData);
            }
        }
    }


    /// <summary>
    /// 通信数据
    /// </summary>
    public class SmCmData
    {
        public int SmMsgId { get; set; }
        /// <summary>
        /// 请求方法
        /// </summary>
        public MessageParser CmMethod { get; set; } = null!;
        /// <summary>
        /// 响应方法
        /// </summary>
        public MessageParser SmMethod { get; set; } = null!;
    }

}
