using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EventHandler
{
	public abstract class IEventHandler
	{
		protected List<ChuMeng.MyEvent.EventType> regEvent;
		public void RegEvent() {
			if (regEvent != null) {
				foreach(ChuMeng.MyEvent.EventType e in regEvent) {
					ChuMeng.MyEventSystem.myEventSystem.RegisterEvent(e, OnEvent);
				}
			}
		}
		public abstract void Init();
		public abstract void OnEvent(ChuMeng.MyEvent evt);
	}
}
