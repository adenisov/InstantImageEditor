using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InstantImageEditor.Common;
using Microsoft.Win32;

namespace InstantImageEditor.Gui
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow(string inputImagePath, FilterControlBase filterControl)
		{
			InitializeComponent();
			_inputImagePath = inputImagePath;
			_filterControl = filterControl;
			ContentMain.Children.Add(_filterControl);
			Grid.SetRow(_filterControl, 0);
		}

		private readonly string _inputImagePath;
		private readonly FilterControlBase _filterControl;

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
			var filter = _filterControl.GetFilter();
			if (filter == null)
			{
				MessageBox.Show(this, "Specify correct arguments for transformation");
				return;
			}
			var dialog = new SaveFileDialog();
			var dialogResult = dialog.ShowDialog(this);
			if (dialogResult.Value)
			{
				var editor = new ImageEditor();
				editor.Edit(_inputImagePath, dialog.FileName, filter);
				Application.Current.Shutdown(0);
			}
		}
	}
}
