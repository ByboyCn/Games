namespace Games
{
    internal class Events
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEventArgs"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate Task EventAsyncHandler<TEventArgs>(TEventArgs e);

        public static event EventAsyncHandler<WsPacket> Receive = null!;

        public static void OnReceive(WsPacket e)
        {
            Receive?.Invoke(e);
        }

    }
}
