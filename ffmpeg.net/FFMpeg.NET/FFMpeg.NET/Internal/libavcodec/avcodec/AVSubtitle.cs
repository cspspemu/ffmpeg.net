using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public struct AVSubtitle
	{
		public ushort format; /* 0 = graphics */
		public uint start_display_time; /* relative to packet pts, in ms */
		public uint end_display_time; /* relative to packet pts, in ms */
		public uint num_rects;
		//public AVSubtitleRect** rects;
		public Unimplemented rects;
	    public long pts;    ///< Same as packet pts, in AV_TIME_BASE
	}
}
