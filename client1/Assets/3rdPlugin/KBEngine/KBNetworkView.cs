
/*
Author: liyonghelpme
Email: 233242872@qq.com
*/

/*
Author: liyonghelpme
Email: 233242872@qq.com
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace KBEngine
{
	/*
	 * Player In Room
	 * ID Assigned By Server
	 */ 
	/// <summary>
	/// 服务器对象
	/// </summary>
	public class KBPlayer
	{
		public long ID = -1;
		/*
		 * 0 Player 1 Monster 2 pet
		 */ 
		public enum PlayerType
		{
			Player = 0,
			Monster = 1,
			Pet = 2,
		}
		public PlayerType type = PlayerType.Player;
	

	}

	/*
	 * Allocated By Local For NetworkIdentity
	 */ 
	/// <summary>
	/// 服务器对象下面衍生的 本地对象 或者服务器对象
	/// 例如单人副本里面的怪物 为本地对象
	///	多人副本里面的怪物则为 服务器对象
	/// 
	/// 我的服务器对象对应多个本地对象 玩家实体和怪物实体
	/// </summary>
	public class KBViewID
	{
		long internalID = -1;
		KBPlayer internalPlayer;

		public KBPlayer owner {
			get {
				return internalPlayer;
			}
		}
		public long ServerID {
			get {
				return internalID;
			}
		}
		public KBViewID (long id, KBPlayer player)
		{
			internalID = id;
			internalPlayer = player;
		}	
	}

	public class MonoBehaviour : UnityEngine.MonoBehaviour
	{
		protected List<ChuMeng.MyEvent.EventType> regEvt = null;
		protected List<ChuMeng.MyEvent.EventType> regLocalEvt = null;

		protected void RegEvent ()
		{
			if (regEvt != null) {
				foreach (ChuMeng.MyEvent.EventType t in regEvt) {
					ChuMeng.MyEventSystem.myEventSystem.RegisterEvent (t, OnEvent);
				}
			}

			if (regLocalEvt != null) {
				foreach(ChuMeng.MyEvent.EventType t in regLocalEvt) {
					ChuMeng.MyEventSystem.myEventSystem.RegisterLocalEvent(photonView.GetLocalId(), t, OnLocalEvent);
				}
			}

		}

		protected virtual void OnLocalEvent(ChuMeng.MyEvent evt) {
		
		}

		protected void DropEvent()  {
			if (regEvt != null) {
				foreach(ChuMeng.MyEvent.EventType t in regEvt) {
					ChuMeng.MyEventSystem.myEventSystem.dropListener(t, OnEvent);
				}
			}

			if (regLocalEvt != null) {
				foreach(ChuMeng.MyEvent.EventType t in regLocalEvt) {
					ChuMeng.MyEventSystem.myEventSystem.DropLocalListener(photonView.GetLocalId(), t, OnLocalEvent);
				}
			}
		}

		protected virtual void OnEvent(ChuMeng.MyEvent evt) {
		}

		protected virtual void OnDestroy() {
			DropEvent ();
		}
		public KBNetworkView photonView {
			get {
				return GetComponent<KBNetworkView> ();
			}
		}

		protected void AddEvent(ChuMeng.MyEvent.EventType t) {
			regEvt.Add (t);
			ChuMeng.MyEventSystem.myEventSystem.RegisterEvent (t, OnEvent);
		}
	}
	/*
	 * Player ---> Multiple View
	 * ViewID ---> Owner Player Owner ID
	 */ 
	public class KBNetworkView : MonoBehaviour
	{
		/*
		 * Client Object ID
		 */ 
		//Awake的初始化在 私有变量 int 赋值之后？还是之前Public 遗留的问题？
		static int LocalID = 0;

		public void SetLocalId (int lid)
		{
			localId = lid;
		}

		int localId = -1;
		public int GetLocalId() {
			if (localId == -1) {
				localId = LocalID++;
				//Log.Sys("Initial local Id "+localId);
			}
			//Log.Sys ("GetLocalId of "+gameObject.name+" "+localId);
			return localId;
		}
		/*
		 * Allocate by Master or local
		 * For Local allocate new ID
		 * 
		 * Server ID 
		 * Server Object Player
		 */ 
		KBViewID ID = new KBViewID (0, null);

		public long GetServerID ()
		{
			if (ID.owner == null) {
				Debug.Log ("KBNetworkView:: not net connection ");
				return -1;
			}
			return ID.owner.ID;
		}
		public void SetID(KBViewID id) {
			ID = id;
		}

		/// <summary>
		/// 是玩家还是怪物或者宠物等对象
		/// </summary>
		public bool IsPlayer = true;

		//是否是本地玩家
		public bool IsMine {
			get {
				//return viewID.owner == KBEngineApp.app.player;
				if (ID.owner == null) {
					Debug.Log ("KBNetworkView:: No NetworkConnect Init Player Is Mine");
					return true;
				}
				//return ID.owner == ChuMeng.ObjectManager.objectManager.myPlayer && IsPlayer;
			    return false;
			}
		}
		void Start() {
			//localId = LocalID++;
			//Log.Sys ("Implement Local ID "+localId+" "+gameObject.name);
		}
		void Awake ()
		{
			//localId = LocalID++;
		}

	}

}