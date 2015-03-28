using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using InstantImageEditor.Common;
using InstantImageEditor.Filters.ResizeFilter;

namespace InstantImageEditor.Gui
{
	public class ResizeControl : FilterControlBase
	{
		public ResizeControl()
		{
			DefaultStyleKey = typeof (ResizeControl);
		}

		public static readonly DependencyProperty NewWidthProperty = DependencyProperty.Register(
			"NewWidth", typeof (string), typeof (ResizeControl), new PropertyMetadata("0"));

		public static readonly DependencyProperty NewHeightProperty = DependencyProperty.Register(
			"NewHeight", typeof (string), typeof (ResizeControl), new PropertyMetadata("0"));

		public string NewHeight
		{
			get { return (string) GetValue(NewHeightProperty); }
			set { SetValue(NewHeightProperty, value); }
		}

		public string NewWidth
		{
			get { return (string) GetValue(NewWidthProperty); }
			set { SetValue(NewWidthProperty, value); }
		}

		public override IImageFilter GetFilter()
		{
			int width;
			int height;
			if (int.TryParse(NewWidth, out width) && int.TryParse(NewHeight, out height) && width > 0 && height > 0)
			{
				return new ResizeFilter(width, height);

			}
			return null;
		}
	}
}
