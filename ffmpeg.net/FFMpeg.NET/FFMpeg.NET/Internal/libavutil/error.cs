using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavutil
{
	public class error
	{
		public const int EINVAL = -2;

		static public int AVERROR(int Error)
		{
			return Error;
		}
	}
}
