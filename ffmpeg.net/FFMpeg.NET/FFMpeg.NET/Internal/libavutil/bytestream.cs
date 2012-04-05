using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavutil
{
	public struct GetByteContext
	{
		public Pointer<byte> buffer, buffer_end, buffer_start;
	}

	public class bytestream2
	{
		static public void init(ref GetByteContext g, Pointer<byte> Start, int Size)
		{
			g.buffer = Start;
			g.buffer_start = Start;
			g.buffer_end = Start + Size;
		}

		static public byte get_byte(ref GetByteContext g)
		{
			try
			{
				return g.buffer[0];
			}
			finally
			{
				g.buffer++;
			}
			throw new NotImplementedException();
		}

		static public void skip(ref GetByteContext g, int size)
		{
			g.buffer += size;
		}

		static public short get_le16(ref GetByteContext g)
		{
			return (short)get_le16u(ref g);
		}

		static public int get_bytes_left(ref GetByteContext g)
		{
			return g.buffer_end - g.buffer;
		}

		static public ushort get_le16u(ref GetByteContext g)
		{
			var v0 = get_byte(ref g);
			var v1 = get_byte(ref g);

			return (ushort)((v0 << 0) | (v1 << 8));
		}

		static public uint get_le24u(ref GetByteContext g)
		{
			var v0 = get_byte(ref g);
			var v1 = get_byte(ref g);
			var v2 = get_byte(ref g);

			return (uint)((v0 << 0) | (v1 << 8) | (v2 << 16));
		}

		static public int get_bufferu(ref GetByteContext g, Pointer<byte> dst, int size)
		{

			CLib.memcpy(dst, g.buffer, size);
			g.buffer += size;
			return size;
		}
	}

	public class bytestream
	{
		static public uint get_le32(ref Pointer<byte> g)
		{
			var v0 = get_byte(ref g);
			var v1 = get_byte(ref g);
			var v2 = get_byte(ref g);
			var v3 = get_byte(ref g);

			return (uint)((v0 << 0) | (v1 << 8) | (v2 << 16) | (v3 << 24));
		}

		static public uint get_le24(ref Pointer<byte> g)
		{
			var v0 = get_byte(ref g);
			var v1 = get_byte(ref g);
			var v2 = get_byte(ref g);

			return (uint)((v0 << 0) | (v1 << 8) | (v2 << 16));
		}

		static public ushort get_le16(ref Pointer<byte> g)
		{
			var v0 = get_byte(ref g);
			var v1 = get_byte(ref g);

			return (ushort)((v0 << 0) | (v1 << 8));
		}

		static public byte get_byte(ref Pointer<byte> g)
		{
			try
			{
				return g[0];
			}
			finally
			{
				//Pointer.Offset++;
				g++;
			}
		}
	}
}
