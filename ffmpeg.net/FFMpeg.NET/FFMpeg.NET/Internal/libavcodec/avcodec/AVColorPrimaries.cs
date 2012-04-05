using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public enum AVColorPrimaries
	{
	    AVCOL_PRI_BT709      =1, ///< also ITU-R BT1361 / IEC 61966-2-4 / SMPTE RP177 Annex B
	    AVCOL_PRI_UNSPECIFIED=2,
	    AVCOL_PRI_BT470M     =4,
	    AVCOL_PRI_BT470BG    =5, ///< also ITU-R BT601-6 625 / ITU-R BT1358 625 / ITU-R BT1700 625 PAL & SECAM
	    AVCOL_PRI_SMPTE170M  =6, ///< also ITU-R BT601-6 525 / ITU-R BT1358 525 / ITU-R BT1700 NTSC
	    AVCOL_PRI_SMPTE240M  =7, ///< functionally identical to above
	    AVCOL_PRI_FILM       =8,
	    AVCOL_PRI_NB           , ///< Not part of ABI
	}
}
