using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public struct RcOverride
	{
	    public int start_frame;
	    public int end_frame;
	    public int qscale; // If this is 0 then quality_factor will be used instead.
	    public float quality_factor;
	}
}
