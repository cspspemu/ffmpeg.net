using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.mpegaudiodec
{
	public class MpegUtils
	{
		/* max frame size, in samples */
		public const int MPA_FRAME_SIZE = 1152;

		/* max compressed frame size */
		public const int MPA_MAX_CODED_FRAME_SIZE = 1792;

		public const int MPA_MAX_CHANNELS = 2;

		public const int SBLIMIT = 32; /* number of subbands */

		public const int MPA_STEREO  = 0;
		public const int MPA_JSTEREO = 1;
		public const int MPA_DUAL    = 2;
		public const int MPA_MONO    = 3;

		public const int FRAC_BITS   = 23;   /* fractional bits for sb_samples and dct */
		public const int WFRAC_BITS  = 16;   /* fractional bits for window */

		public const int FRAC_ONE = (1 << FRAC_BITS);

		public int FIX(int a) { return  ((int)((a) * FRAC_ONE)); }

		public const int HEADER_SIZE = 4;

		// FLOAT
		/*
		#   define SHR(a,b)       ((a)*(1.0f/(1<<(b))))
		#   define FIXR_OLD(a)    ((int)((a) * FRAC_ONE + 0.5))
		#   define FIXR(x)        ((float)(x))
		#   define FIXHR(x)       ((float)(x))
		#   define MULH3(x, y, s) ((s)*(y)*(x))
		#   define MULLx(x, y, s) ((y)*(x))
		#   define RENAME(a) a ## _float
		#   define OUT_FMT AV_SAMPLE_FMT_FLT
		*/

		public const int BACKSTEP_SIZE = 512;
		public const int EXTRABYTES = 24;
		public const int LAST_BUF_SIZE = 2 * BACKSTEP_SIZE + EXTRABYTES;

		/* bitrate is in kb/s */
		int ff_mpa_l2_select_table(int bitrate, int nb_channels, int freq, bool lsf)
		{
			int ch_bitrate, table;

			ch_bitrate = bitrate / nb_channels;
			if (!lsf)
			{
				if ((freq == 48000 && ch_bitrate >= 56) ||
					(ch_bitrate >= 56 && ch_bitrate <= 80))
					table = 0;
				else if (freq != 48000 && ch_bitrate >= 96)
					table = 1;
				else if (freq != 32000 && ch_bitrate <= 48)
					table = 2;
				else
					table = 3;
			}
			else
			{
				table = 4;
			}
			return table;
		}
	}
}
