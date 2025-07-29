using Services.Interface;
using Services.Implementation;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using YouAreHeard.Models;
using BussinessObjects;
using YouAreHeard.Views;
using Enums;

namespace YouAreHeard.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly IUserService _userService;
        public event PropertyChangedEventHandler PropertyChanged;

        private LoginModel _login = new LoginModel();

        public string Email
        {
            get => _login.Email;
            set
            {
                if (_login.Email != value)
                {
                    _login.Email = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => _login.Password;
            set
            {
                if (_login.Password != value)
                {
                    _login.Password = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(param => Login());
            _userService = new UserService();
        }

        private void Login()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Vui lòng nhập email và mật khẩu.");
                return;
            }

            User user = new User();

            try
            {
                user = _userService.Login(Email, Password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng nhập không thành công");
                return;
            }

            if (user != null)
            {
                switch (user.RoleId)
                {
                    case RoleEnum.DOCTOR_ROLE_ID:
                        var doctorDashboard = new DoctorDashboard(user.UserId);
                        doctorDashboard.Show();
                        break;
                    case RoleEnum.ADMIN_ROLE_ID:
                        var adminDashboard = new AdminDashboard(user.UserId);
                        adminDashboard.Show();
                        break;
                    case RoleEnum.STAFF_ROLE_ID:
                        var staffDashboard = new StaffDashboard(user.UserId);
                        staffDashboard.Show();
                        break;
                }
            }

            // Close the login window
            foreach (Window window in Application.Current.Windows)
            {
                if (window is MainWindow)
                {
                    window.Close();
                    break;
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
