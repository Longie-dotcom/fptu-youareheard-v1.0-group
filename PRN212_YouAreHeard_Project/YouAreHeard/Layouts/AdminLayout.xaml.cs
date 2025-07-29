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
using YouAreHeard.UserControls;

namespace YouAreHeard.Layouts
{
    /// <summary>
    /// Interaction logic for AdminLayout.xaml
    /// </summary>
    public partial class AdminLayout : UserControl
    {
        private readonly int adminId;
        public AdminLayout(int adminId)
        {
            InitializeComponent();
            this.adminId = adminId;
            AdminSidebarControl.Navigation += Navigation;
            DoctorHeaderControl.Navigation += Navigation;
        }

        private void Navigation(string view)
        {
            switch (view)
            {
                case DashboardNavigation.ADMIN_STATISTIC:
                    MainContentArea.Content = new AdminStatisticControl(adminId);
                    break;
                case DashboardNavigation.ADMIN_PROFILE:
                    MainContentArea.Content = new AdminProfileControl(adminId);
                    break;
                case DashboardNavigation.ADMIN_ACCOUNT:
                    MainContentArea.Content = new AdminAccountControl(adminId);
                    break;
                case DashboardNavigation.LOGOUT:
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();

                    Window parent = Window.GetWindow(this);
                    if (mainWindow != null)
                    {
                        parent.Close();
                    }
                    break;
            }
        }
    }
}
