using Services.Interface;
using Services.Implementation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using YouAreHeard.Models;
using BussinessObjects;
using System.Windows.Input;
using YouAreHeard.Views;
using System.Data;
using Enums;

namespace YouAreHeard.ViewModels
{
    public class DoctorAppointmentViewModel : INotifyPropertyChanged
    {
        private readonly IAppointmentService _appointmentService;
        private readonly int doctorId;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<AppointmentModel> _appointments;
        private AppointmentModel _selectedAppointment;

        public ObservableCollection<AppointmentModel> Appointments
        {
            get => _appointments;
            set
            {
                _appointments = value;
                OnPropertyChanged();
            }
        }
        public AppointmentModel NextAppointment { get; set; }

        public AppointmentModel SelectedAppointment
        {
            get => _selectedAppointment;
            set
            {
                _selectedAppointment = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedPatientProfile));
                OnPropertyChanged(nameof(SelectedReason));
                OnPropertyChanged(nameof(SelectedNote));
            }
        }

        public PatientProfileModel SelectedPatientProfile => SelectedAppointment.PatientProfile;
        public string SelectedReason => SelectedAppointment.Reason;
        public string SelectedNote => SelectedAppointment.Notes;

        public ICommand ShowPatientCommand { get; }

        public DoctorAppointmentViewModel(int doctorId)
        {
            this.doctorId = doctorId;
            _appointmentService = new AppointmentService();
            ShowPatientCommand = new RelayCommand(param => ShowPatient(param));
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            var appointmentEntities = _appointmentService.GetAllCurrentAppointmentsWithDetails(doctorId);

            var mappedAppointments = appointmentEntities.Select(appt => new AppointmentModel
            {
                PatientId = appt.PatientId ?? 0,
                DoctorId = appt.DoctorId ?? 0,
                AppointmentID = appt.AppointmentId,
                QueueNumber = appt.QueueNumber ?? 0,
                ScheduleDate = appt.DoctorSchedule.Date?.ToString("yyyy-MM-dd") ?? "",
                ScheduleTime = appt.DoctorSchedule?.StartTime?.ToString(@"hh\:mm") ?? "",
                Location = appt.DoctorSchedule?.Location ?? "",
                Reason = appt.Reason ?? "",
                Notes = appt.Notes ?? "",
                PatientProfile = new PatientProfileModel
                {
                    Name = appt.IsAnonymous == true ? ConstraintWord.ANONYMOUS : appt.Patient?.Name ?? "",
                    Age = appt.Patient?.Dob != null
                    ? ((int)((DateTime.Now - appt.Patient.Dob.Value.ToDateTime(TimeOnly.MinValue)).TotalDays / 365)).ToString()
                    : "",
                    Gender = appt.Patient?.PatientProfile?.Gender ?? "",
                    Phone = appt.IsAnonymous == true ? ConstraintWord.ANONYMOUS : appt.Patient?.Phone ?? "",
                    Weight = appt.Patient?.PatientProfile?.Weight?.ToString() ?? "",
                    Height = appt.Patient?.PatientProfile?.Height?.ToString() ?? "",
                    Pregnancy = appt.Patient?.PatientProfile?.PregnancyStatus?.PregnancyStatusName ?? ""
                }
            }).ToList();
            if (mappedAppointments.Count > 0)
            {
                NextAppointment = mappedAppointments[0];
            }
            Appointments = new ObservableCollection<AppointmentModel>(mappedAppointments);
        }

        private void ShowPatient(object param)
        {
            if (param is AppointmentModel appointment)
            {
                SelectedAppointment = appointment;
                var detailWindow = new AppointmentDetail(appointment);
                detailWindow.Show();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
