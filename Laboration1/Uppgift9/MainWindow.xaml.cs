using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Uppgift9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string ReturnMsg = "Hej {0}! Du är {1} år gammal och får se {2}.";
        private const string AgeRestrictedMsg = "filmer med åldersgräns upp till {0} år{1}";
        private const string OldEnoughMsg = "alla filmer";
        private const string ChildRestrictedMsg = "barntillåtna filmer";
        private const string HasAdultMsg = " eftersom du har en vuxen med dig";
        private const string AdultRedundantMsg = ". Det spelar ingen roll att du har en vuxen med dig";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AgeInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");

            e.Handled = regex.IsMatch(e.Text);
        }

        private void NameInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^a-zA-ZåäöÅÄÖ]+");

            e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnVerify_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameInput.Text) || string.IsNullOrEmpty(AgeInput.Text))
            {
                MessageBox.Show("Ange namn och ålder.");
                return;
            }

            int age = int.Parse(AgeInput.Text);
            string ageRestrictionMsg = null;

            if (age < 7)
            {

                ageRestrictionMsg = RadioWithAdult.IsChecked.Value
                    ? string.Format(AgeRestrictedMsg, 7, HasAdultMsg)
                    : ChildRestrictedMsg;
            }
            else if (age < 11)
            {
                ageRestrictionMsg = RadioWithAdult.IsChecked.Value
                    ? string.Format(AgeRestrictedMsg, 11, HasAdultMsg)
                    : string.Format(AgeRestrictedMsg, 7, null);
            }
            else if (age < 15)
            {
                ageRestrictionMsg = RadioWithAdult.IsChecked.Value
                    ? string.Format(AgeRestrictedMsg, 11, AdultRedundantMsg)
                    : string.Format(AgeRestrictedMsg, 11, null);
            }
            else
            {
                ageRestrictionMsg = OldEnoughMsg;
            }

            TxtBlockResult.Text = string.Format(ReturnMsg, NameInput.Text, age, ageRestrictionMsg);
        }
    }
}
