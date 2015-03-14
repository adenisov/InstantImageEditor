
using System.IO;

namespace InstantImageEditor.Common
{
	public interface IImageFilter
	{
		Stream Filter(Stream image);
		bool IsSuitable(string extension);
	}
}
