using System;
using System.Collections.Generic;

namespace Core.MVC
{
    public class Notifier
    {
        private Dictionary<string, StandardDelegate> m_eventMap = new Dictionary<string, StandardDelegate>();
        public delegate void StandardDelegate(params object[] arg1);

        //添加某事件处理
        public void AddEventHandler(string eventName, StandardDelegate d)
        {
            if (!m_eventMap.ContainsKey(eventName))
            {
                m_eventMap[eventName] = d;
            }
            else
            {
                m_eventMap[eventName] += d;
            }
        }

        //移除某事件处理函数
        public void RemoveEventHandler(string eventName, StandardDelegate d)
        {
            if (m_eventMap.ContainsKey(eventName))
            {
                if (m_eventMap[eventName] != null)
                {
                    m_eventMap[eventName] -= d;
                }
            }
        }

        //触发某事件，将通知到所有的事件监听对象
        public void RaiseEvent(string eventName, params object[] e)
        {
            StandardDelegate fun = null;
            if (m_eventMap.TryGetValue(eventName, out fun))
            {
                if (null != fun)
                {
                    fun(e);
                }
            }
        }

        //判断某事件是否已经注册，可用于防止模型重命名
        public bool HasEvent(string eventName)
        {
            return m_eventMap.ContainsKey(eventName);
        }

        //移除某事件的所有委托
        public void RemoveAllEventHandler(string eventName)
        {
            Delegate[] delegArr = m_eventMap[eventName].GetInvocationList();
            ///遍历委托数组
            foreach (StandardDelegate deleg in delegArr)
            {
                RemoveEventHandler(eventName, deleg);
            }
        }

        //清空注册
        public void ClearEventHandle()
        {
            if (m_eventMap.Count <= 0) return;
            foreach (KeyValuePair<string, StandardDelegate> kv in m_eventMap)
            {
                RemoveEventHandler(kv.Key, kv.Value);
            }
            m_eventMap.Clear();
        }
    }
}