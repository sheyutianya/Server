
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
using System.Reflection;
using System;
using System.Linq;


using Utils;

namespace ChuMeng
{
	public class ObjectManager : MonoBehaviour
	{
        //Dictionary<int, GameObject> fakeObjects = new Dictionary<int,GameObject> ();
        //public static ObjectManager objectManager;
        //public KBEngine.KBPlayer myPlayer;
        ///*
        // * Player And Player Related GameObject
        // */ 
        //public Dictionary<long, KBEngine.KBPlayer> Actors = new Dictionary<long, KBEngine.KBPlayer> ();
        //List<KBEngine.KBNetworkView> photonViewList = new List<KBEngine.KBNetworkView> ();
        ///*
        // * Monster Killed By Player
        // */ 
        ////TODO: 使用MyEventSystem 来发送事件
        //public VoidDelegate killEvent;

        ///// <summary>
        ///// 获得玩家实体对象
        ///// </summary>
        //public KBEngine.KBNetworkView GetPhotonView (long viewID)
        //{
        //    KBEngine.KBNetworkView result = null;
        //    foreach (KBEngine.KBNetworkView view in photonViewList) {
        //        if (view.GetServerID () == viewID && view.IsPlayer) {
        //            return view;
        //        }
        //    }
        //    return null;
        //}

        //public GameObject GetFakeObj (int localId)
        //{
        //    GameObject g;
        //    if (fakeObjects.TryGetValue (localId, out g)) {
        //        return g;
        //    }
        //    return null;
        //}

        ////对象不一定是服务器对象因此通过localId来区分
        //public GameObject GetLocalPlayer (int localId)
        //{
        //    foreach (KBEngine.KBNetworkView p in photonViewList) {
        //        if (p.GetLocalId () == localId) {
        //            return p.gameObject;
        //        }
        //    }
        //    return null;
        //}

        //public GameObject GetMyPlayer ()
        //{
        //    if (myPlayer != null) {
        //        var vi = GetPhotonView (myPlayer.ID);
        //        if (vi != null) {
        //            return vi.gameObject;
        //        }
        //    }
        //    return null;
        //}

        ////获得玩家自身或者其它玩家的属性数据
        //public GameObject GetPlayer (long playerId)
        //{
        //    var view = GetPhotonView (playerId);
        //    if (view != null) {
        //        return view.gameObject;
        //    }
        //    return null;
        //}

        ////登录的时候 从SelectChar中获取等级数据 
        ////平时从 CharacterInfo 数据源获取数据
        ////因为CharacterInfo 数据的初始化是在CreateMyPlayer 之后的
        ////CharacterInfo SetProps Level 这里的值也要修改
        ////public int GetMyLevel ()
        ////{
        ////    return SaveGame.saveGame.selectChar.Level;
        ////}

        ///*
        // * User Data:
        // * 		1 SaveGame  static Data Not Changed in Game
        // * 		2 CharacterData   Dynamic Data Changed in Game
        // * 		3 SaveGame InitPosition use once 
        // */ 

        ///*
        // * SaveGame selectChar has My PlayerID
        // * But Here just Return -1 As My Id
        // */ 
        //public long GetMyServerID ()
        //{
        //    if (myPlayer != null) {
        //        return myPlayer.ID;
        //    }
        //    return -1;
        //}

        ///*
        // * Local Allocated NpcID
        // */ 
        //public int GetMyLocalId ()
        //{
        //    if (myPlayer != null) {
        //        //Log.Sys ("Local PlayerID " + myPlayer.ID);
        //        var view = GetPhotonView (myPlayer.ID);
        //        var lid = view.GetLocalId ();
        //        //Log.Sys("LocalId is "+lid+" "+view.gameObject.name);
        //        return lid;
        //    }

        //    //Debug.LogError("Not Found MyPlayer "+myPlayer);
        //    return -1;
        //}

        ///// <summary>
        ///// 返回玩家上一次离开主城的初始位置 存储在数据池中
        ///// </summary>
        ///// <returns>The my init position.</returns>
        //private Vector3 GetMyInitPos ()
        //{
        //    //var x = SaveGame.saveGame.bindSession.X;
        //    //var y = SaveGame.saveGame.bindSession.Y;
        //    //var z = SaveGame.saveGame.bindSession.Z;

        //    //var coord = Util.GridToCoord (x, z);
        //    ////Get Floor Y Offset By RayCast
        //    ////Current Scene Height
        //    //var AStar = GameObject.Find ("AStar").GetComponent<AstarPath> ();
        //    ////Scene Height Data 
        //    //var gridGraph = AStar.graphs [0] as Pathfinding.GridGraph;
        //    //var gridIndex = (int)(z) * gridGraph.width + (int)(x);
        //    //Debug.Log ("ObjectManager::GetMyInitPos GridIndex" + gridIndex);
        //    //var n = gridGraph.nodes [gridIndex];

        //    //var hei = (Vector3)(n.Position);
        //    //var ret = new Vector3 (coord.x, hei.y + 0.1f, coord.y);
        //    //Debug.Log ("Pos " + ret);
        //    return new Vector3(0f, 0f, 0f);
        //}

        //public float GetSceneHeight (int x, int z)
        //{
        //    //var AStar = GameObject.Find ("AStar").GetComponent<AstarPath> ();
        //    ////Scene Height Data 
        //    //var gridGraph = AStar.graphs [0] as Pathfinding.GridGraph;
        //    //var gridIndex = (int)(z) * gridGraph.width + (int)(x);
        //    //Debug.Log ("ObjectManager::GetMyInitPos GridIndex" + gridIndex);
        //    //var n = gridGraph.nodes [gridIndex];
			
        //    //var hei = (Vector3)(n.Position);
        //    ///return hei.y + 0.1f;
        //}

        //private Vector3 GetMyInitRot ()
        //{
        //    var dir = SaveGame.saveGame.bindSession.Direction;
        //    return Quaternion.Euler (new Vector3 (0, dir, 0)) * Vector3.forward;
        //}

        //public string GetMyName ()
        //{
        //    return SaveGame.saveGame.selectChar.Name;
        //}


        ///*
        // * TODO: Get Player Data From CharacterDataController
        // * RolesInfo is Just LoginInit Data
        // * 
        // * When Login Success,  SaveGame Should Set RolesInfo into CharacterData
        // * 
        // * Other ExtraAttribute  Use Script Or Json Loader to Get Attribute
        // */ 
        //public CharacterData GetMyData ()
        //{
        //    return CharacterData.characterData;
        //}

        //public int GetMyJob ()
        //{
        //    return (int)SaveGame.saveGame.selectChar.Job;
        //}

        //void Awake ()
        //{
        //    objectManager = this;
        //    DontDestroyOnLoad (this.gameObject);
        //}

        ////增加一个玩家实体对象
        //private void AddObject (long unitId, KBEngine.KBNetworkView view)
        //{
        //    photonViewList.Add (view);
        //}

        ///*
        // * PlayerId MySelf self is -1
        // * TODO:如果WorldManager正在进入新的场景，则缓存当前的服务器推送的Player,等待彻底进入场景再初始化Player
        // * TODO:CScene 进入场景之后解开缓存的Player数据
        // */
        //private void AddPlayer (long unitId, KBEngine.KBPlayer player)
        //{
        //    if (WorldManager.worldManager.station == WorldManager.WorldStation.Enter) {
        //        Actors.Add (unitId, player);
        //    } else {
        //        throw new SystemException ("正在切换场景，增加新的Player失败");
        //    }
        //}

        ///*
        // * Synchronize All Local KBNetworkview Data To Server
        // * Position direction
        // */ 
        //public void RunViewUpdate ()
        //{
        //    //单人副本不用更新我的状态到服务器
        //    if (WorldManager.worldManager.sceneType == WorldManager.SceneType.Single) {
        //        return;
        //    }
        //    var player = GetMyPlayer ();
        //    if (player != null) {
        //        var sync = player.GetComponent<PlayerSync> ();

        //        KBEngine.Packet packet = new KBEngine.Packet ();
        //        sync.OnPhotonSerializeView (packet);

        //        KBEngine.Bundle bundle = new KBEngine.Bundle ();
        //        bundle.newMessage (packet.protoBody.GetType ());
        //        var fid = bundle.writePB (packet.protoBody);
        //        bundle.send (KBEngine.KBEngineApp.app.networkInterface (), null, fid);
        //    }
        //    /*
        //    foreach (KBEngine.KBNetworkView kv in photonViewList) {
        //        KBEngine.KBNetworkView view = kv;
        //        if ( view.synchroniztion != KBEngine.KBNetworkView.ViewSynchronization.Off) {
        //            if (view.owner == ObjectManager.objectManager.myPlayer && view.IsPlayer) {
        //                if (!view.gameObject.activeSelf) {
        //                } else {
        //                    KBEngine.Packet packet = new KBEngine.Packet ();

        //                    //得到玩家的同步数据
        //                    var monob = (MonoBehaviour)view.GetComponent<PlayerSync>();

        //                    var methodInfo = GetCachedMethod (monob, "OnPhotonSerializeView");
        //                    object[] paramsX = new object[1];
        //                    paramsX [0] = packet;
        //                    object result = methodInfo.Invoke (monob, paramsX);
								
        //                    KBEngine.Bundle bundle = new KBEngine.Bundle ();
        //                    bundle.newMessage (packet.protoBody.GetType ());
        //                    var fid = bundle.writePB (packet.protoBody);
        //                    bundle.send (KBEngine.KBEngineApp.app.networkInterface (), null, fid);
								
        //                    //}
        //                }
        //            }
        //        }
        //    }
        //    */
        //}

        ///*
        // * OnDestroy Clean PhotonView 
        // */ 
        //public void RunViewUpdate (KBEngine.KBNetworkView view, Google.ProtocolBuffers.IMessageLite msg)
        //{
        //    if (!view.gameObject.activeSelf) {
        //    } else {
        //        KBEngine.Packet packet = new KBEngine.Packet ();
        //        packet.protoBody = msg;
        //        var monob = (MonoBehaviour)view.GetComponent<PlayerSync> ();
        //        var methodInfo = GetCachedMethod (monob, "OnPhotonSerializeView");
        //        object[] paramsX = new object[1];
        //        paramsX [0] = packet;
        //        object result = methodInfo.Invoke (monob, paramsX);

        //    }

        //}

        //Dictionary<Type, Dictionary<string, MethodInfo>> cachedMethods = new Dictionary<Type, Dictionary<string, MethodInfo>> ();
		
        //public MethodInfo GetCachedMethod (MonoBehaviour monob, string methodName)
        //{
        //    Type type = monob.GetType ();
        //    if (!this.cachedMethods.ContainsKey (type)) {
        //        var newMethod = new Dictionary<string, MethodInfo> ();
        //        cachedMethods.Add (type, newMethod);
        //    }
        //    var methods = cachedMethods [type];
        //    if (!methods.ContainsKey (methodName)) {
        //        MethodInfo metInfo = monob.GetType ().GetMethod (methodName);
        //        if (metInfo != null) {
        //            methods.Add (methodName, metInfo);
        //        }
        //    }
        //    MethodInfo minfo = null;
        //    methods.TryGetValue (methodName, out minfo);
        //    return minfo;
        //}

        ///*
        // * Remove View's Owner ID == PlayerID
        // */ 
        //public void ClearPlayer (HideSprite hp)
        //{
        //    Debug.Log ("ObjectManager::ClearPlayer clearPlayer Quit Game " + hp);
        //    DestroyObject (hp.UnitId.Id);
        //}

        //void SaveMyPosAndRot ()
        //{
        //    if (WorldManager.worldManager.GetActive ().IsCity) {
        //        var my = GetMyPlayer ();
        //        var grid = Util.CoordToGrid (my.transform.position);

        //        GCBindingSession.Builder bind = GCBindingSession.CreateBuilder (SaveGame.saveGame.bindSession);
        //        bind.X = System.Convert.ToInt32 (grid.x);
        //        bind.Y = (int)grid.y;
        //        bind.Z = (int)grid.z;
        //        bind.Direction = (int)transform.localRotation.eulerAngles.y;
        //        SaveGame.saveGame.bindSession = bind.BuildPartial ();
        //    }
        //}

        //public void DestroyByLocalId (int localId)
        //{
        //    var keys = photonViewList.Where (f => true).ToArray ();
        //    foreach (KBEngine.KBNetworkView v in keys) {
        //        if (v.GetLocalId () == localId) {
        //            photonViewList.Remove (v);
        //            FakeObjSystem.fakeObjSystem.DestroyObject (v.GetLocalId ());
        //            GameObject.Destroy (v.gameObject);
        //            break;
        //        }
        //    }
        //}

        ////删除Player和PhotonView
        //public void DestroyObject (long playerID)
        //{
        //    ///<summary>
        //    /// 删除自己玩家的时候需要保存玩家的位置和角度
        //    /// </summary>
        //    if (myPlayer != null && myPlayer.ID == playerID) {
        //        SaveMyPosAndRot ();
        //        myPlayer = null;
        //    }

        //    //摧毁某个玩家所有的PhotonView对象  Destroy Fake object Fist Or Send Event ?
        //    var keys = photonViewList.Where (f => true).ToArray ();
        //    foreach (KBEngine.KBNetworkView v in keys) {
        //        if (v.GetServerID () == playerID) {
        //            photonViewList.Remove (v);
        //            FakeObjSystem.fakeObjSystem.DestroyObject (v.GetLocalId ());
        //            GameObject.Destroy (v.gameObject);
        //            //break;

        //        }
        //    }

        //    if (Actors.ContainsKey (playerID)) {
        //        Actors.Remove (playerID);
        //    } else {
        //        Debug.LogError ("ObjectManager::clearPlayer No Such Player " + playerID);
        //    }

        //}
        ///// <summary>
        ///// 摧毁自己玩家对象和单人副本怪物对象
        ///// </summary>
        //public void DestroyMySelf ()
        //{
        //    MyEventSystem.myEventSystem.PushEvent (MyEvent.EventType.PlayerLeaveWorld);
        //    //删除我自己玩家
        //    DestroyObject (myPlayer.ID);

        //}


        ///*
        // * 显示私聊人物信息
        // */ 
        //public void ShowCharInfo (GCLoadMChatShowInfo info)
        //{
        //}

        ////加载对应模型的基础职业骨架 FakeObject
        //public GameObject NewFakeObject (int localId)
        //{
        //    //每次显示都要初始化一下FakeObj的装备信息
        //    if (fakeObjects.ContainsKey (localId)) {
        //        fakeObjects [localId].GetComponent<NpcEquipment> ().InitFakeEquip ();
        //        return fakeObjects [localId];
        //    }

        //    var player = GetLocalPlayer (localId);
        //    var job = player.GetComponent<NpcAttribute> ().ObjUnitData.job;
        //    Log.Important ("DialogPlayer is " + job.ToString ());
        //    var fakeObject = Instantiate (Resources.Load<GameObject> ("DialogPlayer/" + job.ToString ())) as GameObject;
        //    fakeObject.SetActive (false);
        //    fakeObjects [localId] = fakeObject;
        //    fakeObject.GetComponent<NpcEquipment> ().SetFakeObj ();
        //    fakeObject.GetComponent<NpcEquipment> ().SetLocalId (localId);
        //    fakeObject.GetComponent<NpcEquipment> ().InitFakeEquip ();

        //    Util.SetLayer (fakeObject, GameLayer.PlayerCamera);
        //    return fakeObject;
        //}

        ////当玩家对象被删除的时候,删除对应的玩家的FakeObj
        //public void DestroyFakeObj (int localId)
        //{
        //    var fake = GetFakeObj (localId);
        //    if (fake != null) {
        //        fakeObjects.Remove (localId);
        //        GameObject.Destroy (fake);
        //    }
        //}

        ///// <summary> 
        ///// 我方玩家构建流程 副本内
        ///// 
        ///// 角色的初始化位置不同
        ///// </summary>
        //public GameObject CreateMyPlayer ()
        //{
        //    var kbplayer = new KBEngine.KBPlayer ();
        //    kbplayer.ID = SaveGame.saveGame.selectChar.PlayerId;
        //    kbplayer.type = KBEngine.KBPlayer.PlayerType.Player;
        //    if (myPlayer != null) {
        //        throw new System.Exception ("myPlayer not null");
        //    }

        //    myPlayer = kbplayer;
			
        //    var job = (ChuMeng.Job)GetMyJob ();
        //    var udata = Util.GetUnitData (true, (int)job, GetMyLevel ());
        //    var player = Instantiate (Resources.Load<GameObject> (udata.ModelName)) as GameObject;
        //    NGUITools.AddMissingComponent<NpcAttribute>(player);
        //    NGUITools.AddMissingComponent<PlayerMoveController> (player);
        //    player.tag = "Player";
        //    player.layer = (int)GameLayer.Npc;
        //    player.transform.parent = transform;


        //    //设置自己玩家的View属性
        //    var view = player.GetComponent<KBEngine.KBNetworkView> ();
        //    Log.Important ("SelectCharID " + SaveGame.saveGame.selectChar.PlayerId);
        //    view.SetID (new KBEngine.KBViewID (SaveGame.saveGame.selectChar.PlayerId, kbplayer));

        //    Log.Important ("Set UnitData of Certain Job " + udata);
        //    player.GetComponent<NpcAttribute> ().SetObjUnitData (udata);

        //    player.name = "playerSeperate";
        //    var startPoint = GameObject.Find ("PlayerStart");
        //    player.transform.position = startPoint.transform.position;
        //    player.transform.forward = startPoint.transform.forward;
        //    ObjectManager.objectManager.AddObject (SaveGame.saveGame.selectChar.PlayerId, view);
			
        //    Debug.Log ("LevelInit::Awake Initial kbplayer Initial KbNetowrkView " + kbplayer + " " + view);

        //    return player;
        //}


        /////<summary>
        ///// 我方玩家构建流程 野外主城 可能从副本退出 也可能是刚登陆
        ///// 从副本退出则初始位置在刚才进入副本的位置
        ///// 初次登陆的初始位置在登陆的属性中
        ///// 
        ///// 角色的初始化位置不同
        /////</summary> 
        //public GameObject CreateLoginMyPlayer ()
        //{
        //    var kbplayer = new KBEngine.KBPlayer ();
        //    kbplayer.ID = SaveGame.saveGame.selectChar.PlayerId;
        //    kbplayer.type = KBEngine.KBPlayer.PlayerType.Player;

        //    myPlayer = kbplayer;

        //    var job = (ChuMeng.Job)ObjectManager.objectManager.GetMyJob ();
        //    var udata = Util.GetUnitData (true, (int)job, GetMyLevel ());

        //    var player = Instantiate (Resources.Load<GameObject> (udata.ModelName)) as GameObject;
        //    NGUITools.AddMissingComponent<NpcAttribute>(player);
        //    NGUITools.AddMissingComponent<PlayerMoveController> (player);
        //    player.tag = "Player";
        //    player.layer = (int)GameLayer.Npc;
        //    player.transform.parent = transform;
        //    player.GetComponent<NpcAttribute> ().SetObjUnitData (udata);
		
        //    player.name = "playerSeperate";
        //    player.transform.parent = gameObject.transform;

        //    player.transform.position = GetMyInitPos ();
        //    player.transform.forward = GetMyInitRot ();
        //    var view = player.GetComponent<KBEngine.KBNetworkView> ();
        //    Log.Important ("SelectCharID " + SaveGame.saveGame.selectChar.PlayerId);
			
        //    view.SetID (new KBEngine.KBViewID (SaveGame.saveGame.selectChar.PlayerId, kbplayer));
        //    ObjectManager.objectManager.AddObject (SaveGame.saveGame.selectChar.PlayerId, view);
			
        //    Debug.Log ("LevelInit::Awake Initial kbplayer Initial KbNetowrkView " + kbplayer + " " + view);
        //    return player;
        //}

        //List<ViewPlayer> cacheInitPlayer = new List<ViewPlayer> ();
        //class MonsterInit
        //{
        //    public UnitData unitData;
        //    public SpawnTrigger spawn;

        //    public MonsterInit (UnitData ud, SpawnTrigger sp)
        //    {
        //        unitData = ud;
        //        spawn = sp;
        //    }
        //}
        //List<MonsterInit> cacheMonster = new List<MonsterInit> ();

        //public void InitCache ()
        //{
        //    InitCachePlayer ();
        //    InitCacheMonster ();
        //}

        //void InitCachePlayer ()
        //{
        //    foreach (ViewPlayer vp in cacheInitPlayer) {
        //        CreatePlayer (vp);
        //    }
        //    cacheInitPlayer.Clear ();
        //}

        //void InitCacheMonster ()
        //{
        //    foreach (MonsterInit m in cacheMonster) {
        //        CreateMonster (m.unitData, m.spawn);
        //    }
        //    cacheMonster.Clear ();
        //}

        /////<summary>
        ///// 其它玩家构建流程 主城内 或者副本内
        ///// </summary> 
        ////TODO:ViewPlayer 需要增加一个场景ID用于标示这个player当前场景，如果和游戏场景不同则不能初始化
        //public void CreatePlayer (ViewPlayer vp)
        //{
        //    if (WorldManager.worldManager.station == WorldManager.WorldStation.Enter) {
        //        Log.Trivial (Log.Category.System, "Init Player is " + vp);
        //        Debug.Log ("GCPushSpriteInfo::CreatePlayer  Create OtherPlayer");
	
        //        var kbplayer = new KBEngine.KBPlayer ();
        //        kbplayer.ID = vp.UnitId.Id;

        //        var udata = Util.GetUnitData (true, (int)vp.Job, vp.PlayerLevel);
        //        var player = GameObject.Instantiate (Resources.Load<GameObject> (udata.ModelName)) as GameObject;
        //        NGUITools.AddMissingComponent<NpcAttribute>(player);
        //        NGUITools.AddMissingComponent<PlayerMoveController>(player);
        //        player.tag = "Player";
        //        player.layer = (int)GameLayer.Npc;
        //        //NGUITools.AddMissingComponent<PhysicComponent>(player);

        //        NGUITools.AddMissingComponent<SkillInfoComponent> (player);
        //        player.GetComponent<NpcAttribute> ().SetObjUnitData (udata);


        //        player.name = "player_" + vp.UnitId.Id;
        //        player.transform.parent = gameObject.transform;
				
				
        //        var netview = player.GetComponent<KBEngine.KBNetworkView> ();
        //        netview.SetID (new KBEngine.KBViewID (kbplayer.ID, kbplayer));
				
        //        var sync = player.GetComponent<ChuMeng.PlayerSync> ();
        //        sync.SetPosition (vp);
				
        //        //CallNetwork Instantiate Object
        //        AddPlayer (kbplayer.ID, kbplayer);
        //        AddObject (netview.GetServerID (), netview);


        //    } else if (WorldManager.worldManager.station == WorldManager.WorldStation.Entering) {
        //        //正在加载新的场景的静态资源，因此需要缓存其它的玩家，等初始化完成再 构建玩家
        //        cacheInitPlayer.Add (vp);

        //    } else {
        //        Debug.LogError ("该状态不能接受其它玩家的构建请求 " + WorldManager.worldManager.station + "  " + vp.ToString ());
        //    }
        //}


        /////<summary>
        ///// 副本内怪物构建流程
        ///// 单人副本通过Scene配置来产生怪物
        ///// 多人副本通过服务器推送消息产生怪物
        ///// </summary>
        ////TODO: 多人副本怪物产生机制
        //public void CreateMonster (UnitData unitData, SpawnTrigger spawn)
        //{
        //    if (WorldManager.worldManager.station == WorldManager.WorldStation.Enter) {
        //        var Resource = Resources.Load<GameObject> (unitData.ModelName);
        //        //本地怪兽不需要Player信息
        //        GameObject g = Instantiate(Resource) as GameObject;
        //        NpcAttribute npc = NGUITools.AddMissingComponent<NpcAttribute>(g);
        //        NGUITools.AddMissingComponent<NpcAI>(g);
        //        g.transform.parent = transform;
        //        g.tag = GameTag.Enemy;
        //        g.layer = (int)GameLayer.Npc;

        //        var charInfo = g.GetComponent<CharacterInfo>();
        //        var skillInfo = g.GetComponent<SkillInfoComponent> ();
        //        var netView = g.GetComponent<KBEngine.KBNetworkView> ();
        //        netView.SetID (new KBEngine.KBViewID (myPlayer.ID, myPlayer));
        //        netView.IsPlayer = false;

        //        npc.SetObjUnitData (unitData);
        //        AddObject (netView.GetServerID (), netView);

			
        //        float angle = UnityEngine.Random.Range (0, 360);
        //        Vector3 v = Vector3.forward;
        //        v = Quaternion.Euler (new Vector3 (0, angle, 0)) * v;
        //        float rg = UnityEngine.Random.Range (0, spawn.Radius);

        //        npc.transform.position = spawn.transform.position + v * rg;

        //        BattleManager.battleManager.enemyList.Add (npc.gameObject);
        //        npc.SetDeadDelegate = BattleManager.battleManager.EnemyDead;
        //        npc.Level = spawn.Level;
        //    } else {
        //        cacheMonster.Add (new MonsterInit (unitData, spawn));
        //    }
        //}

        //public void CreatePet (int monsterId, GameObject owner, Affix affix, Vector3 pos)
        //{
        //    Log.Sys("Create Pet "+monsterId+" "+owner+" "+pos);
        //    var unitData = Util.GetUnitData (false, monsterId, 1);

        //    var Resource = Resources.Load<GameObject> (unitData.ModelName);

        //    GameObject g = Instantiate(Resource) as GameObject;
        //    NpcAttribute npc = NGUITools.AddMissingComponent<NpcAttribute> (g);
        //    var type = Type.GetType ("ChuMeng."+unitData.AITemplate);
        //    var t = typeof(NGUITools);
        //    var m = t.GetMethod ("AddMissingComponent");
        //    Log.AI ("Create Certain AI  "+unitData.AITemplate+" "+type);
        //    var geMethod = m.MakeGenericMethod (type);
        //    var petAI = geMethod.Invoke(null, new object[]{g}) as AIBase;
        //    //var petAI = NGUITools.AddMissingComponent<type> (g);

        //    g.transform.parent = transform;
        //    g.tag = owner.tag;
        //    g.layer = (int)GameLayer.Npc;


        //    npc.SetOwnerId (owner.GetComponent<KBEngine.KBNetworkView>().GetLocalId());
        //    //不可移动Buff
        //    //持续时间Buff
        //    //无敌不可被攻击Buff
        //    //火焰陷阱的特点 特点组合
        //    g.GetComponent<BuffComponent> ().AddBuff (affix);

        //    var netView = NGUITools.AddMissingComponent<KBEngine.KBNetworkView> (g);
        //    netView.SetID (new KBEngine.KBViewID (myPlayer.ID, myPlayer));
        //    netView.IsPlayer = false;
			
        //    npc.SetObjUnitData (unitData);
        //    AddObject (netView.GetServerID (), netView);

        //    npc.transform.position = pos;	
        //}
        ////Npc构建流程 副本或者主城内

        //public static string GetEnemyTag(string tag) {
        //    if (tag == GameTag.Player) {
        //        return GameTag.Enemy;
        //    }
        //    return GameTag.Player;
        //}
        
	}

}