
using System;

namespace InstantImageEditor.Gui
{
	public static class FilterControlFactory
	{
		public static FilterControlBase GetFilterControl(string parameter)
		{
			switch (parameter)
			{
				case "Resize":
					return new ResizeControl();
				default:
					throw new ArgumentException(parameter);
			}
		}
	}
}
