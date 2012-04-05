using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public class Global
	{
		///**
		// * Required number of additionally allocated bytes at the end of the input bitstream for decoding.
		// * This is mainly needed because some optimized bitstream readers read
		// * 32 or 64 bit at once and could read over the end.<br>
		// * Note: If the first 23 bits of the additional bytes are not 0, then damaged
		// * MPEG bitstreams could cause overread and segfault.
		// */
		public const int FF_INPUT_BUFFER_PADDING_SIZE = 16;

		///**
		// * minimum encoding buffer size
		// * Used to avoid some checks during header writing.
		// */
		public const int FF_MIN_BUFFER_SIZE = 16384;

		public const int FF_MAX_B_FRAMES = 16;

		///* encoding support
		//   These flags can be passed in AVCodecContext.flags before initialization.
		//   Note: Not everything is supported yet.
		//*/

		public const uint CODEC_FLAG_QSCALE = 0x0002;  ///< Use fixed qscale.
		public const uint CODEC_FLAG_4MV    = 0x0004;  ///< 4 MV per MB allowed / advanced prediction for H.263.
		public const uint CODEC_FLAG_QPEL   = 0x0010;  ///< Use qpel MC.
		public const uint CODEC_FLAG_GMC    = 0x0020;  ///< Use GMC.
		public const uint CODEC_FLAG_MV0    = 0x0040;  ///< Always try a MB with MV=<0,0>.
													  ///
		///**
		// * The parent program guarantees that the input for B-frames containing
		// * streams is not written to for at least s->max_b_frames+1 frames, if
		// * this is not set the input will be copied.
		// */
		public const uint CODEC_FLAG_INPUT_PRESERVED = 0x0100;
		public const uint CODEC_FLAG_PASS1           = 0x0200;   ///< Use internal 2pass ratecontrol in first pass mode.
		public const uint CODEC_FLAG_PASS2           = 0x0400;   ///< Use internal 2pass ratecontrol in second pass mode.
		public const uint CODEC_FLAG_GRAY            = 0x2000;   ///< Only decode/encode grayscale.
		public const uint CODEC_FLAG_EMU_EDGE        = 0x4000;   ///< Don't draw edges.
		public const uint CODEC_FLAG_PSNR            = 0x8000;   ///< error[?] variables will be set during encoding.
		public const uint CODEC_FLAG_TRUNCATED       = 0x00010000; /** Input bitstream might be truncated at a random
		//                                                  location instead of only at frame boundaries. */
		public const uint CODEC_FLAG_NORMALIZE_AQP  = 0x00020000; ///< Normalize adaptive quantization.
		public const uint CODEC_FLAG_INTERLACED_DCT = 0x00040000; ///< Use interlaced DCT.
		public const uint CODEC_FLAG_LOW_DELAY      = 0x00080000; ///< Force low delay.
		public const uint CODEC_FLAG_GLOBAL_HEADER  = 0x00400000; ///< Place global headers in extradata instead of every keyframe.
		public const uint CODEC_FLAG_BITEXACT       = 0x00800000; ///< Use only bitexact stuff (except (I)DCT).
		///* Fx : Flag for h263+ extra options */
		public const uint CODEC_FLAG_AC_PRED        = 0x01000000; ///< H.263 advanced intra coding / MPEG-4 AC prediction
		public const uint CODEC_FLAG_LOOP_FILTER    = 0x00000800; ///< loop filter
		public const uint CODEC_FLAG_INTERLACED_ME  = 0x20000000; ///< interlaced motion estimation
		public const uint CODEC_FLAG_CLOSED_GOP     = 0x80000000;
		public const uint CODEC_FLAG2_FAST          = 0x00000001; ///< Allow non spec compliant speedup tricks.
		public const uint CODEC_FLAG2_NO_OUTPUT     = 0x00000004; ///< Skip bitstream encoding.
		public const uint CODEC_FLAG2_LOCAL_HEADER  = 0x00000008; ///< Place global headers at every keyframe instead of in extradata.
		public const uint CODEC_FLAG2_DROP_FRAME_TIMECODE = 0x00002000; ///< timecode is in drop frame format. DEPRECATED!!!!
#if FF_API_MPV_GLOBAL_OPTS
		public const uint CODEC_FLAG_CBP_RD         = 0x04000000; ///< Use rate distortion optimization for cbp.
		public const uint CODEC_FLAG_QP_RD          = 0x08000000; ///< Use rate distortion optimization for qp selectioon.
		public const uint CODEC_FLAG2_STRICT_GOP    = 0x00000002; ///< Strictly enforce GOP size.
		public const uint CODEC_FLAG2_SKIP_RD       = 0x00004000; ///< RD optimal MB level residual skipping
#endif
		public const uint CODEC_FLAG2_CHUNKS        = 0x00008000; ///< Input bitstream might be truncated at a packet boundaries instead of only at frame boundaries.
		public const uint CODEC_FLAG2_SHOW_ALL      = 0x00400000; ///< Show all frames before the first keyframe

	}
}
