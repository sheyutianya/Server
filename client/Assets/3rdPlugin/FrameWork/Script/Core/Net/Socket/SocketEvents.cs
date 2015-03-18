using System;
using UnityEngine;

namespace Net
{
    public class SocketEvents
    {
        /// <summary>
        /// socket 连接上
        /// </summary>
        public const string SOCKET_CONNECT ="socket_connect";

        /// <summary>
        /// socket 关闭
        /// </summary>
        public const string SOCKET_CLOSE = "socket_close";

        /// <summary>
        /// socket error
        /// </summary>
        public const string SOCKET_ERROR = "socket_error";

        /// <summary>
        /// socket 数据
        /// </summary>
        public const string SOCKET_DATA = "socket_data";
    }
}
