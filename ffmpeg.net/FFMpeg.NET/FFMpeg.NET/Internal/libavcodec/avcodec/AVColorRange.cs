using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public enum AVColorRange
	{
	    AVCOL_RANGE_UNSPECIFIED=0,
	    AVCOL_RANGE_MPEG       =1, ///< the normal 219*2^(n-8) "MPEG" YUV ranges
	    AVCOL_RANGE_JPEG       =2, ///< the normal     2^n-1   "JPEG" YUV ranges
	    AVCOL_RANGE_NB           , ///< Not part of ABI
	}
}
