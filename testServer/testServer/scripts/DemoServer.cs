////using UnityEngine;

using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

using com.Cotg.net.msg;
using Cotg.Proto.Const;
using IO;
using Net;
using ProtoBuf;
//using SimpleJSON;

namespace ChuMeng
{
	public class MyCon {
		public Socket connect;
		public bool isClose = false;
	    public int num = 1;
		public MyCon(Socket s) {
			connect = s;
		}

	    public void setNum(int pnum)
	    {
	        num = pnum;
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

		List<byte[]> msgBuffer = new List<byte[]>();
        List<MyCon> UserList = new List<MyCon>();

        private MemoryStream _readBuffer;
        private int _readOffset;//读的偏移
        private int _writeOffset;//写的偏移
        private bool _encrypted;//是否加密

        private byte[] KEY = new byte[] { 0xae, 0xbf, 0x56, 0x78, 0xab, 0xcd, 0xef, 0xf1 }; //加密的KEY

        public static MemoryStream RECEIVE_KEY;//收到的KEY 流
        public static MemoryStream SEND_KEY;//发送给后端的KEY

        private MemoryStream _headerTemp;
        private EndianBinaryReader _headerTempReader;

		public ServerThread() {

			socket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


			socket.SetSocketOption (System.Net.Sockets.SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
			IPEndPoint ip = new IPEndPoint (IPAddress.Parse("127.0.0.1"), 20000);

			socket.Bind (ip);
			socket.Listen (1);

		    _readOffset = 0;
		    _writeOffset = 0;
		    _encrypted = false;

            _readBuffer = new MemoryStream();
            _headerTemp = new MemoryStream();
            _headerTempReader = new EndianBinaryReader(EndianBitConverter.Big, _headerTemp);


            SetKey(KEY);
		}


        /// <summary>
        /// 设置加密Key
        /// </summary>
        public void SetKey(byte[] key)
        {
            RECEIVE_KEY = new MemoryStream();
            SEND_KEY = new MemoryStream();
            for (int i = 0; i < 8; i++)
            {
                RECEIVE_KEY.WriteByte(key[i]);
                SEND_KEY.WriteByte(key[i]);
            }
        }

        //void sendPacket(IBuilderLite retpb, uint flowId) {
        //    var bytes = ServerBundle.sendImmediate(retpb, flowId);
        //    //Debug.Log ("DemoServer: Send Packet "+flowId);
        //    lock (msgBuffer) {
        //        msgBuffer.Add(bytes);
        //    }
        //}
        //void handleMsg(KBEngine.Packet packet) {
        //    var receivePkg = packet.protoBody.GetType ().FullName;
        //    //Debug.Log ("Server Receive "+receivePkg);
        //    var className = receivePkg.Split(char.Parse("."))[1];
        //    IBuilderLite retPb = null;
        //    uint flowId = packet.flowId;
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

        //    if (retPb != null) {
        //        sendPacket (retPb, flowId);
        //    } else {
        //        //Debug.LogError("DemoServer::not Handle Message "+className);
        //    }
        //}

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
                

                MyCon con = (MyCon)pobj;

                Console.WriteLine("ReceiveThread:" + con.num);
            
                if (!con.connect.Connected)
                {
                    break;
                }

                try
                {
                    int num = con.connect.Available;

                    if (num > 0)
                    {
                        byte[] buffer = new byte[num];
                        con.connect.Receive(buffer);
                        Console.WriteLine("ss:" + num);
                        string str = String.Empty;

                        foreach (byte b in buffer)
                        {
                            str += b.ToString() + ":";
                        }
                        Console.WriteLine(str);

                        
                        if (num > 0)
                        {
                            //把数据写入流中
                            //处理包数据
                            _readBuffer.Write(buffer, 0, num);
                            _writeOffset += num;
                            
                            if (_writeOffset > 1)
                            {
                                _readOffset = 0;
                                if (num >= PackageIn.HEADER_SIZE)
                                {
                                    //解包
                                    ReadPackage();
                                }
                            }
                        }
                    }

                }
                catch(Exception e)
                {                    
                   Console.WriteLine("receive error" + e.Message);
                   break;
                }
                Thread.Sleep(100);
            }
	    }

        #region 解包
        /// <summary>
        /// 读包
        /// </summary>
        private void ReadPackage()
        {
            int dataLeft = _writeOffset - _readOffset;
            byte[] readByte = _readBuffer.ToArray();
            do
            {
                int len = 0;
                //解析包长
                while (_readOffset + 4 < _writeOffset)
                {
                    //解析包头
                    _headerTemp.Position = 0;
                    _headerTemp.WriteByte(readByte[_readOffset]);
                    _headerTemp.WriteByte(readByte[_readOffset + 1]);
                    _headerTemp.WriteByte(readByte[_readOffset + 2]);
                    _headerTemp.WriteByte(readByte[_readOffset + 3]);
                    if (_encrypted)
                    {
                        _headerTemp = DecrptBytes(_headerTemp, 4, CopyByteArray(RECEIVE_KEY));
                    }
                    _headerTemp.Position = 0;
                    if (_headerTempReader.ReadInt16() == PackageOut.HEADER)
                    {
                        //拿到包长
                        len = _headerTempReader.ReadUInt16();
                        break;
                    }
                    else
                    {
                        _readOffset++;
                    }
                }

                dataLeft = _writeOffset - _readOffset;
                if (dataLeft >= len && len != 0)
                {
                    _readBuffer.Position = _readOffset;
                    PackageIn buff = new PackageIn();
                    if (_encrypted)
                    {
                        buff.loadE(readByte, len, RECEIVE_KEY.ToArray());
                    }
                    else
                    {
                        buff.load(readByte, len);
                    }
                    _readOffset += len;
                    dataLeft = _writeOffset - _readOffset;
                    HandlePackage(buff);
                }
                else
                {
                    break;
                }
            }
            while (dataLeft >= PackageIn.HEADER_SIZE);

            _readBuffer.Position = 0;
            if (dataLeft > 0)
            {
                _readBuffer.Write(_readBuffer.ToArray(), _readOffset, dataLeft);
            }
            _readOffset = 0;
            _writeOffset = dataLeft;
        }

        /// <summary>
        /// 复制数据流
        /// </summary>
        private MemoryStream CopyByteArray(MemoryStream src)
        {
            MemoryStream result = new MemoryStream();
            byte[] bytes = src.ToArray();
            for (int i = 0; i < src.Length; i++)
            {
                result.WriteByte(bytes[i]);
            }
            return result;
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="srcstream"></param>
        /// <param name="len"></param>
        /// <param name="keystream"></param>
        /// <returns></returns>
        public MemoryStream DecrptBytes(MemoryStream srcstream, int len, MemoryStream keystream)
        {
            int i = 0;
            byte[] src = srcstream.ToArray();
            byte[] key = keystream.ToArray();
            for (i = 0; i < len; i++)
            {
                if (i > 0)
                {
                    key[i % 8] = (byte)((key[i % 8] + src[i - 1]) ^ i);
                    srcstream.Position = i;
                    srcstream.WriteByte((byte)((src[i] - src[i - 1]) ^ key[i % 8]));
                }
                else
                {
                    srcstream.Position = 0;
                    srcstream.WriteByte((byte)(src[0] ^ key[0]));
                }
            }
            return srcstream;
        }

        /// <summary>
        /// 处理接受到的包
        /// </summary>
        /// <param name="pkg"></param>
        private void HandlePackage(PackageIn pkg)
        {


            //PackageIn pkg = obj[0] as PackageIn;
            string codeString = pkg.Code.ToString();

            TestMsg msg = pkg.ReadBody<TestMsg>();

            //0x2130 + "";
            //switch (codeString)
            //{
            //    case "":

            //        break;
            //}

            try
            {
                if (pkg.Checksum == pkg.calculateCheckSum())
                {
                    pkg.Position = PackageIn.HEADER_SIZE;
                    //m_PackageQueue.Enqueue(pkg);
                }
            }
            catch (Exception e)
            {
                //Debug.LogError("handlePackage" + e.Message);
            }
        }
        #endregion




	    public void run() {
            Console.WriteLine("Start Demo Server");

			while (true) {

			    Socket newSocket = null;
			    try
			    {
			        newSocket = socket.Accept();
			    }
			    catch
			    {
			        
			        break;
			    }

                //为连接的客户建立接收线程
                ParameterizedThreadStart pts = new ParameterizedThreadStart(ReceiveThread);
                Thread threadReceive = new Thread(pts);
                MyCon newCon = new MyCon(newSocket);
                threadReceive.Start(newCon);
                newCon.setNum(UserList.Count+1);

                UserList.Add(newCon);

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
