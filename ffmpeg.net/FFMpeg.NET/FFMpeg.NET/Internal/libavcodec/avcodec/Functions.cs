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
	}
}
