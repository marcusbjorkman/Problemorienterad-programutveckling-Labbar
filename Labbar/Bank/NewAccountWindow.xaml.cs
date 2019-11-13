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
using System.Windows.Shapes;

namespace Bank
{
    /// <summary>
    /// Interaction logic for NewAccountWindow.xaml
    /// </summary>
    public partial class NewAccountWindow : Window
    {
        public NewAccountWindow()
        {
            InitializeComponent();
        }

        private void RadioBtnChecking_Checked(object sender, RoutedEventArgs e)
        {
            if (TxtBoxCredit != null)
            {
                TxtBoxCredit.IsEnabled = true;
            }
        }

        private void RadioBtnChecking_Unchecked(object sender, RoutedEventArgs e)
        {
            TxtBoxCredit.IsEnabled = false;
        }
    }
}
