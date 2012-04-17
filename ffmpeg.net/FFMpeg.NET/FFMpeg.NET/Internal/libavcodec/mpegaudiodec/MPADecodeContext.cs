using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.mpegaudiodec
{
	public class MPADecodeContext
	{
#if false
	    MPA_DECODE_HEADER
	    uint8_t last_buf[LAST_BUF_SIZE];
	    int last_buf_size;
	    /* next header (used in free format parsing) */
	    uint32_t free_format_next_header;
	    GetBitContext gb;
	    GetBitContext in_gb;
	    DECLARE_ALIGNED(32, MPA_INT, synth_buf)[MPA_MAX_CHANNELS][512 * 2];
	    int synth_buf_offset[MPA_MAX_CHANNELS];
	    DECLARE_ALIGNED(32, INTFLOAT, sb_samples)[MPA_MAX_CHANNELS][36][SBLIMIT];
	    INTFLOAT mdct_buf[MPA_MAX_CHANNELS][SBLIMIT * 18]; /* previous samples, for layer 3 MDCT */
	    GranuleDef granules[2][2]; /* Used in Layer 3 */
	    int adu_mode; ///< 0 for standard mp3, 1 for adu formatted mp3
	    int dither_state;
	    int err_recognition;
	    AVCodecContext* avctx;
	    MPADSPContext mpadsp;
	    DSPContext dsp;
	    AVFrame frame;
#endif
	}
}
