using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FFMpeg.NET.Internal;

namespace FFMpeg.NET.Tests
{
	[TestClass]
	public class CLibTest
	{
		[TestMethod]
		public void TestMemset()
		{
			var Pointer = CLib.malloc(8);
			CLib.memset(Pointer, 1, 4);
			CollectionAssert.AreEqual(new byte[] { 1, 1, 1, 1, 0, 0, 0, 0 }, Pointer.Data.ToArray());
		}

		[TestMethod]
		public void TestIsStruct()
		{
			var Pointers = new Pointer<byte>[1];
			Assert.IsTrue(Pointers[0].IsNull);
		}
	}
}
