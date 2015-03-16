
/*
Author: liyonghelpme
Email: 233242872@qq.com
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ChuMeng
{
	public class MyEvent {
		public enum EventType {
			/*/// <summary>
			/// 初始化我方玩家结束 进入世界
			/// </summary>
			PlayerEnterWorld,
			PlayerLeaveWorld,

			UnitHP, //单位HP变换
			UnitMP, //单位MP变换
			//UnitMaxHP, //单位MaxHP变换
			//UnitMaxMp, //单位MaxMP变换

			UnitExp, 
			UnitFaceImage,

			UnitHPPercent,
			UnitMPPercent,

			UnitDead,//角色死亡

			OpenItemCoffer, //打开背包面板
			PackageItemChanged, //背包物品变化
			//null arg
			UpdateItemCoffer, //更新物品


			ShowSuperToolTip, //显示tips面板
			UpdateSuperTip, //更新tip面板

			DebugMessage,

			CharEquipChanged, //某个角色的装备更新通知NpcEquipment


			 
			RefreshEquip,  //背包界面更新装备ICON

			MeshShown,//显示背包里面的人物模型
			MeshHide,//Hide Model For UI

			UnitMoney,//五种货币变化了

			OpenAttr,//打开属性面板
			OpenComposeItem, //打开装备强化面板
			ComposeOver,//装备合成结束

			OpenCopyUI,//打开副本UI
			UpdateCopy,

			OpenCopyTip, //打开或者更新副本Tip界面

			ChangeScene, //切换场景关闭所有的UI  //PlayerLeaveWorld, 
			EnterScene,

			UpdateSkill,//Open Skill Panel 更新技能面板或者技能按钮
			MovePlayer,

			MonsterDead,
			KnockBack,

			OpenShortCut,
			UpdateShortCut,

			OpenMall,

			TryEquip, //FakeUI 对象尝试穿上新的时装 NpcEquipment 处理该事件

			UpdateTeam,
			UpdateTeamInfo,

			UpdateCopyList,
			SelectCopy,

			TeamStateChange,
			UpdateShenPi,


			UpdateLogin,

			UpdateSelectChar,

			OkEnter,//进入某个场景

			NewChatMsg,
			OpenAchievement,

			UpdateVip,
			openVip,


			EventTrigger = 10000,//动画的Hit事件
			EventStart = 10001,
		

			SpawnParticle = 10002,
			EventMissileDie = 10003,

			EventEnd = 10004,

			UpdateTask,
			openTask,

			PlayerDead,
			
			*/
		}

/*
		public long localID = -1;
		public EventType type;
		public string strArg;
		public int intArg = -1;
		public int intArg1 = 0;
		public float floatArg = 0;
		public bool boolArg = false;
		//public ActionItem actionItem = null;
		public EquipData equipData = null;
		public GameObject player;
		public Vector2 vec2;

		public LevelInfo levelInfo;

		public GCPushTeamInvite teamInvite;

		public RolesInfo rolesInfo;

		public string particle;

		public string boneName;

		public Vector3 particleOffset;

        public Transform missile;
		public MyEvent(EventType t) {
			type = t;
		}*/
	}

	public delegate void EventDel(MyEvent evt);
	public interface IEventDispatcher {
		void RegisterEvent (string evtName, EventDel callback);
		void dropListener (string evtName, EventDel callback);
		void PushEvent (MyEvent evt);
	}

	public class MyEventSystem : MonoBehaviour
	{
        static int LocalCoff = 100000;
		public static List<EventHandler.IEventHandler> eventHandlers = new List<EventHandler.IEventHandler>() {
			//new  EventHandler.SpawnParticleHandler(),
		};

		public static MyEventSystem myEventSystem;

		void Awake() {
			myEventSystem = this;
			DontDestroyOnLoad (gameObject);

			//Log.AI ("Init all Event Handler");
			foreach (EventHandler.IEventHandler handler in eventHandlers) {
				handler.Init();
				handler.RegEvent();
			}
		}


		Dictionary<MyEvent.EventType, List<EventDel>> m_listeners = new Dictionary<MyEvent.EventType, List<EventDel>>();


		Dictionary<long, List<EventDel>> localListener = new Dictionary<long, List<EventDel>> ();

		public void RegisterEvent(MyEvent.EventType evtName, EventDel callback) {
			List<EventDel> evtListeners = null;
			if (m_listeners.TryGetValue (evtName, out evtListeners)) {
				//evtListeners.Remove (callback);
				evtListeners.Add (callback);
			} else {
				evtListeners = new List<EventDel>();
				evtListeners.Add(callback);
				m_listeners.Add(evtName, evtListeners);
			}
			//Log.Important ("RegisterEvent "+evtName+" "+callback);
		}

		public void RegisterLocalEvent(int localId, MyEvent.EventType type, EventDel callback) {
			List<EventDel> evtListeners = null;
			var key = (long)localId * LocalCoff + (int)type;
            //Log.Sys("RegLocalEvent is "+localId+" "+key+" "+type.ToString());
			if (localListener.TryGetValue (key, out evtListeners)) {
				evtListeners.Add (callback);
			} else {
				evtListeners = new List<EventDel>();
				evtListeners.Add(callback);
				localListener.Add(key, evtListeners);
			}
		}

		public void DropLocalListener(int localId, MyEvent.EventType type, EventDel callback) {
			List<EventDel> evtListeners = null;
			var key = (long)localId * LocalCoff + (int)type;
            //Log.Sys("DropLocalListener "+localId+" "+type+" "+key);
			if (localListener.TryGetValue (key, out evtListeners)) {
				evtListeners.Remove(callback);
			}
		}

		public void PushLocalEvent(int localId, MyEvent.EventType type) {
			//var evt = new MyEvent (type);
			//evt.localID = localId;
			//PushLocalEvent (localId, evt);
		}

		public void PushLocalEvent(long localId, MyEvent evt) {
         
			List<EventDel> evtListeners = null;
			//var key = (long)localId * LocalCoff + (int)evt.type;
            //Log.Sys("PushLocalEvent "+" "+key+" "+evt.type.ToString());
            //if (localListener.TryGetValue (key, out evtListeners)) {
			//	//小心不要在事件处理过程中删除掉事件DropEvent
			//	var nevt = evtListeners.ToArray();
			//	for(int i=0; i < nevt.Length; i++) {
			//		nevt[i](evt);
			//	}
			//}
		}


		public void dropListener(MyEvent.EventType evtName, EventDel callback) {
			List<EventDel> evtListener = null;
			if (m_listeners.TryGetValue (evtName, out evtListener)) {
				evtListener.Remove(callback);
			}
		}

		public void PushEvent(MyEvent evt) {
			List<EventDel> evtListeners = null;
            //if (m_listeners.TryGetValue (evt.type, out evtListeners)) {
            //    //小心不要在事件处理过程中删除掉事件DropEvent
            //    var nevt = evtListeners.ToArray();
            //    for(int i =0; i < nevt.Length; i++) {
            //        nevt[i](evt);
            //    }
            //}
		}

		public void PushEvent(MyEvent.EventType evt) {
			//PushEvent (new MyEvent (evt));
		}

	}

}
