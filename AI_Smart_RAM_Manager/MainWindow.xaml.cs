using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace AI_Smart_RAM_Manager
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		private MediaPlayer myMediaPlayer = new MediaPlayer();
        public MainWindow()
		{
			InitializeComponent();
            
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			etiket.Content = textbox1.Text;
			try
			{
				string executablePath = AppDomain.CurrentDomain.BaseDirectory;
                string soundFilePath = System.IO.Path.Combine(executablePath, "anime-ahh.mp3");

				myMediaPlayer.Open(new Uri(soundFilePath));
				myMediaPlayer.Play();
            }
            catch (Exception ex)
			{
                MessageBox.Show("Ses çalınamadı: " + ex.Message);
                return;
            }
        }

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

		}







    }
}