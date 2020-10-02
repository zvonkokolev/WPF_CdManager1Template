using CdManager.Model;
using System.Collections.Generic;
using System.Windows;

namespace CdManager.Wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private List<Cd> _cds;
		private Repository rep;
		public MainWindow()
		{
			InitializeComponent();
			Loaded += new RoutedEventHandler(MainWindow_Loaded);
		}

		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			rep = Repository.GetInstance();
			_cds = rep.GetAllCds();
			lbxCds.ItemsSource = _cds;
		}

		private void BtnNew_Clicked(object sender, RoutedEventArgs e)
		{
			AddCdWindow addCdWindow = new AddCdWindow();
			addCdWindow.ShowDialog();
			rep = Repository.GetInstance();

			_cds = rep.GetAllCds();
			lbxCds.ItemsSource = _cds;
		}

		private void BtnDel_Clicked(object sender, RoutedEventArgs e)
		{
			rep = Repository.GetInstance();
			Cd selectedCd = (Cd)lbxCds.SelectedItem;
			if (selectedCd != null)
			{
				rep.RemoveCd(selectedCd);
			}
			else
			{
				MessageBox.Show("Wählen Sie CD zum Löschen");
			}

			_cds = rep.GetAllCds();
			lbxCds.ItemsSource = _cds;
		}

		private void BtnEdit_Clicked(object sender, RoutedEventArgs e)
		{
			rep = Repository.GetInstance();
			Cd selectedCd = (Cd)lbxCds.SelectedItem;

			if (selectedCd != null)
			{

				EditCdWindow editCdWindow = new EditCdWindow(selectedCd);
				editCdWindow.ShowDialog();
			}
			else
			{
				MessageBox.Show("Wählen Sie eine CD zum Bearbeiten");
			}

			_cds = rep.GetAllCds();
			lbxCds.ItemsSource = _cds;
		}
	}
}
