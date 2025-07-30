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
    /// Interaction logic for AppointmentDetail.xaml
    /// </summary>
    public partial class AppointmentDetail : Window
    {
        public AppointmentDetail(AppointmentModel appointment)
        {
            InitializeComponent();
            DataContext = new DoctorTestBoxViewModel(appointment);
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
