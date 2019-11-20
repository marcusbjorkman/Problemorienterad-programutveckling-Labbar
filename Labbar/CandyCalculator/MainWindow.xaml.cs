using CandyCalculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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

namespace CandyCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CandyDivider _calculator = new CandyDivider();

        private ObservableCollection<Person> peopleList = new ObservableCollection<Person>();

        public MainWindow()
        {
            InitializeComponent();
            ListBoxPersons.ItemsSource = peopleList;
        }

        private void BtnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtBoxName.Text)
                || string.IsNullOrWhiteSpace(TxtBoxAge.Text)
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
            peopleList.Add(person);
        }
    }
}
