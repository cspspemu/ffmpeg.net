using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal
{
	public class CLib
	{
		static public void memset(Pointer<byte> Pointer, byte Value, int Count)
		{
			for (int n = 0; n < Count; n++) Pointer[n] = Value;
		}

		static public void memcpy(Pointer<byte> destination, Pointer<byte> source, int num)
		{
			for (int n = 0; n < num; n++)
			{
				destination[n] = source[n];
			}
		}
	}
}
