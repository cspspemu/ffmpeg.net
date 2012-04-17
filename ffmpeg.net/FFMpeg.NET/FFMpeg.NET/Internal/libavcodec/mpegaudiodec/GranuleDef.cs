using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.mpegaudiodec
{
	/* layer 3 "granule" */
	public struct GranuleDef
	{
	    byte scfsi;
	    int part2_3_length;
	    int big_values;
	    int global_gain;
	    int scalefac_compress;
	    byte block_type;
	    byte switch_point;

	    //int table_select[3];
		Unimplemented table_select;

	    //int subblock_gain[3];
		Unimplemented subblock_gain;

	    byte scalefac_scale;
	    byte count1table_select;

	    //int region_size[3]; /* number of huffman codes in each region */
		Unimplemented region_size;

	    int preflag;
	    int short_start, long_end; /* long/short band indexes */

	    //byte scale_factors[40];
		Unimplemented scale_factors;

	    //DECLARE_ALIGNED(16, INTFLOAT, sb_hybrid)[SBLIMIT * 18]; /* 576 samples */
		Unimplemented sb_hybrid;
	}

}
