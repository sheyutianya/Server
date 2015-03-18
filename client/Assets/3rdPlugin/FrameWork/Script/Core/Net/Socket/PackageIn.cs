using System;
using System.IO;
using IO;
using ProtoBuf;

namespace Net
{
    public class PackageIn:MemoryStream
    {
        public  const long HEADER_SIZE = 8;

        private int _len;

        private EndianBinaryReader _reader;
        private EndianBinaryWriter _writer;
        public int Len
        {
            get { return _len; }
            set { _len = value; }
        }

        private int _checksum;

        public int Checksum
        {
            get { return _checksum; }
            set { _checksum = value; }
        }

        private int _clientId;

        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

        private int _code;

        public int Code
        {
            get { return _code; }
            set { _code = value; }
        }

       
        public PackageIn()
        {
            _writer = new EndianBinaryWriter(EndianBitConverter.Big, this);

            _reader = new EndianBinaryReader(EndianBitConverter.Big,this);
        }

        public void load( byte[] src,int len)
		{
			for(int i = 0; i < len; i ++)
            {
                _writer.Write(src[i]);
            }	
			Position = 0;
			ReadHeader();
		}
		
		public void loadE( byte[] src,int len, byte[] key)
		{
			int i=0;

			for(i=0;i<len;i++)
			{
				if(i>0)
				{
                    key[i % 8] = (byte)((key[i % 8] + src[i - 1]) ^ i);
                    _writer.Write((byte)((src[i] - src[i - 1]) ^ key[i % 8]));
				}else
				{
                   _writer.Write((byte)(src[i] ^ key[0]));
				}
			}
			Position = 0;
			ReadHeader();
		}

        /// <summary>
        /// 读取包头
        /// </summary>
		public void ReadHeader()
		{
            _reader.ReadInt16();
            _len = _reader.ReadInt16();
            _checksum = _reader.ReadInt16();
            _code = _reader.ReadInt16();
		}

        /// <summary>
        /// 读取包体
        /// </summary>
        public T ReadBody<T>() where T : IExtensible
        {
            byte[] src = ToArray();
            long length = src.Length - HEADER_SIZE;
            byte[] result = new byte[length];
            Array.Copy(src, HEADER_SIZE, result, 0, length);
            return ProbufSerialize.PBDeserialize<T>(result);
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
