using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavutil
{
	public class common
	{
		//#define MKTAG(a,b,c,d) ((a) | ((b) << 8) | ((c) << 16) | ((unsigned)(d) << 24))
		//#define MKBETAG(a,b,c,d) ((d) | ((c) << 8) | ((b) << 16) | ((unsigned)(a) << 24))

		static public uint MKBETAG(char a, char b, char c, char d)
		{
			return (uint)((d) | ((c) << 8) | ((b) << 16) | ((a) << 24));
		}
	}
}
