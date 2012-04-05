using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	public class Constants
	{
		public const int AV_NUM_DATA_POINTERS = 8;

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

		/* Unsupported options :
		 *              Syntax Arithmetic coding (SAC)
		 *              Reference Picture Selection
		 *              Independent Segment Decoding */
		/* /Fx */
		/* codec capabilities */

		public uint CODEC_CAP_DRAW_HORIZ_BAND = 0x0001; ///< Decoder can use draw_horiz_band callback.
		/**
		 * Codec uses get_buffer() for allocating buffers and supports custom allocators.
		 * If not set, it might not use get_buffer() at all or use operations that
		 * assume the buffer was allocated by avcodec_default_get_buffer.
		 */
		public uint CODEC_CAP_DR1             = 0x0002;
		public uint CODEC_CAP_TRUNCATED       = 0x0008;
		/* Codec can export data for HW decoding (XvMC). */
		public uint CODEC_CAP_HWACCEL         = 0x0010;

		/**
		 * Encoder or decoder requires flushing with NULL input at the end in order to
		 * give the complete and correct output.
		 *
		 * NOTE: If this flag is not set, the codec is guaranteed to never be fed with
		 *       with NULL data. The user can still send NULL data to the public encode
		 *       or decode function, but libavcodec will not pass it along to the codec
		 *       unless this flag is set.
		 *
		 * Decoders:
		 * The decoder has a non-zero delay and needs to be fed with avpkt->data=NULL,
		 * avpkt->size=0 at the end to get the delayed data until the decoder no longer
		 * returns frames.
		 *
		 * Encoders:
		 * The encoder needs to be fed with NULL data at the end of encoding until the
		 * encoder no longer returns data.
		 *
		 * NOTE: For encoders implementing the AVCodec.encode2() function, setting this
		 *       flag also means that the encoder must set the pts and duration for
		 *       each output packet. If this flag is not set, the pts and duration will
		 *       be determined by libavcodec from the input frame.
		 */
		public const uint CODEC_CAP_DELAY = 0x0020;
		/**
		 * Codec can be fed a final frame with a smaller size.
		 * This can be used to prevent truncation of the last audio samples.
		 */
		public const uint CODEC_CAP_SMALL_LAST_FRAME = 0x0040;
		/**
		 * Codec can export data for HW decoding (VDPAU).
		 */
		public const uint CODEC_CAP_HWACCEL_VDPAU    = 0x0080;
		/**
		 * Codec can output multiple frames per AVPacket
		 * Normally demuxers return one frame at a time, demuxers which do not do
		 * are connected to a parser to split what they return into proper frames.
		 * This flag is reserved to the very rare category of codecs which have a
		 * bitstream that cannot be split into frames without timeconsuming
		 * operations like full decoding. Demuxers carring such bitstreams thus
		 * may return multiple frames in a packet. This has many disadvantages like
		 * prohibiting stream copy in many cases thus it should only be considered
		 * as a last resort.
		 */
		public const uint  CODEC_CAP_SUBFRAMES        = 0x0100;
		/**
		 * Codec is experimental and is thus avoided in favor of non experimental
		 * encoders
		 */
		public const uint CODEC_CAP_EXPERIMENTAL     = 0x0200;
		/**
		 * Codec should fill in channel configuration and samplerate instead of container
		 */
		public const uint CODEC_CAP_CHANNEL_CONF     = 0x0400;

		/**
		 * Codec is able to deal with negative linesizes
		 */
		public const uint CODEC_CAP_NEG_LINESIZES    = 0x0800;

		/**
		 * Codec supports frame-level multithreading.
		 */
		public const uint CODEC_CAP_FRAME_THREADS    = 0x1000;
		/**
		 * Codec supports slice-based (or partition-based) multithreading.
		 */
		public const uint CODEC_CAP_SLICE_THREADS    = 0x2000;
		/**
		 * Codec supports changed parameters at any point.
		 */
		public const uint CODEC_CAP_PARAM_CHANGE     = 0x4000;
		/**
		 * Codec supports avctx->thread_count == 0 (auto).
		 */
		public const uint CODEC_CAP_AUTO_THREADS     = 0x8000;
		/**
		 * Audio encoder supports receiving a different number of samples in each call.
		 */
		public const uint CODEC_CAP_VARIABLE_FRAME_SIZE = 0x10000;
		/**
		 * Codec is lossless.
		 */
		public const uint CODEC_CAP_LOSSLESS         = 0x80000000;

		////The following defines may change, don't e;xpect compatibility if you use them.
		public const uint MB_TYPE_INTRA4x4   = 0x0001;
		public const uint MB_TYPE_INTRA16x16 = 0x0002; //FIXME H.264-specific
		public const uint MB_TYPE_INTRA_PCM  = 0x0004; //FIXME H.264-specific
		public const uint MB_TYPE_16x16      = 0x0008;
		public const uint MB_TYPE_16x8       = 0x0010;
		public const uint MB_TYPE_8x16       = 0x0020;
		public const uint MB_TYPE_8x8        = 0x0040;
		public const uint MB_TYPE_INTERLACED = 0x0080;
		public const uint MB_TYPE_DIRECT2    = 0x0100; //FIXME
		public const uint MB_TYPE_ACPRED     = 0x0200;
		public const uint MB_TYPE_GMC        = 0x0400;
		public const uint MB_TYPE_SKIP       = 0x0800;
		public const uint MB_TYPE_P0L0       = 0x1000;
		public const uint MB_TYPE_P1L0       = 0x2000;
		public const uint MB_TYPE_P0L1       = 0x4000;
		public const uint MB_TYPE_P1L1       = 0x8000;
		public const uint MB_TYPE_L0         = (MB_TYPE_P0L0 | MB_TYPE_P1L0);
		public const uint MB_TYPE_L1         = (MB_TYPE_P0L1 | MB_TYPE_P1L1);
		public const uint MB_TYPE_L0L1       = (MB_TYPE_L0   | MB_TYPE_L1);
		public const uint MB_TYPE_QUANT      = 0x00010000;
		public const uint MB_TYPE_CBP        = 0x00020000;
		//Note bits 24-31 are reserved for codec specific use (h264 ref0, mpeg1 0mv, ...)

		public const uint FF_QSCALE_TYPE_MPEG1 = 0;
		public const uint FF_QSCALE_TYPE_MPEG2 = 1;
		public const uint FF_QSCALE_TYPE_H264  = 2;
		public const uint FF_QSCALE_TYPE_VP56  = 3;
		
		public const uint FF_BUFFER_TYPE_INTERNAL = 1;
		public const uint FF_BUFFER_TYPE_USER     = 2; ///< direct rendering buffers (image is (de)allocated by user)
		public const uint FF_BUFFER_TYPE_SHARED   = 4; ///< Buffer from somewhere else; don't deallocate image (data/base), all other tables are not shared.
		public const uint FF_BUFFER_TYPE_COPY     = 8; ///< Just a (modified) copy of some other buffer, don't deallocate anything.
		
		public const uint FF_BUFFER_HINTS_VALID    = 0x01; // Buffer hints value is meaningful (if 0 ignore).
		public const uint FF_BUFFER_HINTS_READABLE = 0x02; // Codec will read from buffer.
		public const uint FF_BUFFER_HINTS_PRESERVE = 0x04; // User must not alter buffer content.
		public const uint FF_BUFFER_HINTS_REUSABLE = 0x08; // Codec will reuse the buffer (update).

		public const uint AV_PKT_FLAG_KEY     = 0x0001; ///< The packet contains a keyframe
		public const uint AV_PKT_FLAG_CORRUPT = 0x0002; ///< The packet content is corrupted

		/**
		 * An AV_PKT_DATA_PARAM_CHANGE side data packet is laid out as follows:
		 * u32le param_flags
		 * if (param_flags & AV_SIDE_DATA_PARAM_CHANGE_CHANNEL_COUNT)
		 *     s32le channel_count
		 * if (param_flags & AV_SIDE_DATA_PARAM_CHANGE_CHANNEL_LAYOUT)
		 *     u64le channel_layout
		 * if (param_flags & AV_SIDE_DATA_PARAM_CHANGE_SAMPLE_RATE)
		 *     s32le sample_rate
		 * if (param_flags & AV_SIDE_DATA_PARAM_CHANGE_DIMENSIONS)
		 *     s32le width
		 *     s32le height
		 */

		/**
		 * An AV_PKT_DATA_H263_MB_INFO side data packet contains a number of
		 * structures with info about macroblocks relevant to splitting the
		 * packet into smaller packets on macroblock edges (e.g. as for RFC 2190).
		 * That is, it does not necessarily contain info about all macroblocks,
		 * as long as the distance between macroblocks in the info is smaller
		 * than the target payload size.
		 * Each MB info structure is 12 bytes, and is laid out as follows:
		 * u32le bit offset from the start of the packet
		 * u8    current quantizer at the start of the macroblock
		 * u8    GOB number
		 * u16le macroblock address within the GOB
		 * u8    horizontal MV predictor
		 * u8    vertical MV predictor
		 * u8    horizontal MV predictor for block number 3
		 * u8    vertical MV predictor for block number 3
		 */

		public const int AVPALETTE_SIZE = 1024;
		public const int AVPALETTE_COUNT = 256;
	}
}
