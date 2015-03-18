using UnityEngine;
using System;

namespace Core.MVC
{
    public abstract class View : ViewNotifier
    {
        protected Model _bindModel;

        public virtual void Init(Model model)
        {
            _bindModel = model;
        }

        //��ģ�͵�ĳ������
        protected void BindModel(Enum Attribute, Notifier.StandardDelegate fun)
        {
            _bindModel.AddEventHandler(_bindModel.GetModelName() + Attribute, fun);
        }

        //���ģ�͵�ĳ������
        protected void UnBindModel(Enum Attribute, Notifier.StandardDelegate fun)
        {
            _bindModel.RemoveEventHandler(_bindModel.GetModelName() + Attribute, fun);
        }

        protected void UnAllBindModel(Enum Attribute)
        {
            _bindModel.RemoveAllEventHandler(_bindModel.GetModelName() + Attribute);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _bindModel = null;
        }
    }

    public class ViewNotifier : MonoBehaviour
    {
        private Notifier _notifier = new Notifier();
        
        protected void AddEventHandler(string eventName, Notifier.StandardDelegate d)
        {
            _notifier.AddEventHandler(eventName, d);
        }

        protected void RemoveEventHandler(string eventName, Notifier.StandardDelegate d)
        {
            _notifier.RemoveEventHandler(eventName, d);
        }

        //����ĳ�¼����¼��� - ������
        protected void RaiseEvent(string eventName, params object[] e)
        {
            _notifier.RaiseEvent(eventName, e);
        }

        protected void RemoveAllEventHandler(string eventName)
        {
            _notifier.RemoveAllEventHandler(eventName);
        }

        //���ע��
        protected void ClearEventHandle()
        {
            _notifier.ClearEventHandle();
        }

        //�����ٵ�ʱ�򣬽��Լ�ע����¼���NotifyManager��ע����
        protected virtual void OnDestroy()
        {
            ClearEventHandle();
            _notifier = null;
        }
    }
}
