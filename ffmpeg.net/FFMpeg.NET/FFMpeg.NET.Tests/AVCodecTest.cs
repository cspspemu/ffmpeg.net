using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFMpeg.NET.Internal.libavcodec.bmp;
using FFMpeg.NET.Internal.libavcodec.avcodec;
using FFMpeg.NET.Internal;
using FFMpeg.NET.Internal.libavutil;
using FFMpeg.NET.Internal.libavcodec.targa;

namespace FFMpeg.NET.Tests
{
	[TestClass]
	public class AVCodecTest
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

		byte[] Targa24 = {
			0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x02, 0x00, 0x02, 0x00, 0x18, 0x00, 0x33, 0x33, 0x33, 0x44, 0x44, 0x44,
			0x11, 0x11, 0x11, 0x22, 0x22, 0x22, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x54, 0x52, 0x55, 0x45, 0x56, 0x49, 0x53, 0x49, 0x4F, 0x4E,
			0x2D, 0x58, 0x46, 0x49, 0x4C, 0x45, 0x2E, 0x00
		};


		private object Decode<TType>(byte[] Data, AVCodec AVCodec, Action<AVCodecContext, AVPacket, TType> Action)
		{
			var context = new AVCodecContext();
			var packet = new AVPacket();
			packet.data = Pointer<byte>.Create(new AllocatedMemory(Data));
			packet.size = Data.Length;

			context.get_buffer = (AVCodecContext, AVFrame) =>
			{
				var width = AVCodecContext.width;
				var height = AVCodecContext.height;
				AVFrame.linesize[0] = width * 4;
				AVFrame.data[0] = CLib.malloc(AVFrame.linesize[0] * height);
				return 0;
			};

			context.release_buffer = (AVCodecContext, AVFrame) =>
			{
				CLib.free(AVFrame.data[0]);
			};

			AVCodec.init(context);
			try
			{
				object obj = null;
				if (AVCodec.decode(context, ref obj, packet) < 0) throw(new Exception());
				Action(context, packet, (TType)obj);
				return obj;
			}
			finally
			{
				AVCodec.close(context);
			}
		}

		[TestMethod]
		public void TestDecodeBmp24()
		{
			Decode<AVFrame>(Bmp24, new ff_bmp_decoder(), (context, packet, AVFrame) =>
			{
				var frame = context.coded_frame;

				Assert.AreEqual(2, context.width);
				Assert.AreEqual(2, context.height);
				Assert.AreEqual(PixelFormat.PIX_FMT_BGR24, context.pix_fmt);
				Assert.AreEqual(
					"11-11-11-22-22-22-00-00-33-33-33-44-44-44-00-00",
					BitConverter.ToString(AVFrame.data[0].GetBytes(8 * 2))
				);
			});
		}

		[TestMethod]
		public void TestDecodeTarga24()
		{
			Decode<AVFrame>(Targa24, new ff_targa_decoder(), (context, packet, AVFrame) =>
			{
				var frame = context.coded_frame;

				Assert.AreEqual(2, context.width);
				Assert.AreEqual(2, context.height);
				Assert.AreEqual(PixelFormat.PIX_FMT_BGR24, context.pix_fmt);
				Assert.AreEqual(
					"11-11-11-22-22-22-00-00-33-33-33-44-44-44-00-00",
					BitConverter.ToString(AVFrame.data[0].GetBytes(8 * 2))
				);
			});
		}
	}
}
