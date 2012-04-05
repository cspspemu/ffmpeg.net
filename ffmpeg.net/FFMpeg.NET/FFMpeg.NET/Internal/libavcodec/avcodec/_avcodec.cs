using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.avcodec
{

//struct AVCodecInternal;

//typedef struct AVCodecDefault AVCodecDefault;


///* resample.c */

//struct ReSampleContext;
//struct AVResampleContext;

//typedef struct ReSampleContext ReSampleContext;

///**
// *  Initialize audio resampling context.
// *
// * @param output_channels  number of output channels
// * @param input_channels   number of input channels
// * @param output_rate      output sample rate
// * @param input_rate       input sample rate
// * @param sample_fmt_out   requested output sample format
// * @param sample_fmt_in    input sample format
// * @param filter_length    length of each FIR filter in the filterbank relative to the cutoff frequency
// * @param log2_phase_count log2 of the number of entries in the polyphase filterbank
// * @param linear           if 1 then the used FIR filter will be linearly interpolated
//                           between the 2 closest, if 0 the closest will be used
// * @param cutoff           cutoff frequency, 1.0 corresponds to half the output sampling rate
// * @return allocated ReSampleContext, NULL if error occurred
// */
//ReSampleContext *av_audio_resample_init(int output_channels, int input_channels,
//                                        int output_rate, int input_rate,
//                                        enum AVSampleFormat sample_fmt_out,
//                                        enum AVSampleFormat sample_fmt_in,
//                                        int filter_length, int log2_phase_count,
//                                        int linear, double cutoff);

//int audio_resample(ReSampleContext *s, short *output, short *input, int nb_samples);

///**
// * Free resample context.
// *
// * @param s a non-NULL pointer to a resample context previously
// *          created with av_audio_resample_init()
// */
//void audio_resample_close(ReSampleContext *s);


///**
// * Initialize an audio resampler.
// * Note, if either rate is not an integer then simply scale both rates up so they are.
// * @param filter_length length of each FIR filter in the filterbank relative to the cutoff freq
// * @param log2_phase_count log2 of the number of entries in the polyphase filterbank
// * @param linear If 1 then the used FIR filter will be linearly interpolated
//                 between the 2 closest, if 0 the closest will be used
// * @param cutoff cutoff frequency, 1.0 corresponds to half the output sampling rate
// */
//struct AVResampleContext *av_resample_init(int out_rate, int in_rate, int filter_length, int log2_phase_count, int linear, double cutoff);

///**
// * Resample an array of samples using a previously configured context.
// * @param src an array of unconsumed samples
// * @param consumed the number of samples of src which have been consumed are returned here
// * @param src_size the number of unconsumed samples available
// * @param dst_size the amount of space in samples available in dst
// * @param update_ctx If this is 0 then the context will not be modified, that way several channels can be resampled with the same context.
// * @return the number of samples written in dst or -1 if an error occurred
// */
//int av_resample(struct AVResampleContext *c, short *dst, short *src, int *consumed, int src_size, int dst_size, int update_ctx);


///**
// * Compensate samplerate/timestamp drift. The compensation is done by changing
// * the resampler parameters, so no audible clicks or similar distortions occur
// * @param compensation_distance distance in output samples over which the compensation should be performed
// * @param sample_delta number of output samples which should be output less
// *
// * example: av_resample_compensate(c, 10, 500)
// * here instead of 510 samples only 500 samples would be output
// *
// * note, due to rounding the actual compensation might be slightly different,
// * especially if the compensation_distance is large and the in_rate used during init is small
// */
//void av_resample_compensate(struct AVResampleContext *c, int sample_delta, int compensation_distance);
//void av_resample_close(struct AVResampleContext *c);

///**
// * Allocate memory for a picture.  Call avpicture_free() to free it.
// *
// * @see avpicture_fill()
// *
// * @param picture the picture to be filled in
// * @param pix_fmt the format of the picture
// * @param width the width of the picture
// * @param height the height of the picture
// * @return zero if successful, a negative value if not
// */
//int avpicture_alloc(AVPicture *picture, enum PixelFormat pix_fmt, int width, int height);

///**
// * Free a picture previously allocated by avpicture_alloc().
// * The data buffer used by the AVPicture is freed, but the AVPicture structure
// * itself is not.
// *
// * @param picture the AVPicture to be freed
// */
//void avpicture_free(AVPicture *picture);

///**
// * Fill in the AVPicture fields.
// * The fields of the given AVPicture are filled in by using the 'ptr' address
// * which points to the image data buffer. Depending on the specified picture
// * format, one or multiple image data pointers and line sizes will be set.
// * If a planar format is specified, several pointers will be set pointing to
// * the different picture planes and the line sizes of the different planes
// * will be stored in the lines_sizes array.
// * Call with ptr == NULL to get the required size for the ptr buffer.
// *
// * To allocate the buffer and fill in the AVPicture fields in one call,
// * use avpicture_alloc().
// *
// * @param picture AVPicture whose fields are to be filled in
// * @param ptr Buffer which will contain or contains the actual image data
// * @param pix_fmt The format in which the picture data is stored.
// * @param width the width of the image in pixels
// * @param height the height of the image in pixels
// * @return size of the image data in bytes
// */
//int avpicture_fill(AVPicture *picture, uint8_t *ptr,
//                   enum PixelFormat pix_fmt, int width, int height);

///**
// * Copy pixel data from an AVPicture into a buffer.
// * The data is stored compactly, without any gaps for alignment or padding
// * which may be applied by avpicture_fill().
// *
// * @see avpicture_get_size()
// *
// * @param[in] src AVPicture containing image data
// * @param[in] pix_fmt The format in which the picture data is stored.
// * @param[in] width the width of the image in pixels.
// * @param[in] height the height of the image in pixels.
// * @param[out] dest A buffer into which picture data will be copied.
// * @param[in] dest_size The size of 'dest'.
// * @return The number of bytes written to dest, or a negative value (error code) on error.
// */
//int avpicture_layout(const AVPicture* src, enum PixelFormat pix_fmt, int width, int height,
//                     unsigned char *dest, int dest_size);

///**
// * Calculate the size in bytes that a picture of the given width and height
// * would occupy if stored in the given picture format.
// * Note that this returns the size of a compact representation as generated
// * by avpicture_layout(), which can be smaller than the size required for e.g.
// * avpicture_fill().
// *
// * @param pix_fmt the given picture format
// * @param width the width of the image
// * @param height the height of the image
// * @return Image data size in bytes or -1 on error (e.g. too large dimensions).
// */
//int avpicture_get_size(enum PixelFormat pix_fmt, int width, int height);
//void avcodec_get_chroma_sub_sample(enum PixelFormat pix_fmt, int *h_shift, int *v_shift);

///**
// * Get the name of a codec.
// * @return  a static string identifying the codec; never NULL
// */
//const char *avcodec_get_name(enum CodecID id);

//void avcodec_set_dimensions(AVCodecContext *s, int width, int height);

///**
// * Return a value representing the fourCC code associated to the
// * pixel format pix_fmt, or 0 if no associated fourCC code can be
// * found.
// */
//unsigned int avcodec_pix_fmt_to_codec_tag(enum PixelFormat pix_fmt);

///**
// * Put a string representing the codec tag codec_tag in buf.
// *
// * @param buf_size size in bytes of buf
// * @return the length of the string that would have been generated if
// * enough space had been available, excluding the trailing null
// */
//size_t av_get_codec_tag_string(char *buf, size_t buf_size, unsigned int codec_tag);

//#define FF_LOSS_RESOLUTION  0x0001 /**< loss due to resolution change */
//#define FF_LOSS_DEPTH       0x0002 /**< loss due to color depth change */
//#define FF_LOSS_COLORSPACE  0x0004 /**< loss due to color space conversion */
//#define FF_LOSS_ALPHA       0x0008 /**< loss of alpha bits */
//#define FF_LOSS_COLORQUANT  0x0010 /**< loss due to color quantization */
//#define FF_LOSS_CHROMA      0x0020 /**< loss of chroma (e.g. RGB to gray conversion) */

///**
// * Compute what kind of losses will occur when converting from one specific
// * pixel format to another.
// * When converting from one pixel format to another, information loss may occur.
// * For example, when converting from RGB24 to GRAY, the color information will
// * be lost. Similarly, other losses occur when converting from some formats to
// * other formats. These losses can involve loss of chroma, but also loss of
// * resolution, loss of color depth, loss due to the color space conversion, loss
// * of the alpha bits or loss due to color quantization.
// * avcodec_get_fix_fmt_loss() informs you about the various types of losses
// * which will occur when converting from one pixel format to another.
// *
// * @param[in] dst_pix_fmt destination pixel format
// * @param[in] src_pix_fmt source pixel format
// * @param[in] has_alpha Whether the source pixel format alpha channel is used.
// * @return Combination of flags informing you what kind of losses will occur
// * (maximum loss for an invalid dst_pix_fmt).
// */
//int avcodec_get_pix_fmt_loss(enum PixelFormat dst_pix_fmt, enum PixelFormat src_pix_fmt,
//                             int has_alpha);

///**
// * Find the best pixel format to convert to given a certain source pixel
// * format.  When converting from one pixel format to another, information loss
// * may occur.  For example, when converting from RGB24 to GRAY, the color
// * information will be lost. Similarly, other losses occur when converting from
// * some formats to other formats. avcodec_find_best_pix_fmt() searches which of
// * the given pixel formats should be used to suffer the least amount of loss.
// * The pixel formats from which it chooses one, are determined by the
// * pix_fmt_mask parameter.
// *
// * Note, only the first 64 pixel formats will fit in pix_fmt_mask.
// *
// * @code
// * src_pix_fmt = PIX_FMT_YUV420P;
// * pix_fmt_mask = (1 << PIX_FMT_YUV422P) | (1 << PIX_FMT_RGB24);
// * dst_pix_fmt = avcodec_find_best_pix_fmt(pix_fmt_mask, src_pix_fmt, alpha, &loss);
// * @endcode
// *
// * @param[in] pix_fmt_mask bitmask determining which pixel format to choose from
// * @param[in] src_pix_fmt source pixel format
// * @param[in] has_alpha Whether the source pixel format alpha channel is used.
// * @param[out] loss_ptr Combination of flags informing you what kind of losses will occur.
// * @return The best pixel format to convert to or -1 if none was found.
// */
//enum PixelFormat avcodec_find_best_pix_fmt(int64_t pix_fmt_mask, enum PixelFormat src_pix_fmt,
//                              int has_alpha, int *loss_ptr);

///**
// * Find the best pixel format to convert to given a certain source pixel
// * format and a selection of two destination pixel formats. When converting from
// * one pixel format to another, information loss may occur.  For example, when converting
// * from RGB24 to GRAY, the color information will be lost. Similarly, other losses occur when
// * converting from some formats to other formats. avcodec_find_best_pix_fmt2() selects which of
// * the given pixel formats should be used to suffer the least amount of loss.
// *
// * If one of the destination formats is PIX_FMT_NONE the other pixel format (if valid) will be
// * returned.
// *
// * @code
// * src_pix_fmt = PIX_FMT_YUV420P;
// * dst_pix_fmt1= PIX_FMT_RGB24;
// * dst_pix_fmt2= PIX_FMT_GRAY8;
// * dst_pix_fmt3= PIX_FMT_RGB8;
// * loss= FF_LOSS_CHROMA; // don't care about chroma loss, so chroma loss will be ignored.
// * dst_pix_fmt = avcodec_find_best_pix_fmt2(dst_pix_fmt1, dst_pix_fmt2, src_pix_fmt, alpha, &loss);
// * dst_pix_fmt = avcodec_find_best_pix_fmt2(dst_pix_fmt, dst_pix_fmt3, src_pix_fmt, alpha, &loss);
// * @endcode
// *
// * @param[in] dst_pix_fmt1 One of the two destination pixel formats to choose from
// * @param[in] dst_pix_fmt2 The other of the two destination pixel formats to choose from
// * @param[in] src_pix_fmt Source pixel format
// * @param[in] has_alpha Whether the source pixel format alpha channel is used.
// * @param[in, out] loss_ptr Combination of loss flags. In: selects which of the losses to ignore, i.e.
// *                               NULL or value of zero means we care about all losses. Out: the loss
// *                               that occurs when converting from src to selected dst pixel format.
// * @return The best pixel format to convert to or -1 if none was found.
// */
//enum PixelFormat avcodec_find_best_pix_fmt2(enum PixelFormat dst_pix_fmt1, enum PixelFormat dst_pix_fmt2,
//                                            enum PixelFormat src_pix_fmt, int has_alpha, int *loss_ptr);


///* deinterlace a picture */
///* deinterlace - if not supported return -1 */
//int avpicture_deinterlace(AVPicture *dst, const AVPicture *src,
//                          enum PixelFormat pix_fmt, int width, int height);

///* external high level API */

///**
// * If c is NULL, returns the first registered codec,
// * if c is non-NULL, returns the next registered codec after c,
// * or NULL if c is the last one.
// */
//AVCodec *av_codec_next(AVCodec *c);

///**
// * Return the LIBAVCODEC_VERSION_INT constant.
// */
//unsigned avcodec_version(void);

///**
// * Return the libavcodec build-time configuration.
// */
//const char *avcodec_configuration(void);

///**
// * Return the libavcodec license.
// */
//const char *avcodec_license(void);

///**
// * Register the codec codec and initialize libavcodec.
// *
// * @warning either this function or avcodec_register_all() must be called
// * before any other libavcodec functions.
// *
// * @see avcodec_register_all()
// */
//void avcodec_register(AVCodec *codec);

///**
// * Find a registered encoder with a matching codec ID.
// *
// * @param id CodecID of the requested encoder
// * @return An encoder if one was found, NULL otherwise.
// */
//AVCodec *avcodec_find_encoder(enum CodecID id);

///**
// * Find a registered encoder with the specified name.
// *
// * @param name name of the requested encoder
// * @return An encoder if one was found, NULL otherwise.
// */
//AVCodec *avcodec_find_encoder_by_name(const char *name);

///**
// * Find a registered decoder with a matching codec ID.
// *
// * @param id CodecID of the requested decoder
// * @return A decoder if one was found, NULL otherwise.
// */
//AVCodec *avcodec_find_decoder(enum CodecID id);

///**
// * Find a registered decoder with the specified name.
// *
// * @param name name of the requested decoder
// * @return A decoder if one was found, NULL otherwise.
// */
//AVCodec *avcodec_find_decoder_by_name(const char *name);
//void avcodec_string(char *buf, int buf_size, AVCodecContext *enc, int encode);

///**
// * Return a name for the specified profile, if available.
// *
// * @param codec the codec that is searched for the given profile
// * @param profile the profile value for which a name is requested
// * @return A name for the profile if found, NULL otherwise.
// */
//const char *av_get_profile_name(const AVCodec *codec, int profile);

//#if FF_API_ALLOC_CONTEXT
///**
// * Set the fields of the given AVCodecContext to default values.
// *
// * @param s The AVCodecContext of which the fields should be set to default values.
// * @deprecated use avcodec_get_context_defaults3
// */
//attribute_deprecated
//void avcodec_get_context_defaults(AVCodecContext *s);

///** THIS FUNCTION IS NOT YET PART OF THE PUBLIC API!
// *  we WILL change its arguments and name a few times! */
//attribute_deprecated
//void avcodec_get_context_defaults2(AVCodecContext *s, enum AVMediaType);
//#endif

///**
// * Set the fields of the given AVCodecContext to default values corresponding
// * to the given codec (defaults may be codec-dependent).
// *
// * Do not call this function if a non-NULL codec has been passed
// * to avcodec_alloc_context3() that allocated this AVCodecContext.
// * If codec is non-NULL, it is illegal to call avcodec_open2() with a
// * different codec on this AVCodecContext.
// */
//int avcodec_get_context_defaults3(AVCodecContext *s, AVCodec *codec);

//#if FF_API_ALLOC_CONTEXT
///**
// * Allocate an AVCodecContext and set its fields to default values.  The
// * resulting struct can be deallocated by simply calling av_free().
// *
// * @return An AVCodecContext filled with default values or NULL on failure.
// * @see avcodec_get_context_defaults
// *
// * @deprecated use avcodec_alloc_context3()
// */
//attribute_deprecated
//AVCodecContext *avcodec_alloc_context(void);

///** THIS FUNCTION IS NOT YET PART OF THE PUBLIC API!
// *  we WILL change its arguments and name a few times! */
//attribute_deprecated
//AVCodecContext *avcodec_alloc_context2(enum AVMediaType);
//#endif

///**
// * Allocate an AVCodecContext and set its fields to default values.  The
// * resulting struct can be deallocated by calling avcodec_close() on it followed
// * by av_free().
// *
// * @param codec if non-NULL, allocate private data and initialize defaults
// *              for the given codec. It is illegal to then call avcodec_open2()
// *              with a different codec.
// *              If NULL, then the codec-specific defaults won't be initialized,
// *              which may result in suboptimal default settings (this is
// *              important mainly for encoders, e.g. libx264).
// *
// * @return An AVCodecContext filled with default values or NULL on failure.
// * @see avcodec_get_context_defaults
// */
//AVCodecContext *avcodec_alloc_context3(AVCodec *codec);

///**
// * Copy the settings of the source AVCodecContext into the destination
// * AVCodecContext. The resulting destination codec context will be
// * unopened, i.e. you are required to call avcodec_open2() before you
// * can use this AVCodecContext to decode/encode video/audio data.
// *
// * @param dest target codec context, should be initialized with
// *             avcodec_alloc_context3(), but otherwise uninitialized
// * @param src source codec context
// * @return AVERROR() on error (e.g. memory allocation error), 0 on success
// */
//int avcodec_copy_context(AVCodecContext *dest, const AVCodecContext *src);

///**
// * Allocate an AVFrame and set its fields to default values.  The resulting
// * struct can be deallocated by simply calling av_free().
// *
// * @return An AVFrame filled with default values or NULL on failure.
// * @see avcodec_get_frame_defaults
// */
//AVFrame *avcodec_alloc_frame(void);

//int avcodec_default_get_buffer(AVCodecContext *s, AVFrame *pic);
//void avcodec_default_release_buffer(AVCodecContext *s, AVFrame *pic);
//int avcodec_default_reget_buffer(AVCodecContext *s, AVFrame *pic);

///**
// * Return the amount of padding in pixels which the get_buffer callback must
// * provide around the edge of the image for codecs which do not have the
// * CODEC_FLAG_EMU_EDGE flag.
// *
// * @return Required padding in pixels.
// */
//unsigned avcodec_get_edge_width(void);
///**
// * Modify width and height values so that they will result in a memory
// * buffer that is acceptable for the codec if you do not use any horizontal
// * padding.
// *
// * May only be used if a codec with CODEC_CAP_DR1 has been opened.
// * If CODEC_FLAG_EMU_EDGE is not set, the dimensions must have been increased
// * according to avcodec_get_edge_width() before.
// */
//void avcodec_align_dimensions(AVCodecContext *s, int *width, int *height);
///**
// * Modify width and height values so that they will result in a memory
// * buffer that is acceptable for the codec if you also ensure that all
// * line sizes are a multiple of the respective linesize_align[i].
// *
// * May only be used if a codec with CODEC_CAP_DR1 has been opened.
// * If CODEC_FLAG_EMU_EDGE is not set, the dimensions must have been increased
// * according to avcodec_get_edge_width() before.
// */
//void avcodec_align_dimensions2(AVCodecContext *s, int *width, int *height,
//                               int linesize_align[AV_NUM_DATA_POINTERS]);

//enum PixelFormat avcodec_default_get_format(struct AVCodecContext *s, const enum PixelFormat * fmt);

//int avcodec_default_execute(AVCodecContext *c, int (*func)(AVCodecContext *c2, void *arg2),void *arg, int *ret, int count, int size);
//int avcodec_default_execute2(AVCodecContext *c, int (*func)(AVCodecContext *c2, void *arg2, int, int),void *arg, int *ret, int count);
////FIXME func typedef

//#if FF_API_AVCODEC_OPEN
///**
// * Initialize the AVCodecContext to use the given AVCodec. Prior to using this
// * function the context has to be allocated.
// *
// * The functions avcodec_find_decoder_by_name(), avcodec_find_encoder_by_name(),
// * avcodec_find_decoder() and avcodec_find_encoder() provide an easy way for
// * retrieving a codec.
// *
// * @warning This function is not thread safe!
// *
// * @code
// * avcodec_register_all();
// * codec = avcodec_find_decoder(CODEC_ID_H264);
// * if (!codec)
// *     exit(1);
// *
// * context = avcodec_alloc_context3(codec);
// *
// * if (avcodec_open(context, codec) < 0)
// *     exit(1);
// * @endcode
// *
// * @param avctx The context which will be set up to use the given codec.
// * @param codec The codec to use within the context.
// * @return zero on success, a negative value on error
// * @see avcodec_alloc_context3, avcodec_find_decoder, avcodec_find_encoder, avcodec_close
// *
// * @deprecated use avcodec_open2
// */
//attribute_deprecated
//int avcodec_open(AVCodecContext *avctx, AVCodec *codec);
//#endif

///**
// * Initialize the AVCodecContext to use the given AVCodec. Prior to using this
// * function the context has to be allocated with avcodec_alloc_context3().
// *
// * The functions avcodec_find_decoder_by_name(), avcodec_find_encoder_by_name(),
// * avcodec_find_decoder() and avcodec_find_encoder() provide an easy way for
// * retrieving a codec.
// *
// * @warning This function is not thread safe!
// *
// * @code
// * avcodec_register_all();
// * av_dict_set(&opts, "b", "2.5M", 0);
// * codec = avcodec_find_decoder(CODEC_ID_H264);
// * if (!codec)
// *     exit(1);
// *
// * context = avcodec_alloc_context3(codec);
// *
// * if (avcodec_open2(context, codec, opts) < 0)
// *     exit(1);
// * @endcode
// *
// * @param avctx The context to initialize.
// * @param codec The codec to open this context for. If a non-NULL codec has been
// *              previously passed to avcodec_alloc_context3() or
// *              avcodec_get_context_defaults3() for this context, then this
// *              parameter MUST be either NULL or equal to the previously passed
// *              codec.
// * @param options A dictionary filled with AVCodecContext and codec-private options.
// *                On return this object will be filled with options that were not found.
// *
// * @return zero on success, a negative value on error
// * @see avcodec_alloc_context3(), avcodec_find_decoder(), avcodec_find_encoder(),
// *      av_dict_set(), av_opt_find().
// */
//int avcodec_open2(AVCodecContext *avctx, AVCodec *codec, AVDictionary **options);

//#if FF_API_OLD_DECODE_AUDIO
///**
// * Wrapper function which calls avcodec_decode_audio4.
// *
// * @deprecated Use avcodec_decode_audio4 instead.
// *
// * Decode the audio frame of size avpkt->size from avpkt->data into samples.
// * Some decoders may support multiple frames in a single AVPacket, such
// * decoders would then just decode the first frame. In this case,
// * avcodec_decode_audio3 has to be called again with an AVPacket that contains
// * the remaining data in order to decode the second frame etc.
// * If no frame
// * could be outputted, frame_size_ptr is zero. Otherwise, it is the
// * decompressed frame size in bytes.
// *
// * @warning You must set frame_size_ptr to the allocated size of the
// * output buffer before calling avcodec_decode_audio3().
// *
// * @warning The input buffer must be FF_INPUT_BUFFER_PADDING_SIZE larger than
// * the actual read bytes because some optimized bitstream readers read 32 or 64
// * bits at once and could read over the end.
// *
// * @warning The end of the input buffer avpkt->data should be set to 0 to ensure that
// * no overreading happens for damaged MPEG streams.
// *
// * @warning You must not provide a custom get_buffer() when using
// * avcodec_decode_audio3().  Doing so will override it with
// * avcodec_default_get_buffer.  Use avcodec_decode_audio4() instead,
// * which does allow the application to provide a custom get_buffer().
// *
// * @note You might have to align the input buffer avpkt->data and output buffer
// * samples. The alignment requirements depend on the CPU: On some CPUs it isn't
// * necessary at all, on others it won't work at all if not aligned and on others
// * it will work but it will have an impact on performance.
// *
// * In practice, avpkt->data should have 4 byte alignment at minimum and
// * samples should be 16 byte aligned unless the CPU doesn't need it
// * (AltiVec and SSE do).
// *
// * @note Codecs which have the CODEC_CAP_DELAY capability set have a delay
// * between input and output, these need to be fed with avpkt->data=NULL,
// * avpkt->size=0 at the end to return the remaining frames.
// *
// * @param avctx the codec context
// * @param[out] samples the output buffer, sample type in avctx->sample_fmt
// *                     If the sample format is planar, each channel plane will
// *                     be the same size, with no padding between channels.
// * @param[in,out] frame_size_ptr the output buffer size in bytes
// * @param[in] avpkt The input AVPacket containing the input buffer.
// *            You can create such packet with av_init_packet() and by then setting
// *            data and size, some decoders might in addition need other fields.
// *            All decoders are designed to use the least fields possible though.
// * @return On error a negative value is returned, otherwise the number of bytes
// * used or zero if no frame data was decompressed (used) from the input AVPacket.
// */
//attribute_deprecated int avcodec_decode_audio3(AVCodecContext *avctx, int16_t *samples,
//                         int *frame_size_ptr,
//                         AVPacket *avpkt);
//#endif

///**
// * Decode the audio frame of size avpkt->size from avpkt->data into frame.
// *
// * Some decoders may support multiple frames in a single AVPacket. Such
// * decoders would then just decode the first frame. In this case,
// * avcodec_decode_audio4 has to be called again with an AVPacket containing
// * the remaining data in order to decode the second frame, etc...
// * Even if no frames are returned, the packet needs to be fed to the decoder
// * with remaining data until it is completely consumed or an error occurs.
// *
// * @warning The input buffer, avpkt->data must be FF_INPUT_BUFFER_PADDING_SIZE
// *          larger than the actual read bytes because some optimized bitstream
// *          readers read 32 or 64 bits at once and could read over the end.
// *
// * @note You might have to align the input buffer. The alignment requirements
// *       depend on the CPU and the decoder.
// *
// * @param      avctx the codec context
// * @param[out] frame The AVFrame in which to store decoded audio samples.
// *                   Decoders request a buffer of a particular size by setting
// *                   AVFrame.nb_samples prior to calling get_buffer(). The
// *                   decoder may, however, only utilize part of the buffer by
// *                   setting AVFrame.nb_samples to a smaller value in the
// *                   output frame.
// * @param[out] got_frame_ptr Zero if no frame could be decoded, otherwise it is
// *                           non-zero.
// * @param[in]  avpkt The input AVPacket containing the input buffer.
// *                   At least avpkt->data and avpkt->size should be set. Some
// *                   decoders might also require additional fields to be set.
// * @return A negative error code is returned if an error occurred during
// *         decoding, otherwise the number of bytes consumed from the input
// *         AVPacket is returned.
// */
//int avcodec_decode_audio4(AVCodecContext *avctx, AVFrame *frame,
//                          int *got_frame_ptr, AVPacket *avpkt);

///**
// * Decode the video frame of size avpkt->size from avpkt->data into picture.
// * Some decoders may support multiple frames in a single AVPacket, such
// * decoders would then just decode the first frame.
// *
// * @warning The input buffer must be FF_INPUT_BUFFER_PADDING_SIZE larger than
// * the actual read bytes because some optimized bitstream readers read 32 or 64
// * bits at once and could read over the end.
// *
// * @warning The end of the input buffer buf should be set to 0 to ensure that
// * no overreading happens for damaged MPEG streams.
// *
// * @note You might have to align the input buffer avpkt->data.
// * The alignment requirements depend on the CPU: on some CPUs it isn't
// * necessary at all, on others it won't work at all if not aligned and on others
// * it will work but it will have an impact on performance.
// *
// * In practice, avpkt->data should have 4 byte alignment at minimum.
// *
// * @note Codecs which have the CODEC_CAP_DELAY capability set have a delay
// * between input and output, these need to be fed with avpkt->data=NULL,
// * avpkt->size=0 at the end to return the remaining frames.
// *
// * @param avctx the codec context
// * @param[out] picture The AVFrame in which the decoded video frame will be stored.
// *             Use avcodec_alloc_frame to get an AVFrame, the codec will
// *             allocate memory for the actual bitmap.
// *             with default get/release_buffer(), the decoder frees/reuses the bitmap as it sees fit.
// *             with overridden get/release_buffer() (needs CODEC_CAP_DR1) the user decides into what buffer the decoder
// *                   decodes and the decoder tells the user once it does not need the data anymore,
// *                   the user app can at this point free/reuse/keep the memory as it sees fit.
// *
// * @param[in] avpkt The input AVpacket containing the input buffer.
// *            You can create such packet with av_init_packet() and by then setting
// *            data and size, some decoders might in addition need other fields like
// *            flags&AV_PKT_FLAG_KEY. All decoders are designed to use the least
// *            fields possible.
// * @param[in,out] got_picture_ptr Zero if no frame could be decompressed, otherwise, it is nonzero.
// * @return On error a negative value is returned, otherwise the number of bytes
// * used or zero if no frame could be decompressed.
// */
//int avcodec_decode_video2(AVCodecContext *avctx, AVFrame *picture,
//                         int *got_picture_ptr,
//                         const AVPacket *avpkt);

///**
// * Decode a subtitle message.
// * Return a negative value on error, otherwise return the number of bytes used.
// * If no subtitle could be decompressed, got_sub_ptr is zero.
// * Otherwise, the subtitle is stored in *sub.
// * Note that CODEC_CAP_DR1 is not available for subtitle codecs. This is for
// * simplicity, because the performance difference is expect to be negligible
// * and reusing a get_buffer written for video codecs would probably perform badly
// * due to a potentially very different allocation pattern.
// *
// * @param avctx the codec context
// * @param[out] sub The AVSubtitle in which the decoded subtitle will be stored, must be
//                   freed with avsubtitle_free if *got_sub_ptr is set.
// * @param[in,out] got_sub_ptr Zero if no subtitle could be decompressed, otherwise, it is nonzero.
// * @param[in] avpkt The input AVPacket containing the input buffer.
// */
//int avcodec_decode_subtitle2(AVCodecContext *avctx, AVSubtitle *sub,
//                            int *got_sub_ptr,
//                            AVPacket *avpkt);

///**
// * Free all allocated data in the given subtitle struct.
// *
// * @param sub AVSubtitle to free.
// */
//void avsubtitle_free(AVSubtitle *sub);

//#if FF_API_OLD_ENCODE_AUDIO
///**
// * Encode an audio frame from samples into buf.
// *
// * @deprecated Use avcodec_encode_audio2 instead.
// *
// * @note The output buffer should be at least FF_MIN_BUFFER_SIZE bytes large.
// * However, for codecs with avctx->frame_size equal to 0 (e.g. PCM) the user
// * will know how much space is needed because it depends on the value passed
// * in buf_size as described below. In that case a lower value can be used.
// *
// * @param avctx the codec context
// * @param[out] buf the output buffer
// * @param[in] buf_size the output buffer size
// * @param[in] samples the input buffer containing the samples
// * The number of samples read from this buffer is frame_size*channels,
// * both of which are defined in avctx.
// * For codecs which have avctx->frame_size equal to 0 (e.g. PCM) the number of
// * samples read from samples is equal to:
// * buf_size * 8 / (avctx->channels * av_get_bits_per_sample(avctx->codec_id))
// * This also implies that av_get_bits_per_sample() must not return 0 for these
// * codecs.
// * @return On error a negative value is returned, on success zero or the number
// * of bytes used to encode the data read from the input buffer.
// */
//int attribute_deprecated avcodec_encode_audio(AVCodecContext *avctx,
//                                              uint8_t *buf, int buf_size,
//                                              const short *samples);
//#endif

///**
// * Encode a frame of audio.
// *
// * Takes input samples from frame and writes the next output packet, if
// * available, to avpkt. The output packet does not necessarily contain data for
// * the most recent frame, as encoders can delay, split, and combine input frames
// * internally as needed.
// *
// * @param avctx     codec context
// * @param avpkt     output AVPacket.
// *                  The user can supply an output buffer by setting
// *                  avpkt->data and avpkt->size prior to calling the
// *                  function, but if the size of the user-provided data is not
// *                  large enough, encoding will fail. All other AVPacket fields
// *                  will be reset by the encoder using av_init_packet(). If
// *                  avpkt->data is NULL, the encoder will allocate it.
// *                  The encoder will set avpkt->size to the size of the
// *                  output packet.
// *
// *                  If this function fails or produces no output, avpkt will be
// *                  freed using av_free_packet() (i.e. avpkt->destruct will be
// *                  called to free the user supplied buffer).
// * @param[in] frame AVFrame containing the raw audio data to be encoded.
// *                  May be NULL when flushing an encoder that has the
// *                  CODEC_CAP_DELAY capability set.
// *                  There are 2 codec capabilities that affect the allowed
// *                  values of frame->nb_samples.
// *                  If CODEC_CAP_SMALL_LAST_FRAME is set, then only the final
// *                  frame may be smaller than avctx->frame_size, and all other
// *                  frames must be equal to avctx->frame_size.
// *                  If CODEC_CAP_VARIABLE_FRAME_SIZE is set, then each frame
// *                  can have any number of samples.
// *                  If neither is set, frame->nb_samples must be equal to
// *                  avctx->frame_size for all frames.
// * @param[out] got_packet_ptr This field is set to 1 by libavcodec if the
// *                            output packet is non-empty, and to 0 if it is
// *                            empty. If the function returns an error, the
// *                            packet can be assumed to be invalid, and the
// *                            value of got_packet_ptr is undefined and should
// *                            not be used.
// * @return          0 on success, negative error code on failure
// */
//int avcodec_encode_audio2(AVCodecContext *avctx, AVPacket *avpkt,
//                          const AVFrame *frame, int *got_packet_ptr);

///**
// * Fill audio frame data and linesize.
// * AVFrame extended_data channel pointers are allocated if necessary for
// * planar audio.
// *
// * @param frame       the AVFrame
// *                    frame->nb_samples must be set prior to calling the
// *                    function. This function fills in frame->data,
// *                    frame->extended_data, frame->linesize[0].
// * @param nb_channels channel count
// * @param sample_fmt  sample format
// * @param buf         buffer to use for frame data
// * @param buf_size    size of buffer
// * @param align       plane size sample alignment
// * @return            0 on success, negative error code on failure
// */
//int avcodec_fill_audio_frame(AVFrame *frame, int nb_channels,
//                             enum AVSampleFormat sample_fmt, const uint8_t *buf,
//                             int buf_size, int align);

//#if FF_API_OLD_ENCODE_VIDEO
///**
// * @deprecated use avcodec_encode_video2() instead.
// *
// * Encode a video frame from pict into buf.
// * The input picture should be
// * stored using a specific format, namely avctx.pix_fmt.
// *
// * @param avctx the codec context
// * @param[out] buf the output buffer for the bitstream of encoded frame
// * @param[in] buf_size the size of the output buffer in bytes
// * @param[in] pict the input picture to encode
// * @return On error a negative value is returned, on success zero or the number
// * of bytes used from the output buffer.
// */
//attribute_deprecated
//int avcodec_encode_video(AVCodecContext *avctx, uint8_t *buf, int buf_size,
//                         const AVFrame *pict);
//#endif

///**
// * Encode a frame of video.
// *
// * Takes input raw video data from frame and writes the next output packet, if
// * available, to avpkt. The output packet does not necessarily contain data for
// * the most recent frame, as encoders can delay and reorder input frames
// * internally as needed.
// *
// * @param avctx     codec context
// * @param avpkt     output AVPacket.
// *                  The user can supply an output buffer by setting
// *                  avpkt->data and avpkt->size prior to calling the
// *                  function, but if the size of the user-provided data is not
// *                  large enough, encoding will fail. All other AVPacket fields
// *                  will be reset by the encoder using av_init_packet(). If
// *                  avpkt->data is NULL, the encoder will allocate it.
// *                  The encoder will set avpkt->size to the size of the
// *                  output packet. The returned data (if any) belongs to the
// *                  caller, he is responsible for freeing it.
// *
// *                  If this function fails or produces no output, avpkt will be
// *                  freed using av_free_packet() (i.e. avpkt->destruct will be
// *                  called to free the user supplied buffer).
// * @param[in] frame AVFrame containing the raw video data to be encoded.
// *                  May be NULL when flushing an encoder that has the
// *                  CODEC_CAP_DELAY capability set.
// * @param[out] got_packet_ptr This field is set to 1 by libavcodec if the
// *                            output packet is non-empty, and to 0 if it is
// *                            empty. If the function returns an error, the
// *                            packet can be assumed to be invalid, and the
// *                            value of got_packet_ptr is undefined and should
// *                            not be used.
// * @return          0 on success, negative error code on failure
// */
//int avcodec_encode_video2(AVCodecContext *avctx, AVPacket *avpkt,
//                          const AVFrame *frame, int *got_packet_ptr);

//int avcodec_encode_subtitle(AVCodecContext *avctx, uint8_t *buf, int buf_size,
//                            const AVSubtitle *sub);

///**
// * Close a given AVCodecContext and free all the data associated with it
// * (but not the AVCodecContext itself).
// *
// * Calling this function on an AVCodecContext that hasn't been opened will free
// * the codec-specific data allocated in avcodec_alloc_context3() /
// * avcodec_get_context_defaults3() with a non-NULL codec. Subsequent calls will
// * do nothing.
// */
//int avcodec_close(AVCodecContext *avctx);

///**
// * Register all the codecs, parsers and bitstream filters which were enabled at
// * configuration time. If you do not call this function you can select exactly
// * which formats you want to support, by using the individual registration
// * functions.
// *
// * @see avcodec_register
// * @see av_register_codec_parser
// * @see av_register_bitstream_filter
// */
//void avcodec_register_all(void);

///**
// * Flush buffers, should be called when seeking or when switching to a different stream.
// */
//void avcodec_flush_buffers(AVCodecContext *avctx);

//void avcodec_default_free_buffers(AVCodecContext *s);

///* misc useful functions */

///**
// * Return codec bits per sample.
// *
// * @param[in] codec_id the codec
// * @return Number of bits per sample or zero if unknown for the given codec.
// */
//int av_get_bits_per_sample(enum CodecID codec_id);

///**
// * Return the PCM codec associated with a sample format.
// * @param be  endianness, 0 for little, 1 for big,
// *            -1 (or anything else) for native
// * @return  CODEC_ID_PCM_* or CODEC_ID_NONE
// */
//enum CodecID av_get_pcm_codec(enum AVSampleFormat fmt, int be);

///**
// * Return codec bits per sample.
// * Only return non-zero if the bits per sample is exactly correct, not an
// * approximation.
// *
// * @param[in] codec_id the codec
// * @return Number of bits per sample or zero if unknown for the given codec.
// */
//int av_get_exact_bits_per_sample(enum CodecID codec_id);

///**
// * Return audio frame duration.
// *
// * @param avctx        codec context
// * @param frame_bytes  size of the frame, or 0 if unknown
// * @return             frame duration, in samples, if known. 0 if not able to
// *                     determine.
// */
//int av_get_audio_frame_duration(AVCodecContext *avctx, int frame_bytes);

///* frame parsing */
//typedef struct AVCodecParserContext {
//    void *priv_data;
//    struct AVCodecParser *parser;
//    int64_t frame_offset; /* offset of the current frame */
//    int64_t cur_offset; /* current offset
//                           (incremented by each av_parser_parse()) */
//    int64_t next_frame_offset; /* offset of the next frame */
//    /* video info */
//    int pict_type; /* XXX: Put it back in AVCodecContext. */
//    /**
//     * This field is used for proper frame duration computation in lavf.
//     * It signals, how much longer the frame duration of the current frame
//     * is compared to normal frame duration.
//     *
//     * frame_duration = (1 + repeat_pict) * time_base
//     *
//     * It is used by codecs like H.264 to display telecined material.
//     */
//    int repeat_pict; /* XXX: Put it back in AVCodecContext. */
//    int64_t pts;     /* pts of the current frame */
//    int64_t dts;     /* dts of the current frame */

//    /* private data */
//    int64_t last_pts;
//    int64_t last_dts;
//    int fetch_timestamp;

//#define AV_PARSER_PTS_NB 4
//    int cur_frame_start_index;
//    int64_t cur_frame_offset[AV_PARSER_PTS_NB];
//    int64_t cur_frame_pts[AV_PARSER_PTS_NB];
//    int64_t cur_frame_dts[AV_PARSER_PTS_NB];

//    int flags;
//#define PARSER_FLAG_COMPLETE_FRAMES           0x0001
//#define PARSER_FLAG_ONCE                      0x0002
///// Set if the parser has a valid file offset
//#define PARSER_FLAG_FETCHED_OFFSET            0x0004

//    int64_t offset;      ///< byte offset from starting packet start
//    int64_t cur_frame_end[AV_PARSER_PTS_NB];

//    /**
//     * Set by parser to 1 for key frames and 0 for non-key frames.
//     * It is initialized to -1, so if the parser doesn't set this flag,
//     * old-style fallback using AV_PICTURE_TYPE_I picture type as key frames
//     * will be used.
//     */
//    int key_frame;

//    /**
//     * Time difference in stream time base units from the pts of this
//     * packet to the point at which the output from the decoder has converged
//     * independent from the availability of previous frames. That is, the
//     * frames are virtually identical no matter if decoding started from
//     * the very first frame or from this keyframe.
//     * Is AV_NOPTS_VALUE if unknown.
//     * This field is not the display duration of the current frame.
//     * This field has no meaning if the packet does not have AV_PKT_FLAG_KEY
//     * set.
//     *
//     * The purpose of this field is to allow seeking in streams that have no
//     * keyframes in the conventional sense. It corresponds to the
//     * recovery point SEI in H.264 and match_time_delta in NUT. It is also
//     * essential for some types of subtitle streams to ensure that all
//     * subtitles are correctly displayed after seeking.
//     */
//    int64_t convergence_duration;

//    // Timestamp generation support:
//    /**
//     * Synchronization point for start of timestamp generation.
//     *
//     * Set to >0 for sync point, 0 for no sync point and <0 for undefined
//     * (default).
//     *
//     * For example, this corresponds to presence of H.264 buffering period
//     * SEI message.
//     */
//    int dts_sync_point;

//    /**
//     * Offset of the current timestamp against last timestamp sync point in
//     * units of AVCodecContext.time_base.
//     *
//     * Set to INT_MIN when dts_sync_point unused. Otherwise, it must
//     * contain a valid timestamp offset.
//     *
//     * Note that the timestamp of sync point has usually a nonzero
//     * dts_ref_dts_delta, which refers to the previous sync point. Offset of
//     * the next frame after timestamp sync point will be usually 1.
//     *
//     * For example, this corresponds to H.264 cpb_removal_delay.
//     */
//    int dts_ref_dts_delta;

//    /**
//     * Presentation delay of current frame in units of AVCodecContext.time_base.
//     *
//     * Set to INT_MIN when dts_sync_point unused. Otherwise, it must
//     * contain valid non-negative timestamp delta (presentation time of a frame
//     * must not lie in the past).
//     *
//     * This delay represents the difference between decoding and presentation
//     * time of the frame.
//     *
//     * For example, this corresponds to H.264 dpb_output_delay.
//     */
//    int pts_dts_delta;

//    /**
//     * Position of the packet in file.
//     *
//     * Analogous to cur_frame_pts/dts
//     */
//    int64_t cur_frame_pos[AV_PARSER_PTS_NB];

//    /**
//     * Byte position of currently parsed frame in stream.
//     */
//    int64_t pos;

//    /**
//     * Previous frame byte position.
//     */
//    int64_t last_pos;

//    /**
//     * Duration of the current frame.
//     * For audio, this is in units of 1 / AVCodecContext.sample_rate.
//     * For all other types, this is in units of AVCodecContext.time_base.
//     */
//    int duration;
//} AVCodecParserContext;

//typedef struct AVCodecParser {
//    int codec_ids[5]; /* several codec IDs are permitted */
//    int priv_data_size;
//    int (*parser_init)(AVCodecParserContext *s);
//    int (*parser_parse)(AVCodecParserContext *s,
//                        AVCodecContext *avctx,
//                        const uint8_t **poutbuf, int *poutbuf_size,
//                        const uint8_t *buf, int buf_size);
//    void (*parser_close)(AVCodecParserContext *s);
//    int (*split)(AVCodecContext *avctx, const uint8_t *buf, int buf_size);
//    struct AVCodecParser *next;
//} AVCodecParser;

//AVCodecParser *av_parser_next(AVCodecParser *c);

//void av_register_codec_parser(AVCodecParser *parser);
//AVCodecParserContext *av_parser_init(int codec_id);

///**
// * Parse a packet.
// *
// * @param s             parser context.
// * @param avctx         codec context.
// * @param poutbuf       set to pointer to parsed buffer or NULL if not yet finished.
// * @param poutbuf_size  set to size of parsed buffer or zero if not yet finished.
// * @param buf           input buffer.
// * @param buf_size      input length, to signal EOF, this should be 0 (so that the last frame can be output).
// * @param pts           input presentation timestamp.
// * @param dts           input decoding timestamp.
// * @param pos           input byte position in stream.
// * @return the number of bytes of the input bitstream used.
// *
// * Example:
// * @code
// *   while(in_len){
// *       len = av_parser_parse2(myparser, AVCodecContext, &data, &size,
// *                                        in_data, in_len,
// *                                        pts, dts, pos);
// *       in_data += len;
// *       in_len  -= len;
// *
// *       if(size)
// *          decode_frame(data, size);
// *   }
// * @endcode
// */
//int av_parser_parse2(AVCodecParserContext *s,
//                     AVCodecContext *avctx,
//                     uint8_t **poutbuf, int *poutbuf_size,
//                     const uint8_t *buf, int buf_size,
//                     int64_t pts, int64_t dts,
//                     int64_t pos);

//int av_parser_change(AVCodecParserContext *s,
//                     AVCodecContext *avctx,
//                     uint8_t **poutbuf, int *poutbuf_size,
//                     const uint8_t *buf, int buf_size, int keyframe);
//void av_parser_close(AVCodecParserContext *s);


//typedef struct AVBitStreamFilterContext {
//    void *priv_data;
//    struct AVBitStreamFilter *filter;
//    AVCodecParserContext *parser;
//    struct AVBitStreamFilterContext *next;
//} AVBitStreamFilterContext;


//typedef struct AVBitStreamFilter {
//    const char *name;
//    int priv_data_size;
//    int (*filter)(AVBitStreamFilterContext *bsfc,
//                  AVCodecContext *avctx, const char *args,
//                  uint8_t **poutbuf, int *poutbuf_size,
//                  const uint8_t *buf, int buf_size, int keyframe);
//    void (*close)(AVBitStreamFilterContext *bsfc);
//    struct AVBitStreamFilter *next;
//} AVBitStreamFilter;

//void av_register_bitstream_filter(AVBitStreamFilter *bsf);
//AVBitStreamFilterContext *av_bitstream_filter_init(const char *name);
//int av_bitstream_filter_filter(AVBitStreamFilterContext *bsfc,
//                               AVCodecContext *avctx, const char *args,
//                               uint8_t **poutbuf, int *poutbuf_size,
//                               const uint8_t *buf, int buf_size, int keyframe);
//void av_bitstream_filter_close(AVBitStreamFilterContext *bsf);

//AVBitStreamFilter *av_bitstream_filter_next(AVBitStreamFilter *f);

///* memory */

///**
// * Reallocate the given block if it is not large enough, otherwise do nothing.
// *
// * @see av_realloc
// */
//void *av_fast_realloc(void *ptr, unsigned int *size, size_t min_size);

///**
// * Allocate a buffer, reusing the given one if large enough.
// *
// * Contrary to av_fast_realloc the current buffer contents might not be
// * preserved and on error the old buffer is freed, thus no special
// * handling to avoid memleaks is necessary.
// *
// * @param ptr pointer to pointer to already allocated buffer, overwritten with pointer to new buffer
// * @param size size of the buffer *ptr points to
// * @param min_size minimum size of *ptr buffer after returning, *ptr will be NULL and
// *                 *size 0 if an error occurred.
// */
//void av_fast_malloc(void *ptr, unsigned int *size, size_t min_size);

///**
// * Same behaviour av_fast_malloc but the buffer has additional
// * FF_INPUT_PADDING_SIZE at the end which will will always be 0.
// *
// * In addition the whole buffer will initially and after resizes
// * be 0-initialized so that no uninitialized data will ever appear.
// */
//void av_fast_padded_malloc(void *ptr, unsigned int *size, size_t min_size);

///**
// * Copy image src to dst. Wraps av_picture_data_copy() above.
// */
//void av_picture_copy(AVPicture *dst, const AVPicture *src,
//                     enum PixelFormat pix_fmt, int width, int height);

///**
// * Crop image top and left side.
// */
//int av_picture_crop(AVPicture *dst, const AVPicture *src,
//                    enum PixelFormat pix_fmt, int top_band, int left_band);

///**
// * Pad image.
// */
//int av_picture_pad(AVPicture *dst, const AVPicture *src, int height, int width, enum PixelFormat pix_fmt,
//            int padtop, int padbottom, int padleft, int padright, int *color);

///**
// * Encode extradata length to a buffer. Used by xiph codecs.
// *
// * @param s buffer to write to; must be at least (v/255+1) bytes long
// * @param v size of extradata in bytes
// * @return number of bytes written to the buffer.
// */
//unsigned int av_xiphlacing(unsigned char *s, unsigned int v);

///**
// * Log a generic warning message about a missing feature. This function is
// * intended to be used internally by FFmpeg (libavcodec, libavformat, etc.)
// * only, and would normally not be used by applications.
// * @param[in] avc a pointer to an arbitrary struct of which the first field is
// * a pointer to an AVClass struct
// * @param[in] feature string containing the name of the missing feature
// * @param[in] want_sample indicates if samples are wanted which exhibit this feature.
// * If want_sample is non-zero, additional verbage will be added to the log
// * message which tells the user how to report samples to the development
// * mailing list.
// */
//void av_log_missing_feature(void *avc, const char *feature, int want_sample);

///**
// * Log a generic warning message asking for a sample. This function is
// * intended to be used internally by FFmpeg (libavcodec, libavformat, etc.)
// * only, and would normally not be used by applications.
// * @param[in] avc a pointer to an arbitrary struct of which the first field is
// * a pointer to an AVClass struct
// * @param[in] msg string containing an optional message, or NULL if no message
// */
//void av_log_ask_for_sample(void *avc, const char *msg, ...) av_printf_format(2, 3);

///**
// * Register the hardware accelerator hwaccel.
// */
//void av_register_hwaccel(AVHWAccel *hwaccel);

///**
// * If hwaccel is NULL, returns the first registered hardware accelerator,
// * if hwaccel is non-NULL, returns the next registered hardware accelerator
// * after hwaccel, or NULL if hwaccel is the last one.
// */
//AVHWAccel *av_hwaccel_next(AVHWAccel *hwaccel);


///**
// * Lock operation used by lockmgr
// */
//enum AVLockOp {
//  AV_LOCK_CREATE,  ///< Create a mutex
//  AV_LOCK_OBTAIN,  ///< Lock the mutex
//  AV_LOCK_RELEASE, ///< Unlock the mutex
//  AV_LOCK_DESTROY, ///< Free mutex resources
//};

///**
// * Register a user provided lock manager supporting the operations
// * specified by AVLockOp. mutex points to a (void *) where the
// * lockmgr should store/get a pointer to a user allocated mutex. It's
// * NULL upon AV_LOCK_CREATE and != NULL for all other ops.
// *
// * @param cb User defined callback. Note: FFmpeg may invoke calls to this
// *           callback during the call to av_lockmgr_register().
// *           Thus, the application must be prepared to handle that.
// *           If cb is set to NULL the lockmgr will be unregistered.
// *           Also note that during unregistration the previously registered
// *           lockmgr callback may also be invoked.
// */
//int av_lockmgr_register(int (*cb)(void **mutex, enum AVLockOp op));

///**
// * Get the type of the given codec.
// */
//enum AVMediaType avcodec_get_type(enum CodecID codec_id);

///**
// * Get the AVClass for AVCodecContext. It can be used in combination with
// * AV_OPT_SEARCH_FAKE_OBJ for examining options.
// *
// * @see av_opt_find().
// */
//const AVClass *avcodec_get_class(void);

///**
// * Get the AVClass for AVFrame. It can be used in combination with
// * AV_OPT_SEARCH_FAKE_OBJ for examining options.
// *
// * @see av_opt_find().
// */
//const AVClass *avcodec_get_frame_class(void);

///**
// * @return a positive value if s is open (i.e. avcodec_open2() was called on it
// * with no corresponding avcodec_close()), 0 otherwise.
// */
//int avcodec_is_open(AVCodecContext *s);

///**
// * @return a non-zero number if codec is an encoder, zero otherwise
// */
//int av_codec_is_encoder(AVCodec *codec);

///**
// * @return a non-zero number if codec is a decoder, zero otherwise
// */
//int av_codec_is_decoder(AVCodec *codec);

//#if FF_API_OLD_DECODE_AUDIO
///* in bytes */
//#define AVCODEC_MAX_AUDIO_FRAME_SIZE 192000 // 1 second of 48khz 32bit audio
//#endif

}
