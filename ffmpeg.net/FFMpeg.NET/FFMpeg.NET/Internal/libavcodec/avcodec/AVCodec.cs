using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{
	/**
	 * AVCodec.
	 */
	//public struct AVCodec
	public abstract class AVCodec
	{
	    /**
	     * Name of the codec implementation.
	     * The name is globally unique among encoders and among decoders (but an
	     * encoder and a decoder can share the same name).
	     * This is the primary way to find a codec from the user perspective.
	     */
	    //const char *name;
		abstract public string name { get; }

	    /**
	     * Descriptive name for the codec, meant to be more human readable than name.
	     * You should use the NULL_IF_CONFIG_SMALL() macro to define it.
	     */
	    //const char *long_name;
		abstract public string long_name { get; }

	    //enum AVMediaType type;
		public Unimplemented type;

		abstract public CodecID id { get; }

	    /**
	     * Codec capabilities.
	     * see CODEC_CAP_*
	     */
		virtual public uint capabilities { get { return 0; } }

	    //const AVRational *supported_framerates; ///< array of supported framerates, or NULL if any, array is terminated by {0,0}
		public Unimplemented supported_framerates;

	    //const enum PixelFormat *pix_fmts;       ///< array of supported pixel formats, or NULL if unknown, array is terminated by -1
		public Unimplemented pix_fmts;

	    public int[] supported_samplerates;       ///< array of supported audio samplerates, or NULL if unknown, array is terminated by 0

	    //const enum AVSampleFormat *sample_fmts; ///< array of supported sample formats, or NULL if unknown, array is terminated by -1
		public Unimplemented sample_fmts;

	    //const uint64_t *channel_layouts;         ///< array of support channel layouts, or NULL if unknown. array is terminated by 0
		public ulong[] channel_layouts;

	    public byte max_lowres;                     ///< maximum value for lowres supported by the decoder
												///
	    //const AVClass *priv_class;              ///< AVClass for the private context
		public Unimplemented priv_class;

	    public AVProfile[] profiles;              ///< array of recognized profiles, or NULL if unknown, array is terminated by {FF_PROFILE_UNKNOWN}

	    /*****************************************************************
	     * No fields below this line are part of the public API. They
	     * may not be used outside of libavcodec and can be changed and
	     * removed at will.
	     * New public fields should be added right above.
	     *****************************************************************
	     */
	    public int priv_data_size;
	    public AVCodec next;
	    /**
	     * @name Frame-level threading support functions
	     * @{
	     */
	    /**
	     * If defined, called on thread contexts when they are created.
	     * If the codec allocates writable tables in init(), re-allocate them here.
	     * priv_data will be set to a copy of the original.
	     */
	    //int (*init_thread_copy)(AVCodecContext *);
		public Unimplemented init_thread_copy;

	    /**
	     * Copy necessary context variables from a previous thread context to the current one.
	     * If not defined, the next thread will start automatically; otherwise, the codec
	     * must call ff_thread_finish_setup().
	     *
	     * dst and src will (rarely) point to the same context, in which case memcpy should be skipped.
	     */
	    //int (*update_thread_context)(AVCodecContext *dst, const AVCodecContext *src);
		public Unimplemented update_thread_context;

	    /** @} */

	    /**
	     * Private codec-specific defaults.
	     */
	    //const AVCodecDefault *defaults;
		public Unimplemented AVCodecDefault;

	    /**
	     * Initialize codec static data, called from avcodec_register().
	     */
	    //void (*init_static_data)(struct AVCodec *codec);
		public Unimplemented init_static_data;

	    //int (*init)(AVCodecContext *);
		virtual public int init(AVCodecContext avctx)
		{
			throw(new NotImplementedException());
		}

	    //int (*encode)(AVCodecContext *, uint8_t *buf, int buf_size, void *data);
		public Unimplemented encode;

	    /**
	     * Encode data to an AVPacket.
	     *
	     * @param      avctx          codec context
	     * @param      avpkt          output AVPacket (may contain a user-provided buffer)
	     * @param[in]  frame          AVFrame containing the raw data to be encoded
	     * @param[out] got_packet_ptr encoder sets to 0 or 1 to indicate that a
	     *                            non-empty packet was returned in avpkt.
	     * @return 0 on success, negative error code on failure
	     */
	    //int (*encode2)(AVCodecContext *avctx, AVPacket *avpkt, const AVFrame *frame, int *got_packet_ptr);
		public Unimplemented encode2;

	    //int (*decode)(AVCodecContext *, void *outdata, int *outdata_size, AVPacket *avpkt);
		//public Unimplemented decode;
		virtual public int decode(AVCodecContext avctx, Pointer<byte> outdata, ref int outdata_size, AVPacket avpkt)
		{
			throw (new NotImplementedException());
		}

	    /// <summary>
		/// int (*close)(AVCodecContext *);
	    /// </summary>
	    /// <param name="avctx"></param>
	    /// <returns></returns>
		virtual public int close(AVCodecContext avctx)
		{
			throw(new NotImplementedException());
		}

	    /**
	     * Flush buffers.
	     * Will be called when seeking
	     */
	    //void (*flush)(AVCodecContext *);
		virtual public void flush(AVCodecContext avctx)
		{
			throw(new NotImplementedException());
		}
	}
}
