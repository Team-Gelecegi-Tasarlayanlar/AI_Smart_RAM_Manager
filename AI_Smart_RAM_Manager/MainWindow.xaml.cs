using System;
using System.Windows;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Threading;


namespace AI_Smart_RAM_Manager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		private MediaPlayer myMediaPlayer = new MediaPlayer();
		private DispatcherTimer timer;
		public MainWindow()
		{
			InitializeComponent();
			ListPrograms();
			fileCreaterScript = new FileCreater();
			timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(3);
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if (programsList.SelectedItem == null)
			{
				ListPrograms();
			}
		}

		private void reloadButtonClick(object sender, RoutedEventArgs e)
		{
			ListPrograms();
		}

		private void killButtonClick(object sender, RoutedEventArgs e) 
		{
			if (programsList.SelectedItem != null)
			{
				Process selectedProcess = (Process)programsList.SelectedItem;

				try
				{
					selectedProcess.Kill();
					programsList.Items.Remove(selectedProcess);
					MessageBox.Show($"Program '{selectedProcess.ProcessName}' kapatıldı.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Program kapatılamadı: {ex.Message}", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}

			else
			{
				MessageBox.Show("Lütfen bir program seçin.", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}

		private void ListPrograms()
		{
			programsList.Items.Clear();

			Process[] runningExecutables = Process.GetProcesses();

			foreach (Process process in runningExecutables) 
			{
				if(!string.IsNullOrEmpty(process.MainWindowTitle))
				{
					programsList.Items.Add(process);
				}
			}
		}
	}
}