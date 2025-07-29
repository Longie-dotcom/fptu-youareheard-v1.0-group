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
using YouAreHeard.ViewModels;

namespace YouAreHeard.Views
{
    /// <summary>
    /// Interaction logic for AdminDoctorScheduleDetail.xaml
    /// </summary>
    public partial class AdminDoctorScheduleDetail : Window
    {
        private readonly AdminDoctorScheduleDetailViewModel adminDoctorScheduleDetailViewModel;
        public AdminDoctorScheduleDetail(int userId)
        {
            InitializeComponent();
            adminDoctorScheduleDetailViewModel = new AdminDoctorScheduleDetailViewModel(userId);
            DataContext = adminDoctorScheduleDetailViewModel;
        }
    }
}
