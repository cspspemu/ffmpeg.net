using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public enum AVAudioServiceType
	{
	    AV_AUDIO_SERVICE_TYPE_MAIN              = 0,
	    AV_AUDIO_SERVICE_TYPE_EFFECTS           = 1,
	    AV_AUDIO_SERVICE_TYPE_VISUALLY_IMPAIRED = 2,
	    AV_AUDIO_SERVICE_TYPE_HEARING_IMPAIRED  = 3,
	    AV_AUDIO_SERVICE_TYPE_DIALOGUE          = 4,
	    AV_AUDIO_SERVICE_TYPE_COMMENTARY        = 5,
	    AV_AUDIO_SERVICE_TYPE_EMERGENCY         = 6,
	    AV_AUDIO_SERVICE_TYPE_VOICE_OVER        = 7,
	    AV_AUDIO_SERVICE_TYPE_KARAOKE           = 8,
	    AV_AUDIO_SERVICE_TYPE_NB                   , ///< Not part of ABI
	}
}
