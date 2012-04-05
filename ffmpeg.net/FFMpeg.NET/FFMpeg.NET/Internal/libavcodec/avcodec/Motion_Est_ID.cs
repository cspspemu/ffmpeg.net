using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	/**
	 * motion estimation type.
	 */
	public enum Motion_Est_ID
	{
	    ME_ZERO = 1,    ///< no search, that is use 0,0 vector whenever one is needed
	    ME_FULL,
	    ME_LOG,
	    ME_PHODS,
	    ME_EPZS,        ///< enhanced predictive zonal search
	    ME_X1,          ///< reserved for experiments
	    ME_HEX,         ///< hexagon based search
	    ME_UMH,         ///< uneven multi-hexagon search
	    ME_ITER,        ///< iterative search
	    ME_TESA,        ///< transformed exhaustive search algorithm
	};
}
