using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal
{
	public class AllocatedMemory
	{
		internal byte[] Data;

		public AllocatedMemory(byte[] Data)
		{
			this.Data = Data;
		}

		public byte[] ToArray()
		{
			return Data;
		}
	}
}
