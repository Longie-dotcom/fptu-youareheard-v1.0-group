using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using YouAreHeard.Models;
using Services.Interface;
using Services.Implementation;
using BussinessObjects;
using System;
using Enums;
using System.Windows;

namespace YouAreHeard.ViewModels
{
    public class StaffVerifyViewModel : INotifyPropertyChanged
    {
        private readonly IAppointmentService _appointmentService;

        public event PropertyChangedEventHandler PropertyChanged;

        private string _search;
        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                OnPropertyChanged();
            }
        }

        private FoundAppointmentModel _foundAppointment;
        public FoundAppointmentModel FoundAppointment
        {
            get => _foundAppointment;
            set
            {
                _foundAppointment = value;
                OnPropertyChanged();
            }
        }

        public ICommand VerifyCommand { get; }

        public StaffVerifyViewModel()
        {
            _appointmentService = new AppointmentService();
            VerifyCommand = new RelayCommand(param => VerifyAppointment(), param => !string.IsNullOrWhiteSpace(Search));
        }

        private void VerifyAppointment()
        {
            try
            {
                var appt = _appointmentService.GetAppointmentByOrderCode(Search);
                if (appt != null)
                {
                    FoundAppointment = new FoundAppointmentModel
                    {
                        DoctorName = appt.Doctor?.Name ?? ErrorIndication.UNKNOWN,
                        PatientName = appt.Patient?.Name ?? ErrorIndication.UNKNOWN,
                        PatientPhone = appt.Patient?.Phone ?? ErrorIndication.UNKNOWN,
                        ScheduleDate = appt.DoctorSchedule?.Date?.ToString("yyyy-MM-dd") ?? ErrorIndication.UNKNOWN,
                        ScheduleTime = $"{appt.DoctorSchedule?.StartTime?.ToString(@"hh:mm")} - {appt.DoctorSchedule?.EndTime?.ToString(@"hh:mm")}",
                        Location = appt.DoctorSchedule?.Location ?? ErrorIndication.UNKNOWN,
                        IsOnline = appt.IsOnline == true ? ConstraintWord.ONLINE : ConstraintWord.OFFLINE,
                        QueueNumber = appt.QueueNumber ?? 0
                    };
                }
                else
                {
                    FoundAppointment = null;
                    MessageBox.Show("Không tìm thấy thông tin!", "Không tìm thấy", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                // TODO: handle/log error
                FoundAppointment = null;
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
