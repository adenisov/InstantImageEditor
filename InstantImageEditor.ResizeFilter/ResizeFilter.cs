﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstantImageEditor.Common;

namespace InstantImageEditor.Filters.ResizeFilter
{
	public class ResizeFilter : IImageFilter
	{
		public Stream Filter(Stream image)
		{
			var img = (Bitmap) Image.FromStream(image);
			var filter = new AForge.Imaging.Filters.ResizeBilinear(_width, _height);
			var resizedImg = filter.Apply(img);
			var stream = new MemoryStream();
			resizedImg.Save(stream, img.RawFormat);
			stream.Seek(0, SeekOrigin.Begin);
			return stream;
		}

		public bool IsSuitable(string extension)
		{
			return Extensions.Contains(extension);
		}

		private int _width;
		private int _height;

		private static readonly List<string> Extensions = new List<string>()
		{".jpg", ".png", ".bmp", ".gif"};

		public ResizeFilter(int width, int height)
		{
			_width = width;
			_height = height;
		}
	}
}
