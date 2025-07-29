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
    /// Interaction logic for AdminSidebarControl.xaml
    /// </summary>
    public partial class AdminSidebarControl : UserControl
    {
        public event Action<string> Navigation;

        public AdminSidebarControl()
        {
            InitializeComponent();
        }

        private void StatisticClick(object sender, RoutedEventArgs e)
        {
            Navigation.Invoke(DashboardNavigation.ADMIN_STATISTIC);
        }

        private void ProfileClick(object sender, RoutedEventArgs e)
        {
            Navigation.Invoke(DashboardNavigation.ADMIN_PROFILE);
        }

        private void AccountClick(object sender, RoutedEventArgs e)
        {
            Navigation.Invoke(DashboardNavigation.ADMIN_ACCOUNT);
        }
    }
}
