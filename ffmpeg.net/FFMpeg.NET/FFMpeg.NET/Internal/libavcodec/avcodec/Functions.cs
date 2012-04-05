using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public class Functions
	{
		/**
		 * Set the fields of the given AVFrame to default values.
		 *
		 * @param pic The AVFrame of which the fields should be set to default values.
		 */
		static public void avcodec_get_frame_defaults(AVFrame pic)
		{
			Unimplemented.MarkWarning("avcodec_get_frame_defaults");
			//throw(new NotImplementedException());
		}

		/**
		 * Get the name of a codec.
		 * @return  a static string identifying the codec; never NULL
		 */
		static public string avcodec_get_name(CodecID id)
		{
			throw(new NotImplementedException());
		}

		static public void avcodec_set_dimensions(AVCodecContext s, int width, int height)
		{
			s.width = width;
			s.height = height;
		}
	}
}
