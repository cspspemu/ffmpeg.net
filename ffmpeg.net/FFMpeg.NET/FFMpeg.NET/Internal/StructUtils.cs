using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace FFMpeg.NET.Internal
{
	public class StructUtils
	{
		static public TType RawDeserialize<TType>(byte[] rawData, int position)
		{
			Type anyType = typeof(TType);
			int rawsize = Marshal.SizeOf(anyType);
			if (rawsize > rawData.Length) return default(TType);
			IntPtr buffer = Marshal.AllocHGlobal(rawsize);
			Marshal.Copy(rawData, position, buffer, rawsize);
			object retobj = Marshal.PtrToStructure(buffer, anyType);
			Marshal.FreeHGlobal(buffer);
			return (TType)retobj;
		}

		static public void RawSerialize<TType>(byte[] rawData, int position, TType value)
		{
			var Data = RawSerialize(value);
			Array.Copy(Data, 0, rawData, position, Data.Length);
		}

		public static byte[] RawSerialize(object anything)
		{
			int rawSize = Marshal.SizeOf(anything);
			IntPtr buffer = Marshal.AllocHGlobal(rawSize);
			Marshal.StructureToPtr(anything, buffer, false);
			byte[] rawDatas = new byte[rawSize];
			Marshal.Copy(buffer, rawDatas, 0, rawSize);
			Marshal.FreeHGlobal(buffer);
			return rawDatas;
		}
	}
}
