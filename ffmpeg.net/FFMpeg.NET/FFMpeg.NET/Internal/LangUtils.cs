using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal
{
	public class LangUtils
	{
		static public void Swap<TType>(ref TType A, ref TType B)
		{
			TType C = A;
			A = B;
			B = C;
		}
	}
}
