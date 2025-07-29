using Enums;
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

namespace YouAreHeard.UserControls
{
    /// <summary>
    /// Interaction logic for SidebarControl.xaml
    /// </summary>
    public partial class DoctorSidebarControl : UserControl
    {
        public event Action<string> Navigation;
        public DoctorSidebarControl()
        {
            InitializeComponent();
        }

        private void TreatmentClick(object sender, RoutedEventArgs e)
        {
            Navigation.Invoke(DashboardNavigation.DOCTOR_TREATMENT);
        }

        private void TestClick(object sender, RoutedEventArgs e)
        {
            Navigation.Invoke(DashboardNavigation.DOCTOR_TEST);
        }

        private void AppointmentClick(object sender, RoutedEventArgs e)
        {
            Navigation.Invoke(DashboardNavigation.DOCTOR_APPOINTMENT);
        }
    }
}
