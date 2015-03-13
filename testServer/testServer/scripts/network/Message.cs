
/*
Author: liyonghelpme
Email: 233242872@qq.com
*/

/*
Author: liyonghelpme
Email: 233242872@qq.com
*/
using Google.ProtocolBuffers;

namespace KBEngine
{
  	//using UnityEngine; 
	using System; 
	using System.Collections; 
	using System.Collections.Generic;
	
	using MessageID = System.UInt16;
	using ChuMeng;
	
    public class Message 
    {
    	public MessageID id = 0;
		public string name;
		public Int16 msglen = -1;
		public System.Reflection.MethodInfo handler = null;
		public System.Reflection.MethodInfo[] argtypes = null;
		public sbyte argsType = 0;

		//public MessageHandler msgHandler = null;
			
		public static Dictionary<MessageID, Message> loginappMessages = new Dictionary<MessageID, Message>();
		public static Dictionary<MessageID, Message> baseappMessages = new Dictionary<MessageID, Message>();
		public static Dictionary<MessageID, Message> clientMessages = new Dictionary<MessageID, Message>();
		
		public static Dictionary<string, Message> messages = new Dictionary<string, Message>();

		public static void reset()
		{
			loginappMessages.Clear();
			baseappMessages.Clear();
			clientMessages.Clear();
			messages.Clear();
		}

		//Message name
		public Message(MessageHandler mh) {
			id = 0;
			name = null;
			msglen = 0;
			handler = null;
			//msgHandler = mh;
			argsType = 0;
			argtypes = null;
		}

		public Message() {
			id = 0;
			name = null;
			msglen = 0;
			handler = null;
			//msgHandler = null;
			argsType = 0;
			argtypes = null;
		}

		public Message(MessageID msgid, string msgname, Int16 length, sbyte argstype, List<Byte> msgargtypes, System.Reflection.MethodInfo msghandler)
		{
			id = msgid;
			name = msgname;
			msglen = length;
			handler = msghandler;
			argsType = argstype;
			
			argtypes = new System.Reflection.MethodInfo[msgargtypes.Count];
			for(int i=0; i<msgargtypes.Count; i++)
			{
				argtypes[i] = StreamRWBinder.bindReader(msgargtypes[i]);
				if(argtypes[i] == null)
				{
					Dbg.ERROR_MSG("Message::Message(): bindReader(" + msgargtypes[i] + ") is error!");
				}
			}
			
			// Dbg.DEBUG_MSG(string.Format("Message::Message(): ({0}/{1}/{2})!", 
			//	msgname, msgid, msglen));
		}
		
		public object[] createFromStream(MemoryStream msgstream)
		{
			if(argtypes.Length <= 0)
				return new object[]{msgstream};
			
			object[] result = new object[argtypes.Length];
			
			for(int i=0; i<argtypes.Length; i++)
			{
				result[i] = argtypes[i].Invoke(msgstream, new object[0]);
			}
			
			return result;
		}
		
		public void handleMessage(MemoryStream msgstream)
		{
			if(argtypes.Length <= 0)
			{
				if(argsType < 0)
					handler.Invoke(KBEngineApp.app, new object[]{msgstream});
				else
					handler.Invoke(KBEngineApp.app, new object[]{});
			}
			else
			{
				handler.Invoke(KBEngineApp.app, createFromStream(msgstream));
			}
		}

		public IMessageLite handlePB(byte moduleId, System.UInt16 msgId, MemoryStream msgstream) {
			var buf = msgstream.getbuffer ();
			IMessageLite msg =  Util.GetMsg (moduleId, msgId, msgstream.getBytString());
			return msg;
		}
    }
} 
