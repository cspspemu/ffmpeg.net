using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace FFMpeg.NET.Internal
{
#if true
	public struct Pointer<TType>
	{
		public AllocatedMemory Data;
		public int Offset;
		public int EntrySize { get { return Marshal.SizeOf(Type); } }
		public Type Type { get { return typeof(TType); } }

		internal Pointer(AllocatedMemory Data, int Offset = 0)
		{
			this.Data = Data;
			this.Offset = Offset;
		}

		public TType this[int Index]
		{
			get
			{
				if (Type == typeof(byte))
				{
					return (TType)(object)Data.Data[Offset + Index];
				}
				else
				{
					return StructUtils.RawDeserialize<TType>(Data.Data, Offset + EntrySize * Index);
				}
			}
			set
			{
				if (Type == typeof(byte))
				{
					Data.Data[Offset + Index] = (byte)(object)value;
				}
				else
				{
					StructUtils.RawSerialize(Data.Data, Offset + EntrySize * Index, value);
				}
			}
		}

		public Pointer<NewType> Cast<NewType>()
		{
			return new Pointer<NewType>(this.Data, this.Offset);
		}

		public static Pointer<TType> operator ++(Pointer<TType> This)
		{
			return This + 1;
		}

		public static Pointer<TType> operator +(Pointer<TType> This, uint Increment)
		{
			return This + (int)Increment;
		}

		public static Pointer<TType> operator +(Pointer<TType> This, int Increment)
		{
			return new Pointer<TType>(
				This.Data,
				This.Offset + (This.EntrySize * Increment)
			);
		}

		public bool IsNull { get { return (Data == null) || (Data.Data == null); } }

		static public Pointer<TType> Create(AllocatedMemory AllocatedMemory, int Offset = 0)
		{
			//if (typeof(TType) == typeof(byte)) return (Pointer<TType>)(object)new BytePointer(AllocatedMemory, Offset);
			return new Pointer<TType>(AllocatedMemory, Offset);
		}

		public byte[] GetBytes(int Count)
		{
			var Bytes = new byte[Count];
			Array.Copy(this.Data.Data, Offset, Bytes, 0, Count);
			return Bytes;
		}
	}
#else
	public abstract class Pointer<TType>
	{
		public AllocatedMemory Data;
		public int Offset;
		public int EntrySize;

		internal Pointer(AllocatedMemory Data, int Offset = 0)
		{
			this.Data = Data;
			this.Offset = Offset;
			this.EntrySize = Marshal.SizeOf(typeof(TType));
		}

		abstract public TType this[int Index] { get; set; }

		public Pointer<NewType> Cast<NewType>()
		{
			return new GenericPointer<NewType>(this.Data, this.Offset);
		}

		public static Pointer<TType> operator ++(Pointer<TType> This)
		{
			return This + 1;
		}

		public static Pointer<TType> operator +(Pointer<TType> This, uint Increment)
		{
			return This + (int)Increment;
		}

		public static Pointer<TType> operator +(Pointer<TType> This, int Increment)
		{
			return new GenericPointer<TType>(
				This.Data,
				This.Offset + (This.EntrySize * Increment)
			);
		}

		public bool IsNull { get { return (Data == null) || (Data.Data == null); } }

		static public Pointer<TType> Create(AllocatedMemory AllocatedMemory, int Offset = 0)
		{
			if (typeof(TType) == typeof(byte)) return (Pointer<TType>)(object)new BytePointer(AllocatedMemory, Offset);
			return new GenericPointer<TType>(AllocatedMemory, Offset);
		}
	}

	public class BytePointer : Pointer<byte>
	{
		internal BytePointer(AllocatedMemory Data, int Offset = 0) : base(Data, Offset)
		{
		}

		override public byte this[int Index]
		{
			get
			{
				return Data.Data[Offset + Index];
			}
			set
			{
				Data.Data[Offset + Index] = value;
			}
		}

	}

	public class GenericPointer<TType> : Pointer<TType>
	{
		internal GenericPointer(AllocatedMemory Data, int Offset = 0)
			: base(Data, Offset)
		{
		}

		override public TType this[int Index]
		{
			get
			{
				return StructUtils.RawDeserialize<TType>(Data.Data, Offset + EntrySize * Index);
			}
			set
			{
				StructUtils.RawSerialize(Data.Data, Offset + EntrySize * Index, value);
			}
		}
	}
#endif
}
