using System;
using System.Collections.Generic;
using Core.Managers;

namespace Core.MVC
{
    /// <summary>
    /// 延迟数据层,
    /// 每帧延迟派发刷新事件，避免对同一属性反复赋值导致多次刷新
    /// </summary>
    public class LateModel : Model
    {
        protected Dictionary<Enum, bool> _changeObj;

        public LateModel()
        {
            _changeObj = new Dictionary<Enum, bool>();
            EnterFrameManager.GetInstance().RegisterLateUpdate(Commit);
        }

        /// <summary>
        /// 每帧延迟派发刷新
        /// </summary>
        public void Commit()
        {
            RefreshChange();
            _changeObj.Clear();
        }

        /// <summary>
        /// 子类继承实现，检查change派发
        /// </summary>
        protected virtual void RefreshChange()
        {

        }

        /// <summary>
        /// 销毁，上层手动调用
        /// </summary>
        public override void Destory()
        {
            base.Destory();
            EnterFrameManager.GetInstance().UnRegisterLateUpdate(Commit);
        }
    }
}

