using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFMpeg.NET.Internal.libavcodec.avcodec;
using FFMpeg.NET.Internal.libavutil.avutil;

namespace FFMpeg.NET.Internal.libavcodec.mpegaudiodec
{
	public class ff_mp3_decoder : AVCodec
	{
		public override string name { get { return "mp3"; } }
		public override string long_name { get { return "MP3 (MPEG audio layer 3)"; } }
		public override CodecID id { get { return CodecID.CODEC_ID_MP3; } }
		override public uint capabilities { get { return Constants.CODEC_CAP_DR1; } }
		public override AVMediaType type { get { return AVMediaType.AVMEDIA_TYPE_AUDIO; } }
	}
}
