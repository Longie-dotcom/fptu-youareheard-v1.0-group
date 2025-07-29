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
using YouAreHeard.ViewModels;

namespace YouAreHeard.UserControls
{
    /// <summary>
    /// Interaction logic for AdminProfileControl.xaml
    /// </summary>
    public partial class AdminProfileControl : UserControl
    {
        private readonly AdminProfileViewModel _adminProfileViewModel;

        public AdminProfileControl(int adminId)
        {
            InitializeComponent();
            _adminProfileViewModel = new AdminProfileViewModel();
            DataContext = _adminProfileViewModel;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is AdminProfileViewModel vm)
            {
                vm.Password = (sender as PasswordBox)?.Password;
            }
        }
    }
}
