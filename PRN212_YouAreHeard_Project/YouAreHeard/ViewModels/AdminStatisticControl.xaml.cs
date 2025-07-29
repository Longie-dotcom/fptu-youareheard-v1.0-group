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
    /// Interaction logic for AdminStatisticControl.xaml
    /// </summary>
    public partial class AdminStatisticControl : UserControl
    {
        private readonly AdminStatisticViewModel _adminStatisticViewModel;

        public AdminStatisticControl(int adminId)
        {
            InitializeComponent();
            _adminStatisticViewModel = new AdminStatisticViewModel();
            DataContext = _adminStatisticViewModel;
        }
    }
}
