////using UnityEngine;

using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using Google.ProtocolBuffers;
//using SimpleJSON;

namespace ChuMeng
{
	public class MyCon {
		public Socket connect;
		public bool isClose = false;
		public MyCon(Socket s) {
			connect = s;
		}
	}

	public class ServerThread {
		string packInf = @"
[
	{""id"": 4, ""baseId"" : 11, ""index"" : 3, ""cdTime"" : 0, ""goodsType"" : 0, ""count"" : 1},

    {""id"": 5, ""baseId"" : 12, ""index"" : 4, ""cdTime"" : 0, ""goodsType"" : 0, ""count"" : 1},
    
    {""id"": 6, ""baseId"" : 13, ""index"" : 5, ""cdTime"" : 0, ""goodsType"" : 1, ""count"" : 1},
    
    {""id"": 7, ""baseId"" : 14, ""index"" : 6, ""cdTime"" : 0, ""goodsType"" : 1, ""count"" : 1},

    {""id"": 8, ""baseId"" : 15, ""index"" : 7, ""cdTime"" : 0, ""goodsType"" : 1, ""count"" : 1},

    {""id"": 9, ""baseId"" : 16, ""index"" : 8, ""cdTime"" : 0, ""goodsType"" : 1, ""count"" : 1},

    
    {""id"": 10, ""baseId"" : 17, ""index"" : 9, ""cdTime"" : 0, ""goodsType"" : 1, ""count"" : 1},

    {""id"": 11, ""baseId"" : 18, ""index"" : 10, ""cdTime"" : 0, ""goodsType"" : 1, ""count"" : 1},

    {""id"": 12, ""baseId"" : 19, ""index"" : 11, ""cdTime"" : 0, ""goodsType"" : 1, ""count"" : 1},

    {""id"": 13, ""baseId"" : 20, ""index"" : 12, ""cdTime"" : 0, ""goodsType"" : 1, ""count"" : 1},

    {""id"": 14, ""baseId"" : 21, ""index"" : 13, ""cdTime"" : 0, ""goodsType"" : 1, ""count"" : 1},

    {""id"": 15, ""baseId"" : 22, ""index"" : 14, ""cdTime"" : 0, ""goodsType"" : 1, ""count"" : 1},

    {""id"": 16, ""baseId"" : 24, ""index"" : 15, ""cdTime"" : 0, ""goodsType"" : 1, ""count"" : 1},

    {""id"": 19, ""baseId"" : 26, ""index"" : 18, ""cdTime"" : 0, ""goodsType"" : 1, ""count"" : 1},

    {""id"": 20, ""baseId"" : 23, ""index"" : 19, ""cdTime"" : 0, ""goodsType"" : 1, ""count"" : 1}
]

";


		int selectPlayerJob = 4;


		MyCon con;
		Socket socket;
		ChuMeng.ServerMsgReader msgReader = new ServerMsgReader();

		List<byte[]> msgBuffer = new List<byte[]>();
		public ServerThread() {
			socket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			//socket.SetSocketOption (System.Net.Sockets.SocketOptionLevel.Socket, SocketOptionName.ReceiveBuffer, );
			socket.SetSocketOption (System.Net.Sockets.SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
			IPEndPoint ip = new IPEndPoint (IPAddress.Parse("127.0.0.1"), 20000);

			socket.Bind (ip);
			socket.Listen (1);

			msgReader.msgHandle = handleMsg;
		}
		void sendPacket(IBuilderLite retpb, uint flowId) {
			var bytes = ServerBundle.sendImmediate(retpb, flowId);
			//Debug.Log ("DemoServer: Send Packet "+flowId);
			lock (msgBuffer) {
				msgBuffer.Add(bytes);
			}
		}
		void handleMsg(KBEngine.Packet packet) {
			var receivePkg = packet.protoBody.GetType ().FullName;
			//Debug.Log ("Server Receive "+receivePkg);
			var className = receivePkg.Split(char.Parse("."))[1];
			IBuilderLite retPb = null;
			uint flowId = packet.flowId;
/*
			if (className == "CGAutoRegisterAccount") {
				var au = GCAutoRegisterAccount.CreateBuilder ();
				au.Username = "liyong";
				retPb = au;
			} else if (className == "CGRegisterAccount") {
				var au = GCRegisterAccount.CreateBuilder ();
				retPb = au;
			} else if (className == "CGLoginAccount") {
				var au = GCLoginAccount.CreateBuilder ();
				var role = RolesInfo.CreateBuilder ();
				role.Name = "刺客";
				role.PlayerId = 101;
				role.Level = 1;
				role.Job = (Job)4;
				au.AddRolesInfo (role);

				role = RolesInfo.CreateBuilder ();
				role.Name = "枪手";
				role.PlayerId = 102;
				role.Level = 1;
				role.Job = (Job)2;
				au.AddRolesInfo (role);

				role = RolesInfo.CreateBuilder ();
				role.Name = "战士";
				role.PlayerId = 103;
				role.Level = 1;
				role.Job = (Job)1;
				au.AddRolesInfo (role);
				retPb = au;
			} else if (className == "CGSelectCharacter") {
				var inpb = packet.protoBody as CGSelectCharacter;
				if (inpb.PlayerId == 101) {
					selectPlayerJob = 4;
				} else if (inpb.PlayerId == 102) {
					selectPlayerJob = 2;
				} else {
					selectPlayerJob = 1;
				}
				var au = GCSelectCharacter.CreateBuilder ();
				au.TokenId = "12345";
				retPb = au;
			} else if (className == "CGBindingSession") {
				var au = GCBindingSession.CreateBuilder ();
				au.X = 1;
				au.Y = 1;
				au.Z = 1;
				au.Direction = 10;
				au.MapId = 0;
				au.DungeonBaseId = 0;
				au.DungeonId = 0;
				retPb = au;
			} else if (className == "CGEnterScene") {
				var inpb = packet.protoBody as CGEnterScene;
				var au = GCEnterScene.CreateBuilder ();
				au.Id = inpb.Id;
				retPb = au;
			} else if (className == "CGLoadPackInfo") {
				var pk = SimpleJSON.JSONNode.Parse (packInf).AsArray;
				var inpb = packet.protoBody as CGLoadPackInfo;
				var au = GCLoadPackInfo.CreateBuilder ();
				if (inpb.PackType == PackType.DEFAULT_PACK) {
					au.PackType = PackType.DEFAULT_PACK;
					foreach (JSONNode k in pk) {
						var pinfo = PackInfo.CreateBuilder ();
						var pkentry = PackEntry.CreateBuilder ();
						pkentry.Id = k ["id"].AsInt;
						pkentry.BaseId = k ["baseId"].AsInt;
						pkentry.Index = k ["index"].AsInt;
						pinfo.CdTime = 0;
						pkentry.GoodsType = k ["goodsType"].AsInt;
						pkentry.Count = 1;
						pinfo.PackEntry = pkentry.BuildPartial ();
						au.AddPackInfo (pinfo);
					}
				} else {
					au.PackType = PackType.DRESSED_PACK;
				}
				retPb = au;
			} else if (className == "CGGetCharacterInfo") {
				var inpb = packet.protoBody as CGGetCharacterInfo;
				var au = GCGetCharacterInfo.CreateBuilder ();
				foreach (int l in inpb.ParamKeyList) {
					var att = RolesAttributes.CreateBuilder ();
					var bd = BasicData.CreateBuilder ();
					att.AttrKey = l;
					bd.Indicate = 1;
					bd.TheInt32 = 120;
					att.BasicData = bd.BuildPartial ();
					au.AddAttributes (att);
				}
				retPb = au;
			} else if (className == "CGLoadShortcutsInfo") {
				var au = GCLoadShortcutsInfo.CreateBuilder ();


				if (selectPlayerJob == 2) {
					var sh = ShortCutInfo.CreateBuilder ();
					sh.Index = 0;
					sh.IndexId = 0;
					sh.BaseId = 8;
					sh.Type = 0;
					au.AddShortCutInfo (sh);

					sh = ShortCutInfo.CreateBuilder ();
					sh.Index = 1;
					sh.IndexId = 0;
					sh.BaseId = 9;
					sh.Type = 0;
					au.AddShortCutInfo (sh);

					sh = ShortCutInfo.CreateBuilder ();
					sh.Index = 2;
					sh.IndexId = 0;
					sh.BaseId = 10;
					sh.Type = 0;
					au.AddShortCutInfo (sh);

					sh = ShortCutInfo.CreateBuilder ();
					sh.Index = 3;
					sh.IndexId = 0;
					sh.BaseId = 11;
					sh.Type = 0;
					au.AddShortCutInfo (sh);
				} else if (selectPlayerJob == 4) {
					var sh = ShortCutInfo.CreateBuilder ();
					sh.Index = 0;
					sh.IndexId = 0;
					sh.BaseId = 14;
					sh.Type = 0;
					au.AddShortCutInfo (sh);
					
					sh = ShortCutInfo.CreateBuilder ();
					sh.Index = 1;
					sh.IndexId = 0;
					sh.BaseId = 15;
					sh.Type = 0;
					au.AddShortCutInfo (sh);
					
					sh = ShortCutInfo.CreateBuilder ();
					sh.Index = 2;
					sh.IndexId = 0;
					sh.BaseId = 16;
					sh.Type = 0;
					au.AddShortCutInfo (sh);
					
					sh = ShortCutInfo.CreateBuilder ();
					sh.Index = 3;
					sh.IndexId = 0;
					sh.BaseId = 17;
					sh.Type = 0;
					au.AddShortCutInfo (sh);
				} else {
					var sh = ShortCutInfo.CreateBuilder ();
					sh.Index = 0;
					sh.IndexId = 0;
					sh.BaseId = 3;
					sh.Type = 0;
					au.AddShortCutInfo (sh);
					
					sh = ShortCutInfo.CreateBuilder ();
					sh.Index = 1;
					sh.IndexId = 0;
					sh.BaseId = 4;
					sh.Type = 0;
					au.AddShortCutInfo (sh);
					
					sh = ShortCutInfo.CreateBuilder ();
					sh.Index = 2;
					sh.IndexId = 0;
					sh.BaseId = 5;
					sh.Type = 0;
					au.AddShortCutInfo (sh);
					
					sh = ShortCutInfo.CreateBuilder ();
					sh.Index = 3;
					sh.IndexId = 0;
					sh.BaseId = 6;
					sh.Type = 0;
					au.AddShortCutInfo (sh);
				}
				retPb = au;
			} else if (className == "CGListBranchinges") {
				var au = GCListBranchinges.CreateBuilder ();
				var bran = Branching.CreateBuilder ();
				bran.Line = 1;
				bran.PlayerCount = 2;
				au.AddBranching (bran);
				retPb = au;
			} else if (className == "CGHeartBeat") {
			
			} else if (className == "CGLoadSkillPanel") {
				var au = GCLoadSkillPanel.CreateBuilder ();
				retPb = au;
			} else if (className == "CGLoadSaleItems") {
				var au = GCLoadSaleItems.CreateBuilder ();
				retPb = au;
			} else if (className == "CGListAllTeams") {
				var au = GCListAllTeams.CreateBuilder ();
				retPb = au;
			} else if (className == "CGCopyInfo") {
				var au = GCCopyInfo.CreateBuilder();
				var cin = CopyInfo.CreateBuilder();
				cin.Id = 3;
				cin.IsPass = false;
				au.AddCopyInfo(cin);
				retPb = au;
			}*/

			if (retPb != null) {
				sendPacket (retPb, flowId);
			} else {
				//Debug.LogError("DemoServer::not Handle Message "+className);
			}
		}

		void SendThread() {
			bool conOK = true;
			while (conOK) {
				lock(msgBuffer) {
					while(msgBuffer.Count > 0){
						con.connect.Send(msgBuffer[0]);
						msgBuffer.RemoveAt(0);
					}
				}
				Thread.Sleep(100);
			}
		}

	    private void ReceiveThread(object pobj)
	    {
            while (true)
            {
                Console.WriteLine("ReceiveThread");
                MyCon con = (MyCon)pobj;
                byte[] buffer = new byte[1024];
                int num = con.connect.Receive(buffer);
                Console.WriteLine("ss:" + num);
                if (num > 0)
                {
                    Console.WriteLine("receive" + buffer);
                    //buffer = new byte[1024];
                    msgReader.process(buffer, (uint)num);
                }
            }
	    }

	    public void run() {
			//Debug.Log ("Start Demo Server");
            Console.WriteLine("Start Demo Server");
			byte[] buffer = new byte[1024];
			while (true) {
                //Console.WriteLine("sendThread");
				var connect = socket.Accept();
				con = new MyCon(connect);
			    var receiveThread = new Thread(new ParameterizedThreadStart(ReceiveThread));
                receiveThread.Start(con);

			    //var sendThread = new Thread(new ThreadStart(SendThread));
			    //sendThread.Start();

			    //lock (msgBuffer) {
			    //    msgBuffer.Clear();
			    //}

			    //while (true)
			    //{
			    //    Console.WriteLine("ReadThread");
			    //    int num = connect.Receive(buffer);
			    //    if (num > 0)
			    //    {
			    //        msgReader.process(buffer, (uint)num);
			    //    }
			    //    else
			    //    {

			    //    }
			    //}
			}

		}
	}

	public class DemoServer
	{
		public DemoServer(){
			//Debug.Log ("Init DemoServer");
			var sth = new ServerThread ();
			var t = new Thread (new ThreadStart(sth.run));
			t.Start ();

		}
	}
}
