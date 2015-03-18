using System.Diagnostics;
using com.Cotg.net.msg;
using Net;
using Debug = UnityEngine.Debug;

namespace Cotg.UI.Login
{
    public class LoginSerives
    {
        #region 单列

        public static LoginSerives _instance;

        public static LoginSerives GetInstance()
        {
            if (_instance == null)
            {
                _instance =new LoginSerives();
            }
            return _instance;
        }

        #endregion


        #region 通信

        public void Login(string name, string password)
        {
            PackageOut pkg = new PackageOut(0x2130);
            TestMsg msg = new TestMsg();
            msg.f1 = 1;
            msg.f2 = 2.0f;
            msg.f3 = 0;
            msg.f4 = 1;
            msg.f5 = false;
            msg.f6 = "aaa";
            SocketManager.ins.socket.SendProtobuffer(pkg, msg);

            Debug.Log("shulululu");
        }
        #endregion
    }
}
