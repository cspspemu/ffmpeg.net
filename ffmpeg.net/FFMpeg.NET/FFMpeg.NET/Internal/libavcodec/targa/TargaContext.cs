using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFMpeg.NET.Internal.libavcodec.avcodec;
using FFMpeg.NET.Internal.libavutil;

namespace FFMpeg.NET.Internal.libavcodec.targa
{
	public class TargaContext
	{
		public AVFrame picture = new AVFrame();

		public GetByteContext gb;

		public int color_type;
		public int compression_type;
	}
}
