using CandyCalculator.Enums;
using CandyCalculator.Models;
using CandyCalculator.Utils;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace CandyCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CandyDivider _calculator = new CandyDivider();
        private readonly ObservableCollection<Person> _peopleList = new ObservableCollection<Person>();

        private const string SaveFilePath = @"C:\temp\CandyPeople.txt";

        public MainWindow()
        {
            InitializeComponent();

            var existingPeople = FileOperations.Deserialize<List<Person>>(SaveFilePath);
            if (existingPeople != null)
            {
                foreach (var p in existingPeople)
                {
                    _peopleList.Add(p);
                    _calculator.AddPerson(p);
                }
            }

            ListBoxPersons.ItemsSource = _peopleList;
        }

        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBoxName.Text)
                || string.IsNullOrEmpty(TxtBoxAge.Text)
                || !int.TryParse(TxtBoxAge.Text, out int age))
            {
                MessageBox.Show("Fyll i namn och ålder ordentligt!");
                return;
            }

            var person = new Person
            {
                Firstname = TxtBoxName.Text,
                Age = age
            };

            _calculator.AddPerson(person);
            _peopleList.Add(person);

            TxtBoxName.Clear();
            TxtBoxAge.Clear();
        }

        private void BtnDivide_Click(object sender, RoutedEventArgs e)
        {
            if (!_peopleList.Any())
            {
                MessageBox.Show("Lägg till en person eller två först!");
                return;
            }
            if (string.IsNullOrEmpty(TxtBoxCandyAmount.Text)
                || !int.TryParse(TxtBoxCandyAmount.Text, out int candies))
            {
                MessageBox.Show("Mata in hur många godisar du vill fördela!");
                return;
            }

            DivideCandyMethod divideMethod = DivideCandyMethod.ByOrder;
            if (RadioBtnByAge.IsChecked.Value)
            {
                divideMethod = DivideCandyMethod.ByAge;
            }
            else if (RadioBtnByName.IsChecked.Value)
            {
                divideMethod = DivideCandyMethod.ByName;
            }

            _calculator.NumberOfCandies = candies;
            _calculator.DivideCandy(divideMethod);
            ListBoxPersons.Items.Refresh();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var people = _calculator.GetPeople();
            if (people != null && people.Any())
            {
                FileOperations.Serialize(people, SaveFilePath);
            }
        }
    }
}
