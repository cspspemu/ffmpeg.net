using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFMpeg.NET.Internal.libavcodec.avcodec;

namespace FFMpeg.NET.Internal.libavcodec.bmp
{
	public class ff_bmp_decoder : AVCodec
	{
		public override string name { get { return "bmp"; } }
		public override string long_name { get { return "BMP image"; } }
		public override CodecID id { get { return CodecID.CODEC_ID_BMP; } }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="avctx"></param>
		/// <returns></returns>
		override public int init(AVCodecContext avctx)
		{
			var s = (BMPContext)avctx.priv_data;

			//avcodec_get_frame_defaults(s.picture);
			throw(new NotImplementedException());

			avctx.coded_frame = s.picture;

			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="avctx"></param>
		/// <returns></returns>
		public override int close(AVCodecContext avctx)
		{
			var c = (BMPContext)avctx.priv_data;

			//if (c.picture.data[0]) avctx->release_buffer(avctx, c.picture);
			throw (new NotImplementedException());

			return 0;
		}
	}
}
