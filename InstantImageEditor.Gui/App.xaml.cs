
using System.Windows;

namespace InstantImageEditor.Gui
{
	public partial class App
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
#if DEBUG
			new MainWindow(@"C:\Users\Andrew\Pictures\Galaxy.jpg",
				FilterControlFactory.GetFilterControl("Resize")).Show();
#else
			new MainWindow(e.Args[0],
				FilterControlFactory.GetFilterControl(e.Args[1])).Show();
#endif
		}
	}
}
