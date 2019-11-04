using System;
using System.Collections.Generic;
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

namespace Uppgift3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string BtnClicked = "Klickad";
        private const string BtnNotClicked = "Oklickad";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLeft_Click(object sender, RoutedEventArgs e)
        {
            if ((string)BtnLeft.Content == BtnClicked)
            {
                return;
            }

            BtnLeft.Content = BtnClicked;
            BtnRight.Content = BtnNotClicked;
        }

        private void BtnRight_Click(object sender, RoutedEventArgs e)
        {
            if ((string)BtnRight.Content == BtnClicked)
            {
                return;
            }

            BtnRight.Content = BtnClicked;
            BtnLeft.Content = BtnNotClicked;
        }
    }
}
