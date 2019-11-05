using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Uppgift14
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

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NumInput.Text))
            {
                MessageBox.Show("Mata in ditt födeleseår först!");
                return;
            }

            if (!TryCalculateAge(NumInput.Text, out int age))
            {
                MessageBox.Show("Du måste mata in enbart siffror.");
                return;
            }

            MessageBox.Show($"Du är {age} år gammal.");
        }

        private bool TryCalculateAge(string input, out int age)
        {
            if (!IsValidInput(input) || !int.TryParse(input, out int birthyear))
            {
                age = 0;
                return false;
            }

            age = DateTime.Now.Year - birthyear;
            return true;
        }

        private bool IsValidInput(string input)
        {
            //var regex = new Regex("[^0-9]+");
            //if (regex.IsMatch(input))
            //{
            //    return false;
            //}

            //return true;

            return !input.Any(c => char.IsLetter(c));
        }
    }
}
