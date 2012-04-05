using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public struct RcOverride
	{
	    int start_frame;
	    int end_frame;
	    int qscale; // If this is 0 then quality_factor will be used instead.
	    float quality_factor;
	}
}
