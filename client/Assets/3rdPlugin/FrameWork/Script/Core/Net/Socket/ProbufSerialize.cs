using System.IO;
using ProtoBuf;

namespace Net
{
    /// <summary>
    /// probuf 序列化与反序列化
    /// </summary>
   public class ProbufSerialize
    {
        /// <summary>
        /// probuf 序列化
        /// </summary>
        public static byte[] PBSerialize(IExtensible msg)
        {
            byte[] result;
            using (var stream = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(stream, msg);
                result = stream.ToArray();
            }
            return result ;
        }

        /// <summary>
        /// probuf反序列化
        /// </summary>
        public static T PBDeserialize<T>(byte[] message) where T : IExtensible
       {
           T result;
           using (var stream = new MemoryStream(message))
           {
               result = ProtoBuf.Serializer.Deserialize<T>(stream);
           }
           return result;
       }

    }
}
