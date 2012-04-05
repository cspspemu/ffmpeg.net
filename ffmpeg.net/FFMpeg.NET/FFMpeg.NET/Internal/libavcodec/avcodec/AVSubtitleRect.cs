using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public struct AVSubtitleRect
	{
	    public int x;         ///< top left corner  of pict, undefined when pict is not set
	    public int y;         ///< top left corner  of pict, undefined when pict is not set
	    public int w;         ///< width            of pict, undefined when pict is not set
	    public int h;         ///< height           of pict, undefined when pict is not set
	    public int nb_colors; ///< number of colors in pict, undefined when pict is not set

	    /**
	     * data+linesize for the bitmap of this subtitle.
	     * can be set for text/ass as well once they where rendered
	     */
	    public AVPicture pict;
		public AVSubtitleType type;

		//public char* text;                     ///< 0 terminated plain UTF-8 text
		public string text;

	    /**
	     * 0 terminated ASS/SSA compatible event line.
	     * The pressentation of this is unaffected by the other values in this
	     * struct.
	     */
	    //char *ass;
		public string ass;
	}
}
