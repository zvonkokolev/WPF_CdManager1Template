using CdManager.Model;
using System.Windows;

namespace CdManager.Wpf
{
	/// <summary>
	/// Interaktionslogik für EditCdWindow.xaml
	/// </summary>
	public partial class EditCdWindow : Window
	{
		private Cd newCd;
		private readonly Cd _cdToEdit;

		public EditCdWindow(Cd cdToEdit)
		{
			_cdToEdit = cdToEdit;
			InitializeComponent();
		}

		private void EditCdWindow_Loaded(object sender, RoutedEventArgs e)
		{
			tbTitel.Text = _cdToEdit.AlbumTitle;
			tbArtist.Text = _cdToEdit.Artist;
			newCd = new Cd
			{
				AlbumTitle = tbTitel.Text,
				Artist = tbArtist.Text
			};
			grdCdField.DataContext = newCd;
		}

		private void BtnSave_Clicked(object sender, RoutedEventArgs e)
		{
			Repository
				.GetInstance()
				.UpdateCd(_cdToEdit, newCd);

			Close();
		}

		private void BtnCancel_Clicked(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
