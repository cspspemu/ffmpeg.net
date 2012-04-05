using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public enum AVColorSpace
	{
	    AVCOL_SPC_RGB        =0,
	    AVCOL_SPC_BT709      =1, ///< also ITU-R BT1361 / IEC 61966-2-4 xvYCC709 / SMPTE RP177 Annex B
	    AVCOL_SPC_UNSPECIFIED=2,
	    AVCOL_SPC_FCC        =4,
	    AVCOL_SPC_BT470BG    =5, ///< also ITU-R BT601-6 625 / ITU-R BT1358 625 / ITU-R BT1700 625 PAL & SECAM / IEC 61966-2-4 xvYCC601
	    AVCOL_SPC_SMPTE170M  =6, ///< also ITU-R BT601-6 525 / ITU-R BT1358 525 / ITU-R BT1700 NTSC / functionally identical to above
	    AVCOL_SPC_SMPTE240M  =7,
	    AVCOL_SPC_YCGCO      =8,
	    AVCOL_SPC_NB           , ///< Not part of ABI
	}
}
