using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFMpeg.NET.Internal.libavcodec.avcodec;
using FFMpeg.NET.Internal.libavutil.avutil;
using FFMpeg.NET.Internal.libavutil;

namespace FFMpeg.NET.Internal.libavcodec.targa
{
	public class ff_targa_decoder : AVCodec
	{
		public override string name { get { return "targa"; } }
		public override string long_name { get { return "Truevision Targa image"; } }
		public override CodecID id { get { return CodecID.CODEC_ID_TARGA; } }
		override public uint capabilities { get { return Constants.CODEC_CAP_DR1; } }
		public override AVMediaType type { get { return AVMediaType.AVMEDIA_TYPE_VIDEO; } }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="avctx"></param>
		/// <returns></returns>
		public override int init(AVCodecContext avctx)
		{
			if (avctx.priv_data == null) avctx.priv_data = new TargaContext();

			var s = (TargaContext)avctx.priv_data;

			Functions.avcodec_get_frame_defaults(s.picture);
		    avctx.coded_frame = s.picture;

		    return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="avctx"></param>
		/// <returns></returns>
		public override int close(AVCodecContext avctx)
		{
			var s = (TargaContext)avctx.priv_data;

			if (!s.picture.data[0].IsNull)
			{
				avctx.release_buffer(avctx, s.picture);
			}

			return 0;
		}

		public override int decode(AVCodecContext avctx, ref object outdata, AVPacket avpkt)
		{
			outdata = null;

			TargaContext s = (TargaContext)avctx.priv_data;
			//AVFrame *picture = data;
			AVFrame p = s.picture;
			Pointer<byte> dst;
			int stride;
			TargaCompr compr;
			int idlen, pal, y, w, h, bpp, flags;
			int first_clr, colors, csize;

			bytestream2.init(ref s.gb, avpkt.data, avpkt.size);

			/* parse image header */
			idlen = bytestream2.get_byte(ref s.gb);
			pal = bytestream2.get_byte(ref s.gb);
			compr = (TargaCompr)bytestream2.get_byte(ref s.gb);
			first_clr = bytestream2.get_le16(ref s.gb);
			colors = bytestream2.get_le16(ref s.gb);
			csize = bytestream2.get_byte(ref s.gb);
			bytestream2.skip(ref s.gb, 4); /* 2: x, 2: y */
			w = bytestream2.get_le16(ref s.gb);
			h = bytestream2.get_le16(ref s.gb);
			bpp = bytestream2.get_byte(ref s.gb);

			if (bytestream2.get_bytes_left(ref s.gb) <= idlen) {
				log.av_log(avctx, log.AV_LOG_ERROR, "Not enough data to read header\n");
			    return error.AVERROR_INVALIDDATA;
			}

			flags = bytestream2.get_byte(ref s.gb);

			if ((pal == 0) && ((first_clr != 0) || (colors != 0) || (csize != 0)))
			{
				log.av_log(avctx, log.AV_LOG_WARNING, "File without colormap has colormap information set.\n");
			    // specification says we should ignore those value in this case
			    first_clr = colors = csize = 0;
			}


			// skip identifier if any
			bytestream2.skip(ref s.gb, idlen);

			switch(bpp){
			case 8:
					avctx.pix_fmt = ((TargaCompr)((int)compr & (~(int)TargaCompr.TGA_RLE)) == TargaCompr.TGA_BW) ? PixelFormat.PIX_FMT_GRAY8 : PixelFormat.PIX_FMT_PAL8;
			    break;
			case 15:
			case 16:
				avctx.pix_fmt = PixelFormat.PIX_FMT_RGB555LE;
			    break;
			case 24:
				avctx.pix_fmt = PixelFormat.PIX_FMT_BGR24;
			    break;
			case 32:
				avctx.pix_fmt = PixelFormat.PIX_FMT_BGRA;
			    break;
			default:
				log.av_log(avctx, log.AV_LOG_ERROR, "Bit depth %i is not supported\n", bpp);
			    return -1;
			}


			if (!s.picture.data[0].IsNull) avctx.release_buffer(avctx, s.picture);

			if (imgutils.av_image_check_size((uint)w, (uint)h, 0, avctx) != 0) return -1;

			if (w != avctx.width || h != avctx.height) Functions.avcodec_set_dimensions(avctx, w, h);

			if (avctx.get_buffer(avctx, p) < 0)
			{
				log.av_log(avctx, log.AV_LOG_ERROR, "get_buffer() failed\n");
			    return -1;
			}

			if ((flags & 0x20) != 0)
			{
			    dst = p.data[0];
			    stride = p.linesize[0];
			}
			else
			{
				//image is upside-down
			    dst = p.data[0] + p.linesize[0] * (h - 1);
			    stride = -p.linesize[0];
			}


			if (colors != 0)
			{
			    int pal_size, pal_sample_size;
			    if((colors + first_clr) > 256){
					log.av_log(avctx, log.AV_LOG_ERROR, "Incorrect palette: %i colors with offset %i\n", colors, first_clr);
			        return -1;
			    }
			    switch (csize) {
			    case 24: pal_sample_size = 3; break;
			    case 16:
			    case 15: pal_sample_size = 2; break;
			    default:
					log.av_log(avctx, log.AV_LOG_ERROR, "Palette entry size %i bits is not supported\n", csize);
			        return -1;
			    }
			    pal_size = colors * pal_sample_size;
				if (avctx.pix_fmt != PixelFormat.PIX_FMT_PAL8)
				{
					//should not occur but skip palette anyway
					bytestream2.skip(ref s.gb, pal_size);
				}
				else
				{
					int t;
					var ppal = p.data[1].CastPointer<uint>() + first_clr;

					if (bytestream2.get_bytes_left(ref s.gb) < pal_size)
					{
						log.av_log(avctx, log.AV_LOG_ERROR, "Not enough data to read palette\n");
						return error.AVERROR_INVALIDDATA;
					}
					switch (pal_sample_size)
					{
						case 3:
							/* RGB24 */
							for (t = 0; t < colors; t++)
							{
								ppal[0] = (0xffU << 24) | bytestream2.get_le24u(ref s.gb);
								ppal++;
							}
							break;
						case 2:
							/* RGB555 */
							for (t = 0; t < colors; t++)
							{
								var v = (uint)bytestream2.get_le16u(ref s.gb);
								v = ((v & 0x7C00) << 9) |
									((v & 0x03E0) << 6) |
									((v & 0x001F) << 3);
								/* left bit replication */
								v |= (v & 0xE0E0E0U) >> 5;
								ppal[0] = (0xffU << 24) | v;
								ppal++;
							}
							break;
					}
					p.palette_has_changed = 1;
				}
			}

			if ((compr & (~TargaCompr.TGA_RLE)) == TargaCompr.TGA_NODATA)
			{
			    CLib.memset(p.data[0], 0, p.linesize[0] * h);
			}
			else {
				if ((compr & TargaCompr.TGA_RLE) != 0)
				{
			        //int res = targa_decode_rle(avctx, s, dst, w, h, stride, bpp);
			        //if (res < 0) return res;
					throw (new NotImplementedException());
				}
				else
				{
			        var img_size = w * ((bpp + 1) >> 3);
			        if (bytestream2.get_bytes_left(ref s.gb) < img_size * h) {
			            log.av_log(avctx, log.AV_LOG_ERROR, "Not enough data available for image\n");
			            return error.AVERROR_INVALIDDATA;
			        }
			        for (y = 0; y < h; y++)
					{
			            bytestream2.get_bufferu(ref s.gb, dst, img_size);
			            dst += stride;
			        }
			    }
			}


			if ((flags & 0x10) != 0) // right-to-left, needs horizontal flip
			{
			    int x;
			    for(y = 0; y < h; y++){
			        var line = p.data[0].GetOffsetPointer(y * p.linesize[0]);
			        for (x = 0; x < w >> 1; x++)
					{
			            switch (bpp)
						{
							case 32:
								line.CastPointer<uint>().SwapValuesAtOffsets((x), (w - x - 1));
								break;
							case 24:
								line.CastPointer<byte>().SwapValuesAtOffsets((3 * x + 0), (3 * w - 3 * x - 3));
								line.CastPointer<byte>().SwapValuesAtOffsets((3 * x + 1), (3 * w - 3 * x - 2));
								line.CastPointer<byte>().SwapValuesAtOffsets((3 * x + 2), (3 * w - 3 * x - 1));
								break;
							case 16:
								line.CastPointer<ushort>().SwapValuesAtOffsets((x), (w -x - 1));
								break;
							case 8:
								line.CastPointer<byte>().SwapValuesAtOffsets((x), (w -x - 1));
								break;
			            }
			        }
			    }
			}

			outdata = s.picture;

			return avpkt.size;
		}
	}
}
