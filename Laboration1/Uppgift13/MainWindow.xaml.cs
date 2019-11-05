using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Uppgift13
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

        private void BtnCount_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBoxTextInput.Text) || string.IsNullOrEmpty(TxtBoxSearchInput.Text))
            {
                MessageBox.Show("Ange en text och något att söka efter först!");
                return;
            }

            int count = TxtBoxTextInput.Text.Count(o => 
                o.ToString().ToUpper() == TxtBoxSearchInput.Text.ToUpper());

            TxtBlockResult.Text = $"Hittade bokstaven '{TxtBoxSearchInput.Text}' {count} gånger.";
        }

        private void TxtBoxSearchInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (TxtBoxSearchInput.Text.Count() >= 1)
            {
                e.Handled = true;
                return;
            }

            var regex = new Regex("[^a-zA-ZåäöÅÄÖ]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
