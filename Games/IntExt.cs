using System.Net;

namespace Games
{
    internal static class IntExt
    {
        #region 大端流

        public static byte[] BigEndian(this short dw)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(dw));
        }

        public static byte[] BigEndian(this int dw)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(dw));
        }

        public static byte[] BigEndian(this long dw)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder(dw));
        }

        public static byte[] BigEndian(this ushort dw)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)dw));
        }

        public static byte[] BigEndian(this uint dw)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder((int)dw));
        }

        public static byte[] BigEndian(this ulong dw)
        {
            return BitConverter.GetBytes(IPAddress.HostToNetworkOrder((long)dw));
        }

        #endregion 大端流

        #region 大端数字

        /// 大端数字
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        public static short GetBigInt16(this byte[] vs)
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt16(vs,0));
        }

        /// 大端数字
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        public static ushort GetBigUInt16(this byte[] vs)
        {
            return (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(vs,0));
        }

        /// 大端数字
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        public static int GetBigInt32(this byte[] vs)
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt32(vs,0));
        }

        /// 大端数字
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        public static uint GetBigUInt32(this byte[] vs)
        {
            return (uint)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(vs,0));
        }        /// 大端数字

                 /// </summary>
                 /// <param name="vs"></param>
                 /// <returns></returns>
        public static long GetBigInt64(this byte[] vs)
        {
            return IPAddress.NetworkToHostOrder(BitConverter.ToInt64(vs,0));
        }

        /// 大端数字
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        public static ulong GetBigUInt64(this byte[] vs)
        {
            return (ulong)IPAddress.NetworkToHostOrder(BitConverter.ToInt64(vs,0));
        }

        #endregion 大端数字

        #region 小端流

        public static byte[] LittleEndian(this short dw)
        {
            return BitConverter.GetBytes(dw);
        }

        public static byte[] LittleEndian(this int dw)
        {
            return BitConverter.GetBytes(dw);
        }

        public static byte[] LittleEndian(this long dw)
        {
            return BitConverter.GetBytes(dw);
        }

        public static byte[] LittleEndian(this ushort dw)
        {
            return BitConverter.GetBytes((short)dw);
        }

        public static byte[] LittleEndian(this uint dw)
        {
            return BitConverter.GetBytes((int)dw);
        }

        public static byte[] LittleEndian(this ulong dw)
        {
            return BitConverter.GetBytes((long)dw);
        }

        #endregion 小端流

        #region 小端数字

        /// <summary>
        /// 小端数字
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        public static int GetLittleInt32(this byte[] vs)
        {
            return BitConverter.ToInt32(vs,0);
        }

        /// <summary>
        /// 小端数字
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        public static uint GetLittleUInt32(this byte[] vs)
        {
            return BitConverter.ToUInt32(vs,0);
        }

        /// <summary>
        /// 小端数字
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        public static short GetLittleInt16(this byte[] vs)
        {
            return BitConverter.ToInt16(vs,0);
        }

        /// <summary>
        /// 小端数字
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        public static ushort GetLittleUInt16(this byte[] vs)
        {
            return BitConverter.ToUInt16(vs,0);
        }

        /// <summary>
        /// 小端数字
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        public static long GetLittleInt64(this byte[] vs)
        {
            return BitConverter.ToInt64(vs,0);
        }

        /// <summary>
        /// 小端数字
        /// </summary>
        /// <param name="vs"></param>
        /// <returns></returns>
        public static ulong GetLittleUInt64(this byte[] vs)
        {
            return BitConverter.ToUInt64(vs,0);
        }

        #endregion 小端数字

    }
}
