using Services.Interface;
using Services.Implementation;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using YouAreHeard.Models;
using BussinessObjects;
using System.Windows.Input;
using System;
using Enums;
using System.Windows;

namespace YouAreHeard.ViewModels
{
    public class DoctorTestBoxViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ITestTypeService _testTypeService;
        private readonly ITestStageService _testStageService;
        private readonly ITestMetricService _testMetricService;
        private readonly IHIVStatusService _hivStatusService;
        private readonly ILabResultService _labResultService;
        private readonly ITestMetricValueService _testMetricValueService;
        private readonly IPatientProfileService _patientProfileService;

        public AppointmentModel Appointment { get; }

        public PatientProfileModel PatientProfile => Appointment?.PatientProfile;

        private ObservableCollection<TestTypeModel> _testTypes;
        public ObservableCollection<TestTypeModel> TestTypes
        {
            get => _testTypes;
            set { _testTypes = value; OnPropertyChanged(); }
        }

        private ObservableCollection<TestStageModel> _testStages;
        public ObservableCollection<TestStageModel> TestStages
        {
            get => _testStages;
            set { _testStages = value; OnPropertyChanged(); }
        }

        private ObservableCollection<TestMetricModel> _allMetrics;
        public ObservableCollection<TestMetricModel> AllMetrics
        {
            get => _allMetrics;
            set { _allMetrics = value; OnPropertyChanged(); }
        }

        private ObservableCollection<TestMetricModel> _selectedMetrics = new();
        public ObservableCollection<TestMetricModel> SelectedMetrics
        {
            get => _selectedMetrics;
            set { _selectedMetrics = value; OnPropertyChanged(); }
        }

        private ObservableCollection<HIVStatusModel> _hivStatuses;
        public ObservableCollection<HIVStatusModel> HIVStatuses
        {
            get => _hivStatuses;
            set { _hivStatuses = value; OnPropertyChanged(); }
        }

        public string Notes
        {
            get => _notes;
            set { _notes = value; OnPropertyChanged(); }
        }
        private string _notes;

        public TestTypeModel SelectedTestType
        {
            get => _selectedTestType;
            set
            {
                _selectedTestType = value;
                OnPropertyChanged();
                LoadTestMetrics();
            }
        }

        private TestTypeModel _selectedTestType;

        public TestStageModel SelectedTestStage
        {
            get => _selectedTestStage;
            set { _selectedTestStage = value; OnPropertyChanged(); }
        }
        private TestStageModel _selectedTestStage;

        public HIVStatusModel SelectedHIVStatus
        {
            get => _selectedHIVStatus;
            set { _selectedHIVStatus = value; OnPropertyChanged(); }
        }
        private HIVStatusModel _selectedHIVStatus;

        public ICommand ConfirmCommand { get; }

        public DoctorTestBoxViewModel(AppointmentModel appointment)
        {
            Appointment = appointment;

            _testTypeService = new TestTypeService();
            _testStageService = new TestStageService();
            _testMetricService = new TestMetricService();
            _hivStatusService = new HIVStatusService();
            _labResultService = new LabResultService();
            _testMetricValueService = new TestMetricValueService();
            _patientProfileService = new PatientProfileService();

            ConfirmCommand = new RelayCommand(param => ConfirmTest());
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            var testTypes = _testTypeService.GetAll();
            TestTypes = new ObservableCollection<TestTypeModel>(
                testTypes.Select(tt => new TestTypeModel
                {
                    TestTypeId = tt.TestTypeId,
                    TestTypeName = tt.TestTypeName ?? ErrorIndication.UNKNOWN
                })
            );

            var testStages = _testStageService.GetAll();
            TestStages = new ObservableCollection<TestStageModel>(
                testStages.Select(ts => new TestStageModel
                {
                    TestStageId = ts.TestStageId,
                    TestStageName = ts.TestStageName ?? ErrorIndication.UNKNOWN
                })
            );

            var metrics = _testMetricService.GetAll();
            AllMetrics = new ObservableCollection<TestMetricModel>(
                metrics.Select(m => new TestMetricModel
                {
                    TestMetricID = m.TestMetricId,
                    TestMetricName = m.TestMetricName ?? ErrorIndication.UNKNOWN,
                    UnitName = m.UnitName ?? ErrorIndication.UNKNOWN
                })
            );

            var hivStatuses = _hivStatusService.GetAll();
            HIVStatuses = new ObservableCollection<HIVStatusModel>(
                hivStatuses.Select(h => new HIVStatusModel
                {
                    HIVStatusID = h.HivstatusId,
                    HIVStatusName = h.HivstatusName ?? ErrorIndication.UNKNOWN
                })
            );
        }


        private void LoadTestMetrics()
        {
            if (SelectedTestType?.TestTypeId != null)
            {
                var metrics = _testMetricService.GetTestMetricsByTypeId(SelectedTestType.TestTypeId);
                SelectedMetrics = new ObservableCollection<TestMetricModel>(
                    metrics.Select(m => new TestMetricModel
                    {
                        TestMetricID = m.TestMetricId,
                        TestMetricName = m.TestMetricName ?? "Unknown",
                        UnitName = m.UnitName ?? "Unknown"
                    })
                );
            }
            else
            {
                SelectedMetrics.Clear();
            }
        }

        private void ConfirmTest()
        {
            try
            {
                if (SelectedTestStage == null || SelectedTestType == null)
                {
                    MessageBox.Show("Vui lòng chọn loại và giai đoạn xét nghiệm.", "Thiếu thông tin",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var labResult = new LabResult
                {
                    DoctorId = Appointment?.DoctorId,
                    PatientId = Appointment?.PatientId,
                    TestStageId = SelectedTestStage?.TestStageId,
                    TestTypeId = SelectedTestType?.TestTypeId,
                    Notes = Notes,
                    Date = DateTime.Now,
                    IsCustomized = false
                };

                var valueEntities = SelectedMetrics
                    .Where(m => !string.IsNullOrWhiteSpace(m.Value))
                    .Select(m => new TestMetricValue
                    {
                        TestMetricId = m.TestMetricID,
                        Value = m.Value
                    })
                    .ToList();

                if (valueEntities.Count > 0)
                {
                    LabResult result = _labResultService.Add(labResult);
                    valueEntities.ForEach(v => v.LabResultId = result.LabResultId);
                    _testMetricValueService.AddRange(valueEntities);

                    MessageBox.Show("Đã lưu kết quả xét nghiệm!", "Thành công",
                                    MessageBoxButton.OK, MessageBoxImage.Information);
                } 
                else
                {
                    MessageBox.Show("Kết quả xét nghiệm không được trống!", "Không thành công",
                                    MessageBoxButton.OK, MessageBoxImage.Error);
                }

                if (SelectedHIVStatus != null)
                {
                    _patientProfileService.UpdateHIVStatus(Appointment.PatientId, SelectedHIVStatus.HIVStatusID);
                    MessageBox.Show($"Trạng thái HIV của bệnh nhân đã được cập nhật thành {SelectedHIVStatus.HIVStatusName}", "Thành công",
                                    MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu kết quả: " + ex.Message,
                                "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
