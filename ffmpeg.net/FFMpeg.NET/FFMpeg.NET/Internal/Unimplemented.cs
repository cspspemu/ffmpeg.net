using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal
{
	/// <summary>
	/// Class to use as placeholder on non implemented yet stuff.
	/// If this is used, coder should check variable and change it.
	/// </summary>
	public abstract class Unimplemented
	{
		static public void Mark()
		{
			throw new NotImplementedException();
		}

		internal static void MarkWarning(string Name)
		{
			Console.Error.WriteLine("MarkWarning! : {0}", Name);
		}
	}
}
