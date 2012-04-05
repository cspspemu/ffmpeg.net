using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavutil
{
	/// <summary>
	/// le = little endian
	/// ne = native endian
	/// be = big endian
	/// </summary>
	public class av_bswap
	{
#if !BIG_ENDIAN
		static public ushort av_le2ne16(ushort Value) { return Value; }
#else
	#error "BIG ENDIAN NOT SUPPORTED"
#endif
	}
}
