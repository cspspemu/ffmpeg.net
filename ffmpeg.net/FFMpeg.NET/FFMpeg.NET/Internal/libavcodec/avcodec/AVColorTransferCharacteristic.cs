using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public enum AVColorTransferCharacteristic
	{
	    AVCOL_TRC_BT709      =1, ///< also ITU-R BT1361
	    AVCOL_TRC_UNSPECIFIED=2,
	    AVCOL_TRC_GAMMA22    =4, ///< also ITU-R BT470M / ITU-R BT1700 625 PAL & SECAM
	    AVCOL_TRC_GAMMA28    =5, ///< also ITU-R BT470BG
	    AVCOL_TRC_SMPTE240M  =7,
	    AVCOL_TRC_NB           , ///< Not part of ABI
	}
}
