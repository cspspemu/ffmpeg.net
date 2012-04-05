using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal
{
	public struct Pointer<TType>
	{
		public TType[] List;
		public int Offset;

		public TType this[int Index]
		{
			get
			{
				return List[Offset + Index];
			}
			set
			{
				List[Offset + Index] = value;
			}
		}

		public Pointer<NewType> Cast<NewType>()
		{
			throw new NotImplementedException();
		}

		public static Pointer<TType> operator++(Pointer<TType> This)
		{
			return new Pointer<TType>()
			{
				List = This.List,
				Offset = This.Offset + 1,
			};
		}

		public static Pointer<TType> operator +(Pointer<TType> This, uint Increment)
		{
			return This + (int)Increment;
		}

		public static Pointer<TType> operator +(Pointer<TType> This, int Increment)
		{
			return new Pointer<TType>()
			{
				List = This.List,
				Offset = This.Offset + Increment,
			};
		}
	}
}
