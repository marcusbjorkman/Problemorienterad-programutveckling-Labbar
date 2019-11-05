using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Uppgift8
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

        private void NumInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);
        }

        private void TxtBoxResult_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;
        }

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NumInput1.Text) || string.IsNullOrEmpty(NumInput2.Text))
            {
                return;
            }

            int num1 = int.Parse(NumInput1.Text);
            int num2 = int.Parse(NumInput2.Text);

            double? result = null;
            if (RadioPlus.IsChecked.Value)
            {
                result = num1 + num2;
            }
            else if (RadioMinus.IsChecked.Value)
            {
                result = num1 - num2;
            }
            else if (RadioMulti.IsChecked.Value)
            {
                result = num1 * num2;
            }
            else if (RadioDiv.IsChecked.Value)
            {
                result = (double)num1 / num2;
            }

            if (!result.HasValue)
            {
                throw new Exception("No radiobutton checked?");
            }

            TxtBoxResult.Text = $"{Math.Round(result.Value, 2)}";
        }
    }
}
