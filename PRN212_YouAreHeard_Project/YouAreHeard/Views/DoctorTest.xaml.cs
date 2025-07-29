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
using YouAreHeard.Models;
using YouAreHeard.ViewModels;

namespace YouAreHeard.Views
{
    /// <summary>
    /// Interaction logic for DoctorTest.xaml
    /// </summary>
    public partial class DoctorTest : Window
    {
        public DoctorTest(AppointmentModel appointment)
        {
            InitializeComponent();
            DataContext = new DoctorTestBoxViewModel(appointment);
        }

        private void CancelClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
