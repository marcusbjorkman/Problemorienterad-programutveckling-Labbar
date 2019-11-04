using System.Windows;

namespace Uppgift2
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

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string txtBoxValue = TxtBoxName.Text;
            if (string.IsNullOrEmpty(txtBoxValue))
            {
                MessageBox.Show($"Inget namn angivet.");
                return;
            }

            MessageBox.Show($"Hej {txtBoxValue}!");
        }
    }
}
