using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public enum AVPacketSideDataType
	{
	    AV_PKT_DATA_PALETTE,
	    AV_PKT_DATA_NEW_EXTRADATA,
	    AV_PKT_DATA_PARAM_CHANGE,
	    AV_PKT_DATA_H263_MB_INFO,
	}
}
