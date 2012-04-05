using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavutil
{
	public class bytestream
	{
		static public uint get_le32(ref Pointer<byte> Pointer)
		{
			var v0 = get_byte(ref Pointer);
			var v1 = get_byte(ref Pointer);
			var v2 = get_byte(ref Pointer);
			var v3 = get_byte(ref Pointer);

			return (uint)((v0 << 0) | (v1 << 8) | (v2 << 16) | (v3 << 24));
		}

		static public uint get_le24(ref Pointer<byte> Pointer)
		{
			var v0 = get_byte(ref Pointer);
			var v1 = get_byte(ref Pointer);
			var v2 = get_byte(ref Pointer);

			return (uint)((v0 << 0) | (v1 << 8) | (v2 << 16));
		}

		static public ushort get_le16(ref Pointer<byte> Pointer)
		{
			var v0 = get_byte(ref Pointer);
			var v1 = get_byte(ref Pointer);

			return (ushort)((v0 << 0) | (v1 << 8));
		}

		static public byte get_byte(ref Pointer<byte> Pointer)
		{
			try
			{
				return Pointer[0];
			}
			finally
			{
				//Pointer.Offset++;
				Pointer++;
			}
		}
	}
}
