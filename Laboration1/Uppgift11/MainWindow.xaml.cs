using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Uppgift11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random _random;

        public MainWindow()
        {
            InitializeComponent();
            _random = new Random();
        }

        private void NumInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnBadLuck_Click(object sender, RoutedEventArgs e)
        {
            if (sender == BtnLessBadLuck)
            {
                if (ProgressbarLuck.Value <= 0)
                    return;

                ProgressbarLuck.Value -= 5;
            }
            else
            {
                if (ProgressbarLuck.Value >= 100)
                    return;

                ProgressbarLuck.Value += 5;
            }

            LblProgress.Content = $"{ProgressbarLuck.Value}%";
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NumInput.Text))
            {
                MessageBox.Show("Ange antal försök!");
                return;
            }

            int numTries = int.Parse(NumInput.Text);
            int numRightWay = 0;
            int numWrongWay = 0;

            for (int i = 0; i < numTries; i++)
            {
                double random = _random.NextDouble();

                if (random >= ProgressbarLuck.Value / 100)
                {
                    numRightWay++;
                }
                else
                {
                    numWrongWay++;
                }
            }

            LblNumRightWay.Content = numRightWay;
            LblNumWrongWay.Content = numWrongWay;
        }
    }
}
