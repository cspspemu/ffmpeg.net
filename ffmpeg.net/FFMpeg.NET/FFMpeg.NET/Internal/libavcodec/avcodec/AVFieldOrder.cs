using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public enum AVFieldOrder
	{
	    AV_FIELD_UNKNOWN,
	    AV_FIELD_PROGRESSIVE,
	    AV_FIELD_TT,          //< Top coded_first, top displayed first
	    AV_FIELD_BB,          //< Bottom coded first, bottom displayed first
	    AV_FIELD_TB,          //< Top coded first, bottom displayed first
	    AV_FIELD_BT,          //< Bottom coded first, top displayed first
	}
}
