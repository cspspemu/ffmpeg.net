using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFMpeg.NET.Internal.libavcodec.avcodec;
using FFMpeg.NET.Internal.libavutil;
using System.Runtime.InteropServices;

namespace FFMpeg.NET.Internal.libavcodec.bmp
{
	public class ff_bmp_decoder : AVCodec
	{
		override public string name { get { return "bmp"; } }
		override public string long_name { get { return "BMP image"; } }
		override public CodecID id { get { return CodecID.CODEC_ID_BMP; } }
		override public uint capabilities { get { return Constants.CODEC_CAP_DR1; } }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="avctx"></param>
		/// <returns></returns>
		override public int init(AVCodecContext avctx)
		{
			var s = (BMPContext)avctx.priv_data;

			//avcodec_get_frame_defaults(s.picture);
			throw(new NotImplementedException());

			avctx.coded_frame = s.picture;

			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="avctx"></param>
		/// <returns></returns>
		override public int close(AVCodecContext avctx)
		{
			var c = (BMPContext)avctx.priv_data;

			//if (c.picture.data[0]) avctx.release_buffer(avctx, c.picture);
			throw (new NotImplementedException());

			return 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="avctx"></param>
		/// <param name="outdata"></param>
		/// <param name="outdata_size"></param>
		/// <param name="avpkt"></param>
		/// <returns></returns>
		public override int decode(AVCodecContext avctx, Pointer<byte> data, ref int data_size, AVPacket avpkt)
		{
			Pointer<byte> buf = avpkt.data;
			int buf_size = avpkt.size;
			BMPContext s = (BMPContext)avctx.priv_data;
			Pointer<AVFrame> picture = data.Cast<AVFrame>();
			AVFrame p = s.picture;
			uint fsize, hsize;
			int width, height;
			int depth;
			BiCompression comp;
			uint ihsize;
			int i, n, linesize;
			var rgb = new uint[3];
			uint alpha = 0;
			Pointer<byte> ptr;
			int dsize;
			Pointer<byte> buf0 = buf;

			if (buf_size < 14){
				//av_log(avctx, AV_LOG_ERROR, "buf size too small (%d)\n", buf_size);
				throw(new NotImplementedException());
				return -1;
			}

			if (bytestream.get_byte(ref buf) != 'B' || bytestream.get_byte(ref buf) != 'M') {
				//av_log(avctx, AV_LOG_ERROR, "bad magic number\n");
				throw (new NotImplementedException());
				return -1;
			}

			fsize = bytestream.get_le32(ref buf);

			if (buf_size < fsize){
				//av_log(avctx, AV_LOG_ERROR, "not enough data (%d < %d), trying to decode anyway\n", buf_size, fsize);
				throw (new NotImplementedException());
				fsize = (uint)buf_size;
			}

			buf += 2; /* reserved1 */
			buf += 2; /* reserved2 */

			hsize = bytestream.get_le32(ref buf); /* header size */
			ihsize = bytestream.get_le32(ref buf);       /* more header size */

			if (ihsize + 14 > hsize){
				//av_log(avctx, AV_LOG_ERROR, "invalid header size %d\n", hsize);
				throw(new NotImplementedException());
				return -1;
			}

			/* sometimes file size is set to some headers size, set a real size in that case */
			if (fsize == 14 || fsize == ihsize + 14)
			{
				fsize = (uint)(buf_size - 2);
			}

			if (fsize <= hsize)
			{
				//av_log(avctx, AV_LOG_ERROR, "declared file size is less than header size (%d < %d)\n", fsize, hsize);
				throw(new NotImplementedException());
				return -1;
			}

			switch (ihsize)
			{
				case  40: // windib
				case  56: // windib v3
				case  64: // OS/2 v2
				case 108: // windib v4
				case 124: // windib v5
					width = (int)bytestream.get_le32(ref buf);
					height = (int)bytestream.get_le32(ref buf);
					break;
				case  12: // OS/2 v1
					width = (int)bytestream.get_le16(ref buf);
					height = (int)bytestream.get_le16(ref buf);
				break;
				default:
					//av_log(avctx, AV_LOG_ERROR, "unsupported BMP file, patch welcome\n");
					throw(new NotImplementedException());
					return -1;
			}

			if (bytestream.get_le16(ref buf) != 1) /* planes */
			{
				//av_log(avctx, AV_LOG_ERROR, "invalid BMP header\n");
				throw(new NotImplementedException());
				return -1;
			}

			depth = bytestream.get_le16(ref buf);

			if (ihsize == 40 || ihsize == 64 || ihsize == 56)
			{
				comp = (BiCompression)bytestream.get_le32(ref buf);
			}
			else
			{
				comp = BiCompression.BMP_RGB;
			}

			if (comp != BiCompression.BMP_RGB && comp != BiCompression.BMP_BITFIELDS && comp != BiCompression.BMP_RLE4 && comp != BiCompression.BMP_RLE8)
			{
				//av_log(avctx, AV_LOG_ERROR, "BMP coding %d not supported\n", comp);
				throw(new NotImplementedException());
				return -1;
			}

			if (comp == BiCompression.BMP_BITFIELDS)
			{
				buf += 20;
				rgb[0] = bytestream.get_le32(ref buf);
				rgb[1] = bytestream.get_le32(ref buf);
				rgb[2] = bytestream.get_le32(ref buf);
				if (ihsize >= 108)
				{
					alpha = bytestream.get_le32(ref buf);
				}
			}


			avctx.width = width;
			avctx.height = height > 0 ? height : -height;

			//avctx.pix_fmt = PIX_FMT_NONE;
			throw(new NotImplementedException());


			switch (depth)
			{
			case 32:
				if (comp == BiCompression.BMP_BITFIELDS)
				{
					if (rgb[0] == 0xFF000000 && rgb[1] == 0x00FF0000 && rgb[2] == 0x0000FF00)
					{
						avctx.pix_fmt = (alpha != 0) ? PixelFormat.PIX_FMT_ABGR : PixelFormat.PIX_FMT_0BGR;
					}
					else if (rgb[0] == 0x00FF0000 && rgb[1] == 0x0000FF00 && rgb[2] == 0x000000FF)
					{
						avctx.pix_fmt = (alpha != 0) ? PixelFormat.PIX_FMT_BGRA : PixelFormat.PIX_FMT_BGR0;
					}
					else if (rgb[0] == 0x0000FF00 && rgb[1] == 0x00FF0000 && rgb[2] == 0xFF000000)
					{
						avctx.pix_fmt = (alpha != 0) ? PixelFormat.PIX_FMT_ARGB : PixelFormat.PIX_FMT_0RGB;
					}
					else if (rgb[0] == 0x000000FF && rgb[1] == 0x0000FF00 && rgb[2] == 0x00FF0000)
					{
						avctx.pix_fmt = (alpha != 0) ? PixelFormat.PIX_FMT_RGBA : PixelFormat.PIX_FMT_RGB0;
					}
					else
					{
						//av_log(avctx, AV_LOG_ERROR, "Unknown bitfields %0X %0X %0X\n", rgb[0], rgb[1], rgb[2]);
						throw (new NotImplementedException());
						//return AVERROR(EINVAL);
						throw (new NotImplementedException());
					}
			    }
				else
				{
					avctx.pix_fmt = PixelFormat.PIX_FMT_BGRA;
			    }
			    break;
			case 24:
				avctx.pix_fmt = PixelFormat.PIX_FMT_BGR24;
			    break;
			case 16:
				if (comp == BiCompression.BMP_RGB)
				{
					avctx.pix_fmt = PixelFormat.PIX_FMT_RGB555;
				}
				else if (comp == BiCompression.BMP_BITFIELDS)
				{
					if (rgb[0] == 0xF800 && rgb[1] == 0x07E0 && rgb[2] == 0x001F) avctx.pix_fmt = PixelFormat.PIX_FMT_RGB565;
					else if (rgb[0] == 0x7C00 && rgb[1] == 0x03E0 && rgb[2] == 0x001F) avctx.pix_fmt = PixelFormat.PIX_FMT_RGB555;
					else if (rgb[0] == 0x0F00 && rgb[1] == 0x00F0 && rgb[2] == 0x000F) avctx.pix_fmt = PixelFormat.PIX_FMT_RGB444;
					else
					{
						//av_log(avctx, AV_LOG_ERROR, "Unknown bitfields %0X %0X %0X\n", rgb[0], rgb[1], rgb[2]);
						throw (new NotImplementedException());
						//return AVERROR(EINVAL);
						throw (new NotImplementedException());
					}
				}
			    break;
			case 8:
				if (hsize - ihsize - 14 > 0)
				{
					avctx.pix_fmt = PixelFormat.PIX_FMT_PAL8;
				}
				else
				{
					avctx.pix_fmt = PixelFormat.PIX_FMT_GRAY8;
				}
			    break;
			case 1:
			case 4:
			    if (hsize - ihsize - 14 > 0)
				{
					avctx.pix_fmt = PixelFormat.PIX_FMT_PAL8;
			    }
				else
				{
			        //av_log(avctx, AV_LOG_ERROR, "Unknown palette for %d-colour BMP\n", 1<<depth);
					throw (new NotImplementedException());
					return -1;
			    }
			    break;
			default:
			    //av_log(avctx, AV_LOG_ERROR, "depth %d not supported\n", depth);
				throw(new NotImplementedException());
			    return -1;
			}

			if (avctx.pix_fmt == PixelFormat.PIX_FMT_NONE)
			{
			    //av_log(avctx, AV_LOG_ERROR, "unsupported pixel format\n");
				throw(new NotImplementedException());
			    return -1;
			}

			//if (p.data[0]) avctx.release_buffer(avctx, p);
			throw(new NotImplementedException());

			p.reference = 0;
			/*
			if (avctx.get_buffer(avctx, p) < 0)
			{
			    //av_log(avctx, AV_LOG_ERROR, "get_buffer() failed\n");
				throw(new NotImplementedException());
			    return -1;
			}
			*/
			throw(new NotImplementedException());

			//p.pict_type = AV_PICTURE_TYPE_I;
			throw(new NotImplementedException());

			p.key_frame = 1;

			buf = buf0 + hsize;
			dsize = (int)(buf_size - hsize);

			/* Line size in file multiple of 4 */
			n = (int)(((avctx.width * depth + 31) / 8) & ~3);

			if (n * avctx.height > dsize && comp != BiCompression.BMP_RLE4 && comp != BiCompression.BMP_RLE8)
			{
			    //av_log(avctx, AV_LOG_ERROR, "not enough data (%d < %d)\n", dsize, n * avctx->height);
				throw(new NotImplementedException());
			    return -1;
			}

			// RLE may skip decoding some picture areas, so blank picture before decoding
			if (comp == BiCompression.BMP_RLE4 || comp == BiCompression.BMP_RLE8)
			{
				CLib.memset(p.data[0], 0, avctx.height * p.linesize[0]);
			}

			if (depth == 4 || depth == 8)
			{
				CLib.memset(p.data[1], 0, 1024);
			}

			if (height > 0)
			{
			    ptr = p.data[0] + (avctx.height - 1) * p.linesize[0];
			    linesize = -p.linesize[0];
			}
			else
			{
			    ptr = p.data[0];
			    linesize = p.linesize[0];
			}

			if (avctx.pix_fmt == PixelFormat.PIX_FMT_PAL8)
			{
			    int colors = (1 << depth);
			    if (ihsize >= 36)
				{
			        int t;
			        buf = buf0 + 46;
			        t = (int)bytestream.get_le32(ref buf);
			        if (t < 0 || t > (int)(1 << depth))
					{
			            //av_log(avctx, AV_LOG_ERROR, "Incorrect number of colors - %X for bitdepth %d\n", t, depth);
						throw(new NotImplementedException());
			        }
					else if (t != 0)
					{
			            colors = t;
			        }
			    }
			    buf = buf0 + 14 + ihsize; //palette location
				if ((hsize - ihsize - 14) < (colors << 2)) // OS/2 bitmap, 3 bytes per palette entry
				{
					for (i = 0; i < colors; i++)
					{
						var a = p.data[1].Cast<uint>();
						a[i] = (uint)((0xff << 24) | bytestream.get_le24(ref buf));
					}
			    }
				else
				{
					for (i = 0; i < colors; i++)
					{
						var a = p.data[1].Cast<uint>();
						a[i] = (uint)((0xFFU << 24) | bytestream.get_le32(ref buf));
					}
			    }
			    buf = buf0 + hsize;
			}

			if (comp == BiCompression.BMP_RLE4 || comp == BiCompression.BMP_RLE8)
			{
			    if (height < 0)
				{
			        p.data[0] += p.linesize[0] * (avctx.height - 1);
			        p.linesize[0] = -p.linesize[0];
			    }

			    //ff_msrle_decode(avctx, (AVPicture)p, depth, buf, dsize);
				throw(new NotImplementedException());

			    if (height < 0)
				{
			        p.data[0] += p.linesize[0] * (avctx.height - 1);
			        p.linesize[0] = -p.linesize[0];
			    }
			}
			else
			{
			    switch (depth)
				{
			    case 1:
			        for (i = 0; i < avctx.height; i++)
					{
			            for (int j = 0; j < n; j++)
						{
			                ptr[j * 8 + 0] = (byte)((buf[j] >> 7)    );
			                ptr[j * 8 + 1] = (byte)((buf[j] >> 6) & 1);
			                ptr[j * 8 + 2] = (byte)((buf[j] >> 5) & 1);
			                ptr[j * 8 + 3] = (byte)((buf[j] >> 4) & 1);
			                ptr[j * 8 + 4] = (byte)((buf[j] >> 3) & 1);
			                ptr[j * 8 + 5] = (byte)((buf[j] >> 2) & 1);
			                ptr[j * 8 + 6] = (byte)((buf[j] >> 1) & 1);
			                ptr[j * 8 + 7] = (byte)((buf[j] >> 0) & 1);
			            }
			            buf += n;
			            ptr += linesize;
			        }
			        break;
			    case 8:
			    case 24:
			    case 32:
			        for(i = 0; i < avctx.height; i++){
			            CLib.memcpy(ptr, buf, n);
			            buf += n;
			            ptr += linesize;
			        }
			        break;
			    case 4:
			        for(i = 0; i < avctx.height; i++){
			            for(int j = 0; j < n; j++)
						{
			                ptr[j * 2 + 0] = (byte)((buf[j] >> 4) & 0xF);
			                ptr[j * 2 + 1] = (byte)(buf[j] & 0xF);
			            }
			            buf += n;
			            ptr += linesize;
			        }
			        break;
			    case 16:
			        for (i = 0; i < avctx.height; i++)
					{
			            Pointer<ushort> src = buf.Cast<ushort>();
						Pointer<ushort> dst = ptr.Cast<ushort>();

						for (int j = 0; j < avctx.width; j++)
						{
							dst[0] = av_bswap.av_le2ne16(src[0]);
							src++;
							dst++;
						}

			            buf += n;
			            ptr += linesize;
			        }
			        break;
			    default:
			        //av_log(avctx, AV_LOG_ERROR, "BMP decoder is broken\n");
					throw(new NotImplementedException());
			        return -1;
			    }
			}

			picture[0] = s.picture;
			data_size = Marshal.SizeOf(typeof(AVPicture));

			return buf_size;
		} // decode
	} // class
} // namespace
