using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavutil
{
	public class error
	{
		public const int EINVAL = -2;
		public const int AVERROR_INVALIDDATA = -3;

		static public int AVERROR(int Error)
		{
			return Error;
		}

		/*
		#define AVERROR_BSF_NOT_FOUND      (-MKTAG(0xF8,'B','S','F')) ///< Bitstream filter not found
		#define AVERROR_BUG                (-MKTAG( 'B','U','G','!')) ///< Internal bug, also see AVERROR_BUG2
		#define AVERROR_DECODER_NOT_FOUND  (-MKTAG(0xF8,'D','E','C')) ///< Decoder not found
		#define AVERROR_DEMUXER_NOT_FOUND  (-MKTAG(0xF8,'D','E','M')) ///< Demuxer not found
		#define AVERROR_ENCODER_NOT_FOUND  (-MKTAG(0xF8,'E','N','C')) ///< Encoder not found
		#define AVERROR_EOF                (-MKTAG( 'E','O','F',' ')) ///< End of file
		#define AVERROR_EXIT               (-MKTAG( 'E','X','I','T')) ///< Immediate exit was requested; the called function should not be restarted
		#define AVERROR_FILTER_NOT_FOUND   (-MKTAG(0xF8,'F','I','L')) ///< Filter not found
		#define AVERROR_INVALIDDATA        (-MKTAG( 'I','N','D','A')) ///< Invalid data found when processing input
		#define AVERROR_MUXER_NOT_FOUND    (-MKTAG(0xF8,'M','U','X')) ///< Muxer not found
		#define AVERROR_OPTION_NOT_FOUND   (-MKTAG(0xF8,'O','P','T')) ///< Option not found
		#define AVERROR_PATCHWELCOME       (-MKTAG( 'P','A','W','E')) ///< Not yet implemented in FFmpeg, patches welcome
		#define AVERROR_PROTOCOL_NOT_FOUND (-MKTAG(0xF8,'P','R','O')) ///< Protocol not found
		#define AVERROR_STREAM_NOT_FOUND   (-MKTAG(0xF8,'S','T','R')) ///< Stream not found
		*/
	}
}
