using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	/**
	 * AVHWAccel.
	 */
	//public struct AVHWAccel
	public class AVHWAccel
	{
	    /**
	     * Name of the hardware accelerated codec.
	     * The name is globally unique among encoders and among decoders (but an
	     * encoder and a decoder can share the same name).
	     */
	    public string name;

	    /**
	     * Type of codec implemented by the hardware accelerator.
	     *
	     * See AVMEDIA_TYPE_xxx
	     */
	    //enum AVMediaType type;
		public Unimplemented type;

	    /**
	     * Codec implemented by the hardware accelerator.
	     *
	     * See CODEC_ID_xxx
	     */
	    public CodecID id;

	    /**
	     * Supported pixel format.
	     *
	     * Only hardware accelerated formats are supported here.
	     */
	    //enum PixelFormat pix_fmt;
		public Unimplemented pix_fmt;

	    /**
	     * Hardware accelerated codec capabilities.
	     * see FF_HWACCEL_CODEC_CAP_*
	     */
	    public int capabilities;

	    public AVHWAccel next;

	    /**
	     * Called at the beginning of each frame or field picture.
	     *
	     * Meaningful frame information (codec specific) is guaranteed to
	     * be parsed at this point. This function is mandatory.
	     *
	     * Note that buf can be NULL along with buf_size set to 0.
	     * Otherwise, this means the whole frame is available at this point.
	     *
	     * @param avctx the codec context
	     * @param buf the frame data buffer base
	     * @param buf_size the size of the frame in bytes
	     * @return zero if successful, a negative value otherwise
	     */
	    //int (*start_frame)(AVCodecContext *avctx, const uint8_t *buf, uint32_t buf_size);
		public Unimplemented start_frame;

	    /**
	     * Callback for each slice.
	     *
	     * Meaningful slice information (codec specific) is guaranteed to
	     * be parsed at this point. This function is mandatory.
	     *
	     * @param avctx the codec context
	     * @param buf the slice data buffer base
	     * @param buf_size the size of the slice in bytes
	     * @return zero if successful, a negative value otherwise
	     */
	    //int (*decode_slice)(AVCodecContext *avctx, const uint8_t *buf, uint32_t buf_size);
		public Unimplemented decode_slice;

	    /**
	     * Called at the end of each frame or field picture.
	     *
	     * The whole picture is parsed at this point and can now be sent
	     * to the hardware accelerator. This function is mandatory.
	     *
	     * @param avctx the codec context
	     * @return zero if successful, a negative value otherwise
	     */
	    //int (*end_frame)(AVCodecContext *avctx);
		public Unimplemented end_frame;

	    /**
	     * Size of HW accelerator private data.
	     *
	     * Private data is allocated with av_mallocz() before
	     * AVCodecContext.get_buffer() and deallocated after
	     * AVCodecContext.release_buffer().
	     */
	    public int priv_data_size;
	}

}
