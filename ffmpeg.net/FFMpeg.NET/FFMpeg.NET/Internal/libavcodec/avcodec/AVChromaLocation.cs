using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	/**
	 *  X   X      3 4 X      X are luma samples,
	 *             1 2        1-6 are possible chroma positions
	 *  X   X      5 6 X      0 is undefined/unknown position
	 */
	public enum AVChromaLocation
	{
	    AVCHROMA_LOC_UNSPECIFIED=0,
	    AVCHROMA_LOC_LEFT       =1, ///< mpeg2/4, h264 default
	    AVCHROMA_LOC_CENTER     =2, ///< mpeg1, jpeg, h263
	    AVCHROMA_LOC_TOPLEFT    =3, ///< DV
	    AVCHROMA_LOC_TOP        =4,
	    AVCHROMA_LOC_BOTTOMLEFT =5,
	    AVCHROMA_LOC_BOTTOM     =6,
	    AVCHROMA_LOC_NB           , ///< Not part of ABI
	}
}
