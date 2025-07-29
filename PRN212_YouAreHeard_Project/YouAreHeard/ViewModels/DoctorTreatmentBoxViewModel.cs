using BussinessObjects;
using Enums;
using Services.Implementation;
using Services.Interface;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using YouAreHeard.Models;

namespace YouAreHeard.ViewModels
{
    public class DoctorTreatmentBoxViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IArvregimanService _regimenService;
        private readonly IMedicationCombinationService _medicationCombinationService;
        private readonly ITreatmentPlanService _treatmentPlanService;
        private readonly IPillRemindTimeService _pillRemindTimeService;

        public AppointmentModel Appointment { get; }

        private ObservableCollection<Arvregiman> _regimens;
        public ObservableCollection<Arvregiman> Regimens
        {
            get => _regimens;
            set { _regimens = value; OnPropertyChanged(); }
        }

        private Arvregiman _selectedRegimen;
        public Arvregiman SelectedRegimen
        {
            get => _selectedRegimen;
            set
            {
                _selectedRegimen = value;
                OnPropertyChanged();
                LoadPillRemindPlanFromSelectedRegimen();
            }
        }

        private ObservableCollection<PillRemindTimeModel> _medications;
        public ObservableCollection<PillRemindTimeModel> Medications
        {
            get => _medications;
            set { _medications = value; OnPropertyChanged(); }
        }

        private string _notes;
        public string Notes
        {
            get => _notes;
            set { _notes = value; OnPropertyChanged(); }
        }
        public List<int> Hours { get; }
        public List<int> Minutes { get; }

        public ICommand SaveTreatmentCommand { get; }

        public DoctorTreatmentBoxViewModel(AppointmentModel appointment)
        {
            Appointment = appointment;

            _regimenService = new ArvregimanService();
            _treatmentPlanService = new TreatmentPlanService();
            _medicationCombinationService = new MedicationCombinationService();
            _pillRemindTimeService = new PillRemindTimeService();

            Hours = Enumerable.Range(0, 24).ToList();
            Minutes = Enumerable.Range(0, 60).ToList();
            SaveTreatmentCommand = new RelayCommand(param => SaveTreatment());

            LoadInitialData();
        }

        private void LoadInitialData()
        {
            var allRegimens = _regimenService.GetAll();
            Regimens = new ObservableCollection<Arvregiman>(allRegimens);
        }

        private void LoadPillRemindPlanFromSelectedRegimen()
        {
            if (SelectedRegimen != null)
            {
                var combinations = _medicationCombinationService.GetByRegimenId(SelectedRegimen.RegimenId);

                Medications = new ObservableCollection<PillRemindTimeModel>(
                    combinations.Select(c => new PillRemindTimeModel
                    {
                        MedicationId = c.MedicationId,
                        MedicationName = c.Medication?.MedicationName ?? ErrorIndication.UNKNOWN,
                        DosageMetric = c.Medication?.DosageMetric ?? "",
                        Frequency = c.Frequency,
                        RemindEntries = Enumerable.Range(0, c.Frequency ?? 1)
                            .Select(i => new PillRemindEntryModel
                            {
                                Dosage = c.Dosage ?? 0,
                                Hour = 8,
                                Minute = 0
                            })
                            .ToList(),
                        Notes = ""
                    })
                );
            }
            else
            {
                Medications = new ObservableCollection<PillRemindTimeModel>();
            }
        }

        private void SaveTreatment()
        {
            if (SelectedRegimen == null)
            {
                MessageBox.Show("Vui lòng chọn một phác đồ điều trị.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var pillRemindersCheck = new List<PillRemindTime>();

            foreach (var med in Medications)
            {
                if (med.MedicationId == null || med.RemindEntries == null || med.RemindEntries.Count == 0)
                    continue;

                foreach (var remind in med.RemindEntries)
                {
                    pillRemindersCheck.Add(new PillRemindTime
                    {
                        MedicationId = med.MedicationId.Value,
                        Time = remind.Time,
                        DrinkDosage = remind.Dosage,
                        Notes = med.Notes,
                    });
                }
            }
            if (pillRemindersCheck.Count <= 0)
            {
                MessageBox.Show("Phác đồ điều trị không được trống.", "Thiếu thông tin", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            try
            {
                var plan = new TreatmentPlan
                {
                    DoctorId = Appointment.DoctorId,
                    PatientId = Appointment.PatientId,
                    RegimenId = SelectedRegimen.RegimenId,
                    Date = DateTime.Now,
                    Notes = Notes,
                    IsCustomized = false
                };

                // Save treatment plan and get the saved one (with ID)
                var savedPlan = _treatmentPlanService.Add(plan);

                if (savedPlan.TreatmentPlanId <= 0)
                {
                    MessageBox.Show("Không thể lưu kế hoạch điều trị.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Save pill remind times
                var pillReminders = new List<PillRemindTime>();

                foreach (var med in Medications)
                {
                    if (med.MedicationId == null || med.RemindEntries == null || med.RemindEntries.Count == 0)
                        continue;

                    foreach (var remind in med.RemindEntries)
                    {
                        pillReminders.Add(new PillRemindTime
                        {
                            TreatmentPlanId = savedPlan.TreatmentPlanId,
                            MedicationId = med.MedicationId.Value,
                            Time = remind.Time,
                            DrinkDosage = remind.Dosage,
                            Notes = med.Notes,
                        });
                    }
                }

                if (pillReminders.Count > 0)
                {
                    _pillRemindTimeService.AddRange(pillReminders);
                }

                MessageBox.Show("Đã lưu kế hoạch điều trị và lịch uống thuốc!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu kế hoạch: " + ex.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
