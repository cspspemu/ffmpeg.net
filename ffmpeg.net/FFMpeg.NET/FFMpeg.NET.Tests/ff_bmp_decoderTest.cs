using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFMpeg.NET.Internal.libavcodec.bmp;
using FFMpeg.NET.Internal.libavcodec.avcodec;
using FFMpeg.NET.Internal;
using FFMpeg.NET.Internal.libavutil;

namespace FFMpeg.NET.Tests
{
	[TestClass]
	public class ff_bmp_decoderTest
	{
		byte[] Bmp24 =
		{
			0x42, 0x4D, 0x48, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x36, 0x00,
			0x00, 0x00, 0x28, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x02, 0x00,
			0x00, 0x00, 0x01, 0x00, 0x18, 0x00, 0x00, 0x00, 0x00, 0x00, 0x12, 0x00,
			0x00, 0x00, 0x12, 0x0B, 0x00, 0x00, 0x12, 0x0B, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x33, 0x33, 0x33, 0x44, 0x44, 0x44,
			0x00, 0x00, 0x11, 0x11, 0x11, 0x22, 0x22, 0x22, 0x00, 0x00, 0x00, 0x00,
		};

		[TestMethod]
		public void Decode()
		{
			var context = new AVCodecContext();
			AVPacket packet = new AVPacket();
			packet.data = Pointer<byte>.Create(new AllocatedMemory(Bmp24));
			packet.size = Bmp24.Length;

			context.get_buffer = (AVCodecContext, AVFrame) =>
			{
				AVFrame.data[0] = CLib.malloc(1024);
				AVFrame.linesize[0] = 8;
				return 0;
			};

			context.release_buffer = (AVCodecContext, AVFrame) =>
			{
				CLib.free(AVFrame.data[0]);
			};

			var ff_bmp_decoder = new ff_bmp_decoder();
			ff_bmp_decoder.init(context);
			{
				object obj = null;
				Assert.IsTrue(ff_bmp_decoder.decode(context, ref obj, packet) >= 0);
				var AVFrame = (AVFrame)obj;

				Assert.AreEqual(2, context.width);
				Assert.AreEqual(2, context.height);
				Assert.AreEqual(PixelFormat.PIX_FMT_BGR24, context.pix_fmt);
				Assert.AreEqual(
					"11-11-11-22-22-22-00-00-33-33-33-44-44-44-00-00",
					BitConverter.ToString(AVFrame.data[0].GetBytes(8 * 2))
				);
			}
			ff_bmp_decoder.close(context);
		}
	}
}
