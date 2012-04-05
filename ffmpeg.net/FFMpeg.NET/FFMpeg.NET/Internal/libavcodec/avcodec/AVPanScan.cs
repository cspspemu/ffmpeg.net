using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	/**
	 * Pan Scan area.
	 * This specifies the area which should be displayed.
	 * Note there may be multiple such areas for one frame.
	 */
	//public struct AVPanScan
	public class AVPanScan
	{
	    /**
	     * id
	     * - encoding: Set by user.
	     * - decoding: Set by libavcodec.
	     */
	    public int id;

	    /**
	     * width and height in 1/16 pel
	     * - encoding: Set by user.
	     * - decoding: Set by libavcodec.
	     */
	    public int width;
	    public int height;

	    /**
	     * position of the top left corner in 1/16 pel for up to 3 fields/frames
	     * - encoding: Set by user.
	     * - decoding: Set by libavcodec.
	     */
	    //public short[,] position; // [3][2];
		public short[,] position = new short[3,2];
	}
}
