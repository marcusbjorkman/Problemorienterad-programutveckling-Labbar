using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Uppgift15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string VowelsUpper = "AEIOUYÅÄÖ";
        private const string VowelsLower = "aeiouyåäö";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBoxInput.Text))
            {
                MessageBox.Show("Mata in en text först!");
                return;
            }

            if (sender == BtnConvertJibberish)
            {
                TxtBlockOutput.Text = GetJibberish(TxtBoxInput.Text);
                LblConvertedLang.Content = "Rotvälska";
            }
            else if (sender == BtnConvertRovare)
            {
                TxtBlockOutput.Text = GetRovare(TxtBoxInput.Text);
                LblConvertedLang.Content = "Rövarspråk";
            }

            TxtBlockNumVowels.Text = $"{NumberOfVowels(TxtBoxInput.Text)}";
        }

        private string GetRovare(string input)
        {
            string result = string.Empty;
            foreach (char c in input)
            {
                if (IsVowel(c) || !char.IsLetter(c))
                {
                    result += c;
                    continue;
                }

                result += c + "o" + c.ToString().ToLower();
            }

            return result;
        }

        private string GetJibberish(string input)
        {
            var regexUpperVowel = new Regex($"[{VowelsUpper}]");
            var regexLowerVowel = new Regex($"[{VowelsLower}]");

            string result = regexUpperVowel.Replace(input, "Ö");
            result = regexLowerVowel.Replace(result, "ö");

            return result;
        }

        private int NumberOfVowels(string input)
        {
            return input.Count(c => IsVowel(c));
        }

        private bool IsVowel(char c)
        {
            return VowelsUpper.Contains(c.ToString().ToUpper());
        }
    }
}
