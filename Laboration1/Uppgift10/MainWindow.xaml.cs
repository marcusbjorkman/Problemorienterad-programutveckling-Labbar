using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Uppgift10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Random _random;

        private int? CurrentRandomInt;
        private int NumTries = 0;

        private const string GuessedRightMsg = "Hurra! Du gissade rätt efter {0} försök.";
        private const string WayOffMsg = "Oj, du är inte ens nära. Du gissade alldeles för {0}.";
        private const string CloserMsg = "Inte långt ifrån! Du gissade för {0}.";
        private const string High = "högt";
        private const string Low = "lågt";

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

        private void BtnRandom_Click(object sender, RoutedEventArgs e)
        {
            CurrentRandomInt = _random.Next(0, 1000);
            BtnGuess.IsEnabled = true;
            NumTries = 0;
        }

        private void BtnGuess_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NumInput.Text))
            {
                MessageBox.Show("Fyll i din gissning!");
                return;
            }

            NumTries++;
            int guess = int.Parse(NumInput.Text);

            string returnMsg;
            if (guess == CurrentRandomInt)
            {
                returnMsg = string.Format(GuessedRightMsg, NumTries);
            }
            else if (guess < CurrentRandomInt)
            {
                returnMsg = (CurrentRandomInt - guess) > 100
                    ? string.Format(WayOffMsg, Low)
                    : string.Format(CloserMsg, Low);
            }
            else
            {
                returnMsg = (guess - CurrentRandomInt) > 100
                    ? string.Format(WayOffMsg, High)
                    : string.Format(CloserMsg, High);
            }

            TxtBlockResult.Text = returnMsg;
        }
    }
}
