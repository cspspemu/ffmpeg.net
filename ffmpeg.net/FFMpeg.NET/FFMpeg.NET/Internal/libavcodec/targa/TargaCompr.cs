using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFMpeg.NET.Internal.libavcodec.targa
{
	/**
	 * @file
	 * targa file common definitions
	 *
	 * Based on:
	 * http://www.gamers.org/dEngine/quake3/TGA.txt
	 *
	 * and other specs you can find referenced for example in:
	 * http://en.wikipedia.org/wiki/Truevision_TGA
	 */

	public enum TargaCompr : byte
	{
		TGA_NODATA = 0, // no image data
		TGA_PAL = 1, // palettized
		TGA_RGB = 2, // true-color
		TGA_BW = 3, // black & white or grayscale
		TGA_RLE = 8, // flag pointing that data is RLE-coded
	};
}
