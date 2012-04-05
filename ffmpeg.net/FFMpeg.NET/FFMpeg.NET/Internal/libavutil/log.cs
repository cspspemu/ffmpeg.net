using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFMpeg.NET.Internal.libavcodec.avcodec;

namespace FFMpeg.NET.Internal.libavutil
{
	public class log
	{
		public const int AV_LOG_QUIET = -8;

		/**
		 * Something went really wrong and we will crash now.
		 */
		public const int AV_LOG_PANIC   =  0;

		/**
		 * Something went wrong and recovery is not possible.
		 * For example, no header was found for a format which depends
		 * on headers or an illegal combination of parameters is used.
		 */
		public const int AV_LOG_FATAL    = 8;

		/**
		 * Something went wrong and cannot losslessly be recovered.
		 * However, not all future data is affected.
		 */
		public const int AV_LOG_ERROR   = 16;

		/**
		 * Something somehow does not look correct. This may or may not
		 * lead to problems. An example would be the use of '-vstrict -2'.
		 */
		public const int AV_LOG_WARNING = 24;

		public const int AV_LOG_INFO    = 32;
		public const int AV_LOG_VERBOSE = 40;

		/**
		 * Stuff which is only useful for libav* developers.
		 */
		public const int AV_LOG_DEBUG   = 48;

		static public void av_log(AVCodecContext avctx, int Level, string Format, params object[] Params)
		{
			Console.Error.WriteLine("{0}", Format);
			//throw new NotImplementedException();
		}
	}
}
