using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.targa
{

//static int targa_decode_rle(AVCodecContext *avctx, TargaContext *s,
//                            uint8_t *dst, int w, int h, int stride, int bpp)
//{
//    int x, y;
//    int depth = (bpp + 1) >> 3;
//    int type, count;
//    int diff;

//    diff = stride - w * depth;
//    x = y = 0;
//    while (y < h) {
//        if (bytestream2_get_bytes_left(&s->gb) <= 0) {
//            av_log(avctx, AV_LOG_ERROR,
//                   "Ran ouf of data before end-of-image\n");
//            return AVERROR_INVALIDDATA;
//        }
//        type  = bytestream2_get_byteu(&s->gb);
//        count = (type & 0x7F) + 1;
//        type &= 0x80;
//        if(x + count > (h - y) * w){
//            av_log(avctx, AV_LOG_ERROR,
//                   "Packet went out of bounds: position (%i,%i) size %i\n",
//                   x, y, count);
//            return AVERROR_INVALIDDATA;
//        }
//        if (!type) {
//            do {
//                int n  = FFMIN(count, w - x);
//                bytestream2_get_buffer(&s->gb, dst, n * depth);
//                count -= n;
//                dst   += n * depth;
//                x     += n;
//                if (x == w) {
//                    x    = 0;
//                    y++;
//                    dst += diff;
//                }
//            } while (count > 0);
//        } else {
//            uint8_t tmp[4];
//            bytestream2_get_buffer(&s->gb, tmp, depth);
//            do {
//                int n  = FFMIN(count, w - x);
//                count -= n;
//                x     += n;
//                do {
//                    memcpy(dst, tmp, depth);
//                    dst += depth;
//                } while (--n);
//                if (x == w) {
//                    x    = 0;
//                    y++;
//                    dst += diff;
//                }
//            } while (count > 0);
//        }
//    }
//    return 0;
//}
//}

}
