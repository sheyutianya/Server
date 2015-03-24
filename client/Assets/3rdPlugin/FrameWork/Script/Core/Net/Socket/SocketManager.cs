using com.Cotg.net.msg;
using Core.MVC;
using UnityEngine;

namespace Net
{
    /// <summary>
    /// socket 管理器
    /// </summary>
    public class SocketManager : Notifier
    {
        #region 单列构造
        private static SocketManager _instance;
        public static SocketManager ins
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SocketManager();
                    
                }
                return _instance;
            }
        }
        

        private SocketManager()
        {   
            SetUp("127.0.0.1" , 20000);
        }
        #endregion

        public ByteSocket socket { get; set; }

        public void SetUp(string ip,int port) 
        {
            InitEvent();
            socket = new ByteSocket(false);
            socket.Connect(ip, port);
        }

        public void Close()
        {
            if(socket != null)socket.Dispose();
        }

        #region 初始化事件
        private void InitEvent()
        {
            //socket 连接
            AddEventHandler(SocketEvents.SOCKET_CONNECT, __connectHandler);
            //socket 出错
            AddEventHandler(SocketEvents.SOCKET_ERROR, __errorHandler);
            //socket 接收到数据
            AddEventHandler(SocketEvents.SOCKET_DATA, __dataHandler);
        }
        #endregion


        #region 收到数据
        /// <summary>
        ///收到数据
        /// </summary>
        /// <param name="obj">收到的数据</param>
        private void __dataHandler(object[] obj)
        {
            PackageIn pkg = obj[0] as PackageIn;
            if (pkg!=null)
            {
                RaiseEvent(pkg.Code.ToString(), pkg);    
            }
            else
            {
                Debug.LogError("收到的数据没有包装秤 PackageIn");
            }
        }
        #endregion

        #region 服务器断开
        /// <summary>
        /// 服务器断开
        /// </summary>
        /// <param name="obj"></param>
        private void __errorHandler(object[] obj)
        {
            Debug.LogError(obj[0] + "服务器没有连接上");             
        }
        #endregion

        #region 连接成功
        /// <summary>
        /// 服务器连接是否成功
        /// </summary>
        private void __connectHandler(object[] obj)
        {
            // 测试发包
            Debug.Log("服务器连接成功");
        }

        #endregion
    }
}
