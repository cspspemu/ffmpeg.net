using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	/**
	 * Audio Video Frame.
	 * New fields can be added to the end of AVFRAME with minor version
	 * bumps. Similarly fields that are marked as to be only accessed by
	 * av_opt_ptr() can be reordered. This allows 2 forks to add fields
	 * without breaking compatibility with each other.
	 * Removal, reordering and changes in the remaining cases require
	 * a major version bump.
	 * sizeof(AVFrame) must not be used outside libavcodec.
	 */
	//public struct AVFrame
	public class AVFrame
	{
	    /**
	     * pointer to the picture/channel planes.
	     * This might be different from the first allocated byte
	     * - encoding: Set by user
	     * - decoding: set by AVCodecContext.get_buffer()
	     */
	    //uint8_t *data[AV_NUM_DATA_POINTERS];
		public Unimplemented data;

	    /**
	     * Size, in bytes, of the data for each picture/channel plane.
	     *
	     * For audio, only linesize[0] may be set. For planar audio, each channel
	     * plane must be the same size.
	     *
	     * - encoding: Set by user
	     * - decoding: set by AVCodecContext.get_buffer()
	     */
	    public int[] linesize = new int[Constants.AV_NUM_DATA_POINTERS];

	    /**
	     * pointers to the data planes/channels.
	     *
	     * For video, this should simply point to data[].
	     *
	     * For planar audio, each channel has a separate data pointer, and
	     * linesize[0] contains the size of each channel buffer.
	     * For packed audio, there is just one data pointer, and linesize[0]
	     * contains the total size of the buffer for all channels.
	     *
	     * Note: Both data and extended_data will always be set by get_buffer(),
	     * but for planar audio with more channels that can fit in data,
	     * extended_data must be used by the decoder in order to access all
	     * channels.
	     *
	     * encoding: unused
	     * decoding: set by AVCodecContext.get_buffer()
	     */
	    //uint8_t **extended_data;
		public Unimplemented extended_data;

	    /**
	     * width and height of the video frame
	     * - encoding: unused
	     * - decoding: Read by user.
	     */
	    public int width, height;

	    /**
	     * number of audio samples (per channel) described by this frame
	     * - encoding: Set by user
	     * - decoding: Set by libavcodec
	     */
	    public int nb_samples;

	    /**
	     * format of the frame, -1 if unknown or unset
	     * Values correspond to enum PixelFormat for video frames,
	     * enum AVSampleFormat for audio)
	     * - encoding: unused
	     * - decoding: Read by user.
	     */
	    public int format;

	    /**
	     * 1 -> keyframe, 0-> not
	     * - encoding: Set by libavcodec.
	     * - decoding: Set by libavcodec.
	     */
	    public int key_frame;

	    /**
	     * Picture type of the frame, see ?_TYPE below.
	     * - encoding: Set by libavcodec. for coded_picture (and set by user for input).
	     * - decoding: Set by libavcodec.
	     */
	    //public AVPictureType pict_type;
		public Unimplemented pict_type;

	    /**
	     * pointer to the first allocated byte of the picture. Can be used in get_buffer/release_buffer.
	     * This isn't used by libavcodec unless the default get/release_buffer() is used.
	     * - encoding:
	     * - decoding:
	     */
	    //uint8_t *_base[AV_NUM_DATA_POINTERS];
		public Unimplemented _base;

	    /**
	     * sample aspect ratio for the video frame, 0/1 if unknown\unspecified
	     * - encoding: unused
	     * - decoding: Read by user.
	     */
	    //public AVRational sample_aspect_ratio;
		public Unimplemented sample_aspect_ratio;

	    /**
	     * presentation timestamp in time_base units (time when frame should be shown to user)
	     * If AV_NOPTS_VALUE then frame_rate = 1/time_base will be assumed.
	     * - encoding: MUST be set by user.
	     * - decoding: Set by libavcodec.
	     */
	    public long pts;

	    /**
	     * reordered pts from the last AVPacket that has been input into the decoder
	     * - encoding: unused
	     * - decoding: Read by user.
	     */
	    public long pkt_pts;

	    /**
	     * dts from the last AVPacket that has been input into the decoder
	     * - encoding: unused
	     * - decoding: Read by user.
	     */
	    public long pkt_dts;

	    /**
	     * picture number in bitstream order
	     * - encoding: set by
	     * - decoding: Set by libavcodec.
	     */
	    public int coded_picture_number;

	    /**
	     * picture number in display order
	     * - encoding: set by
	     * - decoding: Set by libavcodec.
	     */
	    public int display_picture_number;

	    /**
	     * quality (between 1 (good) and FF_LAMBDA_MAX (bad))
	     * - encoding: Set by libavcodec. for coded_picture (and set by user for input).
	     * - decoding: Set by libavcodec.
	     */
	    public int quality;

	    /**
	     * is this picture used as reference
	     * The values for this are the same as the MpegEncContext.picture_structure
	     * variable, that is 1->top field, 2->bottom field, 3->frame/both fields.
	     * Set to 4 for delayed, non-reference frames.
	     * - encoding: unused
	     * - decoding: Set by libavcodec. (before get_buffer() call)).
	     */
	    public int reference;

	    /**
	     * QP table
	     * - encoding: unused
	     * - decoding: Set by libavcodec.
	     */
	    //int8_t *qscale_table;
		public sbyte[] qscale_table;

	    /**
	     * QP store stride
	     * - encoding: unused
	     * - decoding: Set by libavcodec.
	     */
	    public int qstride;

	    /**
	     *
	     */
	    public int qscale_type;

	    /**
	     * mbskip_table[mb]>=1 if MB didn't change
	     * stride= mb_width = (width+15)>>4
	     * - encoding: unused
	     * - decoding: Set by libavcodec.
	     */
	    // uint8_t *mbskip_table;
		public byte[] mbskip_table;

	    /**
	     * motion vector table
	     * @code
	     * example:
	     * int mv_sample_log2= 4 - motion_subsample_log2;
	     * int mb_width= (width+15)>>4;
	     * int mv_stride= (mb_width << mv_sample_log2) + 1;
	     * motion_val[direction][x + y*mv_stride][0->mv_x, 1->mv_y];
	     * @endcode
	     * - encoding: Set by user.
	     * - decoding: Set by libavcodec.
	     */
	    //int16_t (*motion_val[2])[2];
		public Unimplemented motion_val;

	    /**
	     * macroblock type table
	     * mb_type_base + mb_width + 2
	     * - encoding: Set by user.
	     * - decoding: Set by libavcodec.
	     */
	    //uint32_t *mb_type;
		public uint[] mb_type;

	    /**
	     * DCT coefficients
	     * - encoding: unused
	     * - decoding: Set by libavcodec.
	     */
	    //short *dct_coeff;
		public short[] dct_coeff;

	    /**
	     * motion reference frame index
	     * the order in which these are stored can depend on the codec.
	     * - encoding: Set by user.
	     * - decoding: Set by libavcodec.
	     */
	    //int8_t *ref_index[2];
		public Unimplemented ref_index;

	    /**
	     * for some private data of the user
	     * - encoding: unused
	     * - decoding: Set by user.
	     */
	    //void *opaque;
		public object opaque;

	    /**
	     * error
	     * - encoding: Set by libavcodec. if flags&CODEC_FLAG_PSNR.
	     * - decoding: unused
	     */
	    //uint64_t error[AV_NUM_DATA_POINTERS];
		public ulong[] error = new ulong[Constants.AV_NUM_DATA_POINTERS];

	    /**
	     * type of the buffer (to keep track of who has to deallocate data[*])
	     * - encoding: Set by the one who allocates it.
	     * - decoding: Set by the one who allocates it.
	     * Note: User allocated (direct rendering) & internal buffers cannot coexist currently.
	     */
	    public int type;

	    /**
	     * When decoding, this signals how much the picture must be delayed.
	     * extra_delay = repeat_pict / (2*fps)
	     * - encoding: unused
	     * - decoding: Set by libavcodec.
	     */
	    public int repeat_pict;

	    /**
	     * The content of the picture is interlaced.
	     * - encoding: Set by user.
	     * - decoding: Set by libavcodec. (default 0)
	     */
	    public int interlaced_frame;

	    /**
	     * If the content is interlaced, is top field displayed first.
	     * - encoding: Set by user.
	     * - decoding: Set by libavcodec.
	     */
	    public int top_field_first;

	    /**
	     * Tell user application that palette has changed from previous frame.
	     * - encoding: ??? (no palette-enabled encoder yet)
	     * - decoding: Set by libavcodec. (default 0).
	     */
	    public int palette_has_changed;

	    /**
	     * codec suggestion on buffer type if != 0
	     * - encoding: unused
	     * - decoding: Set by libavcodec. (before get_buffer() call)).
	     */
	    public int buffer_hints;

	    /**
	     * Pan scan.
	     * - encoding: Set by user.
	     * - decoding: Set by libavcodec.
	     */
	    public AVPanScan pan_scan;

	    /**
	     * reordered opaque 64bit (generally an integer or a double precision float
	     * PTS but can be anything).
	     * The user sets AVCodecContext.reordered_opaque to represent the input at
	     * that time,
	     * the decoder reorders values as needed and sets AVFrame.reordered_opaque
	     * to exactly one of the values provided by the user through AVCodecContext.reordered_opaque
	     * @deprecated in favor of pkt_pts
	     * - encoding: unused
	     * - decoding: Read by user.
	     */
	    public long reordered_opaque;

	    /**
	     * hardware accelerator private data (FFmpeg-allocated)
	     * - encoding: unused
	     * - decoding: Set by libavcodec
	     */
	    //void *hwaccel_picture_private;
		public object hwaccel_picture_private;

	    /**
	     * the AVCodecContext which ff_thread_get_buffer() was last called on
	     * - encoding: Set by libavcodec.
	     * - decoding: Set by libavcodec.
	     */
	    //struct AVCodecContext *owner;
		public Unimplemented owner;

	    /**
	     * used by multithreading to store frame-specific info
	     * - encoding: Set by libavcodec.
	     * - decoding: Set by libavcodec.
	     */
	    // void *thread_opaque;
		public object thread_opaque;

	    /**
	     * log2 of the size of the block which a single vector in motion_val represents:
	     * (4->16x16, 3->8x8, 2-> 4x4, 1-> 2x2)
	     * - encoding: unused
	     * - decoding: Set by libavcodec.
	     */
	    public byte motion_subsample_log2;

	    /**
	     * frame timestamp estimated using various heuristics, in stream time base
	     * Code outside libavcodec should access this field using:
	     *  av_opt_ptr(avcodec_get_frame_class(), frame, "best_effort_timestamp");
	     * - encoding: unused
	     * - decoding: set by libavcodec, read by user.
	     */
	    public long best_effort_timestamp;

	    /**
	     * reordered pos from the last AVPacket that has been input into the decoder
	     * Code outside libavcodec should access this field using:
	     *  av_opt_ptr(avcodec_get_frame_class(), frame, "pkt_pos");
	     * - encoding: unused
	     * - decoding: Read by user.
	     */
	    public long pkt_pos;
	}
}
