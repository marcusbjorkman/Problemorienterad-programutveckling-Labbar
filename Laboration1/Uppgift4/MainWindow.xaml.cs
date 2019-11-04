using System.Windows;
using System.Windows.Controls;

namespace Uppgift4
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LabelBtnClicked.Content = $"Du klickade på knappen {((Button)sender).Content}";
        }
    }
}
