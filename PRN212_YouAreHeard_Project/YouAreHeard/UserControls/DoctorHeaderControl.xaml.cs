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
    /// Interaction logic for DoctorHeaderControl.xaml
    /// </summary>
    public partial class DoctorHeaderControl : UserControl
    {
        public event Action<string> Navigation;

        public DoctorHeaderControl()
        {
            InitializeComponent();
        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            Navigation.Invoke(DashboardNavigation.LOGOUT);
        }
    }
}
