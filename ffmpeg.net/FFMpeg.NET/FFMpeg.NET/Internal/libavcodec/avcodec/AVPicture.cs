using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	/**
	 * four components are given, that's all.
	 * the last component is alpha
	 */
	//public struct AVPicture
	public class AVPicture
	{
	    //uint8_t *data[AVFrame.AV_NUM_DATA_POINTERS];
		public Unimplemented data;

		public int[] linesize = new int[Constants.AV_NUM_DATA_POINTERS];     ///< number of bytes per line
	}
}
