using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace FFMpeg.NET.Internal
{
	public struct Pointer<TType>
	{
		public byte[] Data;
		public int Offset;

		public int EntrySize
		{
			get
			{
				return Marshal.SizeOf(typeof(TType));
			}
		}

		public TType this[int Index]
		{
			get
			{
				return StructUtils.RawDeserialize<TType>(Data, Offset + EntrySize * Index);
			}
			set
			{
				StructUtils.RawSerialize(Data, Offset + EntrySize * Index, value);
			}
		}

		public Pointer<NewType> Cast<NewType>()
		{
			return new Pointer<NewType>()
			{
				Data = this.Data,
				Offset = this.Offset,
			};
		}

		public static Pointer<TType> operator++(Pointer<TType> This)
		{
			return This + 1;
		}

		public static Pointer<TType> operator +(Pointer<TType> This, uint Increment)
		{
			return This + (int)Increment;
		}

		public static Pointer<TType> operator +(Pointer<TType> This, int Increment)
		{
			return new Pointer<TType>()
			{
				Data = This.Data,
				Offset = This.Offset + (This.EntrySize * Increment),
			};
		}
	}
}
