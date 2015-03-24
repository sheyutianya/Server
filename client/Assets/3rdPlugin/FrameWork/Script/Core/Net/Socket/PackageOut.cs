using System.IO;
using IO;

namespace Net
{
   public class PackageOut:MemoryStream
    {
        public const short HEADER = 0x71ab;
        private short _checksum;
		public static int clientId;
		private int _code;
        private EndianBinaryWriter _writer;

        public int Code
        {
          get { return _code; }
          set { _code = value; }
        }
		
		public PackageOut(int code):this(code,0,0,0){}
        public PackageOut(int code,int toId):this(code,toId,0,0){}
        public PackageOut(int code,int toId,int extend1):this(code,toId,extend1,0){}

		public PackageOut(int code,int toId,int extend1,int extend2)
		{
            _writer = new EndianBinaryWriter(EndianBitConverter.Big, this);
            _writer.Write(HEADER); //2
            _writer.Write((short)0x00); //2
            _writer.Write((short)0x00);//2
            _writer.Write((short)code);	//协议号 2

            //if (toId == 0) toId = clientId;
            //_writer.Write(toId); //4
            //_writer.Write(extend1); //4
            //_writer.Write(extend2);//4

			_code = code;
			_checksum = 0;
        }
		
		public void pack()
		{
			_checksum = calculateCheckSum();
            EndianBinaryWriter temp = new EndianBinaryWriter(EndianBitConverter.Big,new MemoryStream());
            temp.Write((short)Length);
            temp.Write(_checksum);
            byte[] bytes = (temp.BaseStream as MemoryStream).ToArray();
            Position = 2;
            WriteByte(bytes[0]) ;
            WriteByte(bytes[1]) ;
            WriteByte(bytes[2]) ;
            WriteByte(bytes[3]) ;
            Position = Length - 1;            
        }

        public short calculateCheckSum()
		{
			int val1 = 0x77;
			int i = 6;
            byte[] bts = ToArray();
			while (i < Length)
			{
				val1 += bts[i++];
			}
			
			return (short)((val1) & 0x7F7F);
		}
    }

   
}
