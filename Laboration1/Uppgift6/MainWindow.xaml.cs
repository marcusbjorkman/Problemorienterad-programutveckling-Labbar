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

namespace Uppgift6
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

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            NumInput1.Clear();
            NumInput2.Clear();
            TxtBoxResult.Clear();
            LabelResultName.Content = "";
        }

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NumInput1.Text) || string.IsNullOrEmpty(NumInput2.Text))
            {
                return;
            }

            double num1 = double.Parse(NumInput1.Text);
            double num2 = double.Parse(NumInput2.Text);
            double? result = null;

            string btnClicked = ((Button)sender).Content as string;
            switch (btnClicked) // Är c# 8.0 ute än? Nya switchen verkar mycket bättre :)
            {
                case "+":
                    LabelResultName.Content = "Summa";
                    result = num1 + num2;
                    break;
                case "-":
                    LabelResultName.Content = "Differens";
                    result = num1 - num2;
                    break;
                case "*":
                    LabelResultName.Content = "Produkt";
                    result = num1 * num2;
                    break;
                case "/":
                    LabelResultName.Content = "Kvot";
                    result = num1 / num2;
                    break;
            }

            TxtBoxResult.Text =  Math.Round(result.Value, 6).ToString();
        }
    }
}
