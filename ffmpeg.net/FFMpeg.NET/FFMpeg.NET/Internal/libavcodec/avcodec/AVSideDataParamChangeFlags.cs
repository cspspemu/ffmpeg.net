using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public enum AVSideDataParamChangeFlags
	{
	    AV_SIDE_DATA_PARAM_CHANGE_CHANNEL_COUNT  = 0x0001,
	    AV_SIDE_DATA_PARAM_CHANGE_CHANNEL_LAYOUT = 0x0002,
	    AV_SIDE_DATA_PARAM_CHANGE_SAMPLE_RATE    = 0x0004,
	    AV_SIDE_DATA_PARAM_CHANGE_DIMENSIONS     = 0x0008,
	}
}
