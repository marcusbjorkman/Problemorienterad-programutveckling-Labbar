using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Uppgift12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Får göra om ifall det var viktigt att det skulle ligga i en Array.
        private readonly List<int> _currentNumbers = new List<int>();

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
            ClearAndResetFields();
        }

        private void BtnAddNum_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NumInput.Text))
            {
                MessageBox.Show("Ange ett tal!");
                return;
            }

            int num = int.Parse(NumInput.Text);
            _currentNumbers.Add(num);
            ListBoxArray.ItemsSource = null;
            ListBoxArray.ItemsSource = _currentNumbers;

            double avg = (double)_currentNumbers.Sum() / _currentNumbers.Count;
            TxtBoxResult.Text = $"{Math.Round(avg, 3)}";

            NumInput.Clear();

            if (_currentNumbers.Count >= 5)
            {
                BtnAddNum.IsEnabled = false;
            }
        }

        // "Detta ska du göra i form av en metod". Förstår inte vad man vill åt, BtnClear_Click är väl lika mycket metod...
        private void ClearAndResetFields()
        {
            _currentNumbers.Clear();
            ListBoxArray.ItemsSource = null;
            ListBoxArray.ItemsSource = _currentNumbers;

            TxtBoxResult.Clear();
            NumInput.Clear();
            BtnAddNum.IsEnabled = true;

            NumInput.Focus();
        }
    }
}
