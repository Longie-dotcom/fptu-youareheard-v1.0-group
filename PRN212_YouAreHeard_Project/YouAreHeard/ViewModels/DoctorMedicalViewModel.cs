using Services.Interface;
using Services.Implementation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using YouAreHeard.Models;
using BussinessObjects;
using System.Windows.Input;
using YouAreHeard.Views;

namespace YouAreHeard.ViewModels
{
    public class DoctorMedicalViewModel : INotifyPropertyChanged
    {
        private readonly IAppointmentService _appointmentService;
        private readonly int _doctorId;

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

        public PatientProfileModel SelectedPatientProfile => SelectedAppointment?.PatientProfile;
        public string SelectedReason => SelectedAppointment?.Reason;
        public string SelectedNote => SelectedAppointment?.Notes;

        public ICommand StartLabTestCommand { get; }
        public ICommand StartTreatmentCommand { get; }

        public DoctorMedicalViewModel(int doctorId)
        {
            _doctorId = doctorId;
            _appointmentService = new AppointmentService();
            StartLabTestCommand = new RelayCommand(param => StartLabTest(param));
            StartTreatmentCommand = new RelayCommand(param => StartTreatment(param));
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            var appointments = _appointmentService.GetAllCurrentAppointmentsWithDetails(_doctorId);

            var mapped = appointments.Select(appt => new AppointmentModel
            {
                PatientId = appt.PatientId ?? 0,
                DoctorId = appt.DoctorId ?? 0,
                AppointmentID = appt.AppointmentId,
                QueueNumber = appt.QueueNumber ?? 0,
                ScheduleDate = appt.DoctorSchedule.Date?.ToString("yyyy-MM-dd") ?? "",
                ScheduleTime = appt.DoctorSchedule.StartTime?.ToString(@"hh\:mm") ?? "",
                Location = appt.DoctorSchedule.Location ?? "",
                Reason = appt.Reason ?? "",
                Notes = appt.DoctorNotes ?? "",
                PatientProfile = new PatientProfileModel
                {
                    Name = appt.Patient?.Name ?? "",
                    Age = appt.Patient?.Dob.HasValue == true
                        ? ((int)((DateTime.Now - appt.Patient.Dob.Value.ToDateTime(TimeOnly.MinValue)).TotalDays / 365)).ToString()
                        : "",
                    Gender = appt.Patient?.PatientProfile?.Gender ?? "",
                    Phone = appt.Patient?.Phone ?? "",
                    Weight = appt.Patient?.PatientProfile?.Weight?.ToString() ?? "",
                    Height = appt.Patient?.PatientProfile?.Height?.ToString() ?? "",
                    Pregnancy = appt.Patient?.PatientProfile?.PregnancyStatus?.PregnancyStatusName ?? ""
                }
            }).ToList();

            Appointments = new ObservableCollection<AppointmentModel>(mapped);
        }

        private void StartLabTest(object param)
        {
            if (param is AppointmentModel appointment)
            {
                SelectedAppointment = appointment;
                var testWindow = new DoctorTest(appointment);
                testWindow.Show();
            }
        }

        private void StartTreatment(object param)
        {
            if (param is AppointmentModel appointment)
            {
                SelectedAppointment = appointment;
                var doctorTreatment = new DoctorTreatment(appointment);
                doctorTreatment.Show();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
