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

namespace Uppgift5
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
            if (string.IsNullOrEmpty(NumberInput1.Text) || string.IsNullOrEmpty(NumberInput2.Text))
            {
                return;
            }

            var num1 = int.Parse(NumberInput1.Text);
            var num2 = int.Parse(NumberInput2.Text);

            TxtBoxSum.Text = $"{num1 + num2}";
        }

        private void NumberInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);
        }

        private void TxtBoxSum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            NumberInput1.Clear();
            NumberInput2.Clear();
            TxtBoxSum.Clear();
        }
    }
}
