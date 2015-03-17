using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using InstantImageEditor.Common;

namespace InstantImageEditor.Gui
{
	public abstract class FilterControlBase
		: Control
	{
		public abstract IImageFilter GetFilter();
	}
}
