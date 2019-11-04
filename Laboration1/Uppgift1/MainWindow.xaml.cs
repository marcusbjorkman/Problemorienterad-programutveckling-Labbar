using System.Windows;

namespace Uppgift1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnMessage_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Klickad :)");
        }
    }
}
