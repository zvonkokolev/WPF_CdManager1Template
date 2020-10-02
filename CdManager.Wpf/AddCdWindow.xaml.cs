using CdManager.Model;
using System.Windows;

namespace CdManager.Wpf
{
	/// <summary>
	/// Interaktionslogik für AddCdWindow.xaml
	/// </summary>
	public partial class AddCdWindow : Window
	{
		Cd newCd;

		public AddCdWindow()
		{
			InitializeComponent();
		}

		private void AddCdWindow_Loaded(object sender, RoutedEventArgs e)
		{
			newCd = new Cd();
			newCd.AlbumTitle = tbTitel.Text;
			newCd.Artist = tbArtist.Text;
			grdCdField.DataContext = newCd;
		}

		private void BtnSave_Clicked(object sender, RoutedEventArgs e)
		{
			Repository.GetInstance().AddCd(newCd);
			Close();
		}

		private void BtnCancel_Clicked(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
