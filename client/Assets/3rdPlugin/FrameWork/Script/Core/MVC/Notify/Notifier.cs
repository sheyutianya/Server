using System;
using System.Collections.Generic;

namespace Core.MVC
{
    public class Notifier
    {
        private Dictionary<string, StandardDelegate> m_eventMap = new Dictionary<string, StandardDelegate>();
        public delegate void StandardDelegate(params object[] arg1);

        //���ĳ�¼�����
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

        //�Ƴ�ĳ�¼�������
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

        //����ĳ�¼�����֪ͨ�����е��¼���������
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

        //�ж�ĳ�¼��Ƿ��Ѿ�ע�ᣬ�����ڷ�ֹģ��������
        public bool HasEvent(string eventName)
        {
            return m_eventMap.ContainsKey(eventName);
        }

        //�Ƴ�ĳ�¼�������ί��
        public void RemoveAllEventHandler(string eventName)
        {
            Delegate[] delegArr = m_eventMap[eventName].GetInvocationList();
            ///����ί������
            foreach (StandardDelegate deleg in delegArr)
            {
                RemoveEventHandler(eventName, deleg);
            }
        }

        //���ע��
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