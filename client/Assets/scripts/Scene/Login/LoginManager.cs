using com.Cotg.net.msg;
using Cotg.Proto.Const;
//using Cotg.Scene;
using Net;
using UnityEngine;

namespace Cotg.UI.Login
{
    public class LoginManager
    {
        #region 单例

        private static LoginManager _instance;

        public static LoginManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LoginManager();
            }
            return _instance;
        }

        private LoginManager()
        {
            SetUp();
        }

        #endregion


        private LoginModel _model;

        public LoginModel Model
        {
            get { return _model; }
        }

        /// <summary>
        /// 初始化事件
        /// </summary>
        public void SetUp()
        {
            if (_model == null)
            {
                _model = new LoginModel();
                SocketManager.ins.AddEventHandler(ProtoType.NET_PLAYER_CODE, __receivePlayer);
            }

            
        }

        private void __receivePlayer(object[] arg1)
        {
            PackageIn packageIn = arg1[0] as PackageIn;
            //TestMsg msg = packageIn.ReadBody<TestMsg>();
            //Debug.Log("msg.Id:" + msg.Name + "msg.Name:" + msg.Password);
            //_model.BeginChanges();
            //_model.Inject(msg);
            //_model.Password(msg.Password);
            // _model.Name(msg.Name);
            //_model.Commit();
        }
    }
}
