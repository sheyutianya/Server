using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO ;
using System.Net;
using Core.Managers;
using ProtoBuf;
using System.Threading;
using IO;
using UnityEngine;

namespace Net
{
    public class ByteSocket 
    {

        private bool _debug; //是否是Debug 模式
		
		private Socket _socket; //Socket的引用
		
		private string _ip;//IP
		
		private int _port;//端口
		
		private bool _encrypted;//是否加密
		
		private byte[] KEY = new byte[]{0xae, 0xbf, 0x56, 0x78, 0xab, 0xcd, 0xef, 0xf1}; //加密的KEY

		public static MemoryStream RECEIVE_KEY;//收到的KEY 流
		public static MemoryStream SEND_KEY;//发送给后端的KEY
		
        private MemoryStream _readBuffer;
		private int _readOffset;//读的偏移
		private int _writeOffset;//写的偏移

		private MemoryStream _headerTemp;
        private EndianBinaryReader _headerTempReader;

        private Thread thread; // 连接的线程

        #region 构造函数
        public ByteSocket():this(true,false){}
        public ByteSocket(bool encrypted):this(encrypted,false){}
		public ByteSocket(bool encrypted,bool debug) 
		{
            EnterFrameManager.GetInstance().Register(EnterFrame);
			_readBuffer = new MemoryStream();
			_headerTemp = new MemoryStream();
            _headerTempReader = new EndianBinaryReader(EndianBitConverter.Big, _headerTemp);
			_encrypted = encrypted;
			_debug = debug;
			SetKey(KEY); //设置第一次请求的默认KEY  再次请求的KEY 有服务器发过来再替换
		}
        #endregion

        #region 设置加密的KEY
        /// <summary>
        /// 设置加密Key
        /// </summary>
        public void SetKey(byte[] key)
		{
			RECEIVE_KEY = new MemoryStream();
			SEND_KEY = new MemoryStream();
			for(int i=0;i<8;i++)
			{
				RECEIVE_KEY.WriteByte(key[i]);
				SEND_KEY.WriteByte(key[i]);             
			}         
		}

        /// <summary>
        /// 重置加密key
        /// </summary>
		public void ResetKey()
		{
			SetKey(KEY);
		}
        #endregion


        #region 连接服务器
        /// <summary>
        /// 连接服务器  
        /// </summary>
        /// <param name="ip">服务器的IP</param>
        /// <param name="port">服务器的端口</param>
        public void Connect(string ip,int port)
		{
			try
			{
                //已经连接上了 再次请求连接  先关闭上次连接
				if(_socket != null)
				{
					Close(false);
				}
				//TCP 连接
				_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp) ;
				_ip = ip;
				_port = port;
                _readBuffer.Position = 0 ;
				_readOffset = 0;
				_writeOffset = 0;
                 //服务器IP地址
                 IPAddress ipAddress = IPAddress.Parse(_ip);
                 //服务器端口
                 IPEndPoint ipEndpoint =  new IPEndPoint(ipAddress,_port);
                 //异步建立连接
                 _socket.BeginConnect(ipEndpoint, new AsyncCallback(ConnectCallback),_socket);
                
			}
			catch(Exception e)
			{
                SocketManager.ins.RaiseEvent(SocketEvents.SOCKET_ERROR, e.Message);
            }
		}

      
        /// <summary>
        /// 接受到数据
        /// </summary>
        private void ReveiveSorket()
        {
           while(true)
           {
               if (!_socket.Connected)
               { 
                   //与服务器断开连接
                   Close(true);
                   break;
               }
               try
               {
                   //Receive方法一直等待服务器消息
                int len= _socket.Available ;
               if ( len> 0)
               {
                   byte[] receivebuff = new byte[len];
                   _socket.Receive(receivebuff);
                   //接受的时候保存在流中
                   _readBuffer.Write(receivebuff, 0, len);              
                   //如果有数据的话
                   if (len > 0)
                   {
                       _writeOffset += len;
                       if (_writeOffset > 1)
                       {
                           _readOffset = 0;
                           if (len >= PackageIn.HEADER_SIZE)
                           {
                               //解包
                               ReadPackage();
                           }
                       }

                  }
               }
               }
               catch (Exception e)
               {
					Debug.LogError("ReveiveSorket"+e.Message);
               }
           }
        }    

        /// <summary>
        /// 连接成功
        /// </summary>
        /// <param name="asyncConnect"></param>
        private void ConnectCallback(IAsyncResult asyncConnect)
        {
            Socket client = (Socket)asyncConnect.AsyncState;
            try
            {
                client.EndConnect(asyncConnect); // 结束挂起的异步连接请求   运行到这里说明连接成功 
                HandleConnect(); //连接成功的通知
                //开启接受数据的线程
                if (thread == null)
                {
                    thread = new Thread(new ThreadStart(ReveiveSorket));
                    thread.IsBackground = true;
                    thread.Start();
                } 
            }
            catch (Exception e)
            {
                Debug.LogError("connectcallback " + e.Message);
            }
          
        }

        /// <summary>
        /// 连接成功  通知
        /// </summary>
        private void HandleConnect()
        {
            SocketManager.ins.RaiseEvent(SocketEvents.SOCKET_CONNECT);
        }
        #endregion


        #region  条件判定
        /// <summary>
        /// 是否连接上了
        /// </summary>
        /// <returns></returns>
		public bool GetConnected()
		{
            return _socket != null && _socket.Connected  ;  
		}
		
        /// <summary>
        /// 是否是同一个地址
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="port"></param>
        /// <returns></returns>
		public bool IsSame(string ip ,int port) 
		{
			return _ip == ip && port == _port;
		}
        #endregion


        #region 发送数据
        /// <summary>
        /// 直接发送字符串
        /// </summary>
        /// <param name="value"></param>

        public void SendByteArrayString(string value)
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(value);

            if (GetConnected())
            {
                _socket.Send(bytes);
            }
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="pkg"></param>
		public void Send(PackageOut pkg) 
		{
			if(GetConnected())
			{
				pkg.pack();
				if(_debug)
				{
				}
				byte[] source = pkg.ToArray();
                //加密过程
                if(_encrypted)
				{
                    byte[] sendKey = SEND_KEY.ToArray();
					for(int i = 0;i<source.Length;i++)
					{
						if(i>0)
						{
                            sendKey[i % 8] = (byte)((sendKey[i % 8] + source[i - 1]) ^ i);
                            source[i] = (byte)((source[i] ^ sendKey[i % 8]) + source[i - 1]);
						}else
						{
							source[0] = (byte)(source[0] ^ sendKey[0]);
                           
						}
					}
                    _socket.Send(source);
				}
				else
				{
                     _socket.Send(source);
				}
                pkg.Flush();
			}
		}
		
        /// <summary>
        /// 发送probuf 包
        /// </summary>
        /// <param name="pkg"></param>
        /// <param name="msg"></param>
		public void SendProtobuffer(PackageOut pkg,IExtensible msg)
		{
			if(msg != null)
			{
               byte[] bts = ProbufSerialize.PBSerialize(msg) ;
               TraceBytes(bts);
               pkg.Write(bts,0,bts.Length);
			}
			Send(pkg);
            pkg.Flush();
		}

        /// <summary>
        /// 打印字节数据
        /// </summary>
        private void TraceBytes(byte[] bytes)
        {
            String str = String.Empty;
            foreach (byte b in bytes)
            {
                str += b.ToString()+":";
            }
            Debug.Log("sendBytes:" + str);
        }
        #endregion

        #region  关闭socket
        /// <summary>
        /// 关闭Socket 
        /// </summary>
        /// <param name="isEvt">是否发送事件</param>
		public void Close(bool isEvt)  
		{
			if(_socket.Connected)
			{
				try{
					_socket.Close();
				}catch(Exception e)
                {
                    Debug.LogError("close" + e.Message);
				}
			}
			if(isEvt)
            {
                SocketManager.ins.RaiseEvent(SocketEvents.SOCKET_CLOSE);
            }
		}
        #endregion

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
				while(_readOffset + 4 < _writeOffset)
				{
                    //解析包头
					_headerTemp.Position = 0;
                    _headerTemp.WriteByte(readByte[_readOffset]);
                    _headerTemp.WriteByte(readByte[_readOffset+1]);
                    _headerTemp.WriteByte(readByte[_readOffset + 2]);
                    _headerTemp.WriteByte(readByte[_readOffset + 3]);	
					if(_encrypted)
					{
						_headerTemp = DecrptBytes(_headerTemp,4,CopyByteArray(RECEIVE_KEY));
					}
					_headerTemp.Position = 0;
                    if (_headerTempReader.ReadInt16() == PackageOut.HEADER)
                    {
                        //拿到包长
                       len = _headerTempReader.ReadUInt16();
                       break ;
                    }
					else
					{
						_readOffset ++;
					}
				}
				
				dataLeft = _writeOffset - _readOffset;
				if(dataLeft >= len && len != 0)
				{
					_readBuffer.Position = _readOffset;
					PackageIn buff= new PackageIn();
					if(_encrypted)
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
			while(dataLeft >= PackageIn.HEADER_SIZE);	
			
			_readBuffer.Position = 0;
			if(dataLeft > 0)
			{
				_readBuffer.Write(_readBuffer.ToArray(),_readOffset,dataLeft);
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
            byte[] bytes = src.ToArray() ;
			for(int i=0;i<src.Length;i++)
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
		public MemoryStream DecrptBytes(MemoryStream srcstream,int len,MemoryStream keystream)
		{
			int i=0;
            byte[] src =  srcstream.ToArray();
            byte[] key =  keystream.ToArray();		
            for(i=0;i<len;i++)
			{
				if(i>0)
				{
					key[i % 8] = (byte)((key[i % 8] + src[i-1]) ^ i);
                    srcstream.Position = i;
                    srcstream.WriteByte((byte)((src[i] - src[i - 1]) ^ key[i % 8]));
				}else
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
			if(_debug)
			{
                //DEBUG 模式
			}
			try
			{
                if (pkg.Checksum == pkg.calculateCheckSum())
				{
					pkg.Position = PackageIn.HEADER_SIZE;
				    m_PackageQueue.Enqueue(pkg);
                }				
			}
			catch(Exception e)
			{				
                Debug.LogError("handlePackage" + e.Message);
			}
		}
        #endregion


        #region 销毁
        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            if (_socket.Connected)
            {
                try
                {
                    _socket.Close();
                }
                catch (Exception e)
                {
                    Debug.LogError("Dispose" + e.Message);
                }
            }
            _socket = null;
        }
        #endregion

        #region 执行队列
        /// <summary>
        /// 主线程中执行队列
        /// </summary>
        private Queue<PackageIn> m_PackageQueue = new Queue<PackageIn>();
        #endregion

        /// <summary>
        /// 主线程每帧执行
        /// </summary>
        private void EnterFrame()
        {
            if (m_PackageQueue.Count > 0)
            {
                SocketManager.ins.RaiseEvent(SocketEvents.SOCKET_DATA, m_PackageQueue.Dequeue());
            }
        }
    }
}

