using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using FFMpeg.NET.Internal;
using FFMpeg.NET.Internal.libavutil;

namespace FFMpeg.NET.Tests
{
	[TestClass]
	public class bytestreamTest
	{
		[TestMethod]
		public void TestGetByte()
		{
			var Data = Pointer<byte>.Create(new AllocatedMemory(new byte[] { 1, 2, 3 }));
			Assert.AreEqual(1, bytestream.get_byte(ref Data));
			Assert.AreEqual(2, bytestream.get_byte(ref Data));
			Assert.AreEqual(3, bytestream.get_byte(ref Data));
		}
	}
}
