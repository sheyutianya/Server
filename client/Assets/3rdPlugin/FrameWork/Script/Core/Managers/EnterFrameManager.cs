using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Managers
{
    /// <summary>
    /// 帧管理器
    ///    管理所有需要在主线程中执行的IEnterFrame
    /// </summary>
    public class EnterFrameManager
    {
        #region 单例

        private static EnterFrameManager _instarnce ;
        public static EnterFrameManager GetInstance()
        {
            if (_instarnce == null)
            {
                _instarnce = new EnterFrameManager();
            }
            return _instarnce;
        }
        private EnterFrameManager()
        {
        }
        #endregion

        private event Action OnEnterFrame;
        private event Action OnFixUpdate;
        private event Action OnLateUpdate;
        #region 注册
        public  void Register(Action enterAction)
        {
            OnEnterFrame += enterAction;
        }
        #endregion

        #region 注销
        public void UnRegister(Action enterAction)
        {
            OnEnterFrame -= enterAction;
        }
        #endregion

        /// <summary>
        /// 初始化每帧执行
        /// </summary>
        public  void Do()
        {
            if (OnEnterFrame != null)
            {
                OnEnterFrame();
            }
        }

        #region 注册
        public void RegisterFixUpdate(Action action)
        {
            OnFixUpdate += action;
        }
        #endregion

        #region 注销
        public void UnRegisterFixUpdate(Action action)
        {
            OnFixUpdate -= action;
        }
        #endregion

        /// <summary>
        /// 初始化精确执行
        /// </summary>
        public void DoFixUpdate()
        {
            if (OnFixUpdate != null)
            {
                OnFixUpdate();
            }
        }

        #region 注册
        public void RegisterLateUpdate(Action enterAction)
        {
            OnLateUpdate += enterAction;
        }
        #endregion

        #region 注销
        public void UnRegisterLateUpdate(Action enterAction)
        {
            OnLateUpdate -= enterAction;
        }
        #endregion

        /// <summary>
        /// 初始化每帧延迟执行
        /// </summary>
        public void DoLateUpdate()
        {
            if (OnLateUpdate != null)
            {
                OnLateUpdate();
            }
        }
    }
}
