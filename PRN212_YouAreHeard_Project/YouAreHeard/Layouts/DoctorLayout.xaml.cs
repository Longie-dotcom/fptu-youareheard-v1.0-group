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
    /// Interaction logic for DoctorLayout.xaml
    /// </summary>
    public partial class DoctorLayout : UserControl
    {
        public readonly int doctorId;

        public DoctorLayout(int doctorId)
        {
            InitializeComponent();
            this.doctorId = doctorId;
            DoctorSidebarControl.Navigation += Navigation;
            DoctorHeaderControl.Navigation += Navigation;
        }

        private void Navigation(string view)
        {
            switch (view)
            {
                case DashboardNavigation.DOCTOR_APPOINTMENT:
                    MainContentArea.Content = new DoctorAppointmentControl(doctorId);
                    break;
                case DashboardNavigation.DOCTOR_TEST:
                    MainContentArea.Content = new DoctorTestControl(doctorId);
                    break;
                case DashboardNavigation.DOCTOR_TREATMENT:
                    MainContentArea.Content = new DoctorTreatmentControl(doctorId);
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
