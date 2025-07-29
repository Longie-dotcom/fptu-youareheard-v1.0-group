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
using YouAreHeard.Layouts;

namespace YouAreHeard.Views
{
    /// <summary>
    /// Interaction logic for DoctorDashboard.xaml
    /// </summary>
    public partial class DoctorDashboard : Window
    {
        public DoctorDashboard(int userId)
        {
            InitializeComponent();
            DoctorLayout.Content = new DoctorLayout(userId);
        }
    }
}
