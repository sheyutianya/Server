////using UnityEngine;
using System.Collections;
using Google.ProtocolBuffers;
using System.Collections.Generic;
using System;

namespace ChuMeng
{
	public class ServerBundle 
	{
		KBEngine.MemoryStream stream = new KBEngine.MemoryStream();
		public int messageLength = 0;
		public KBEngine.Message msgtype = null;
		public int moduleId;
		public int msgId;
		public System.UInt32 flowId;

		void newMessage(System.Type type) {
			//Debug.Log ("ServerBundle:: 开始发送消息 Message is " + type.Name);
			//var pa = Util.GetMsgID (type.Name);
			//moduleId = pa.moduleId;
			//msgId = pa.messageId;
			
			msgtype = null;
		}

		public uint writePB(byte[] v) {

			int bodyLength = 4 + 1 + 2+ 4 + 2 + v.Length;
			int totalLength = 1 + 4 + bodyLength;
			//checkStream (totalLength);
			//Debug.Log ("ServerBundle::writePB pack data is "+bodyLength+" pb length "+v.Length+" totalLength "+totalLength);
			//Debug.Log ("ServerBundle::writePB module Id msgId " + moduleId+" "+msgId);
			stream.writeUint8 (Convert.ToByte(0xcc));
			stream.writeUint32 (Convert.ToUInt32(bodyLength));
			stream.writeUint32 (Convert.ToUInt32(flowId));
			stream.writeUint8 (Convert.ToByte(moduleId));
			stream.writeUint16 (Convert.ToUInt16(msgId));
			stream.writeUint32 (Convert.ToUInt32 (123));//response time
			stream.writeUint16 (Convert.ToUInt16 (0)); // no error reponse flag
			stream.writePB (v);
			
			return flowId;
		}

		uint writePB(IMessageLite pbMsg) {
			byte[] bytes;
			using (System.IO.MemoryStream stream = new System.IO.MemoryStream()) {
				pbMsg.WriteTo (stream);
				bytes = stream.ToArray ();
			}
			return writePB (bytes);
		}
		public static byte[] sendImmediate(IBuilderLite build, uint flowId) {
			var data = build.WeakBuild ();

			var bundle = new ServerBundle ();
			bundle.newMessage (data.GetType());
			bundle.flowId = flowId;
			bundle.writePB (data);

			return bundle.stream.getbuffer();
		}
	}

}