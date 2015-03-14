
using System;
using System.IO;

namespace InstantImageEditor.Common
{
	public class ImageEditor
	{
		public void Edit(string inputPath, string outputPath,
			IImageFilter filter)
		{
			if (!File.Exists(inputPath))
			{
				throw new FileNotFoundException();
			}
			if (!filter.IsSuitable(Path.GetExtension(inputPath)))
			{
				throw new ArgumentException();
			}
			Stream outputStream;
			using (var stream = new FileStream(inputPath, FileMode.Open))
			{
				outputStream = filter.Filter(stream);
			}
			using (var stream = new FileStream(outputPath, FileMode.OpenOrCreate))
			{
				//var packetLength = 1024;
				//outputStream.Read()
				//stream.Write();
			}
		}
	}
}
