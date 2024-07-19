using ClientApp.MVVM.Models;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Threading.Tasks;

namespace ClientApp.MVVM.ViewModels
{
    public class UpdateControlViewModel : ViewModelBase
    {
        public UpdateControlViewModel() { }

        private string? _searchPatientId;
        public string? SearchPatientId
        {
            get => _searchPatientId;
            set => this.RaiseAndSetIfChanged(ref _searchPatientId, value);
        }

        private string? _fullNamePatient;
        public string? FullNamePatient
        {
            get => _fullNamePatient;
            set => this.RaiseAndSetIfChanged(ref _fullNamePatient, value);
        }

        private GenderType? _genderType;
        public GenderType? GenderType
        {
            get => _genderType;
            set => this.RaiseAndSetIfChanged(ref _genderType, value);
        }

        private DateTime? _patientBirthDay;
        public DateTime? PatientBirthDay
        {
            get => _patientBirthDay;
            set => this.RaiseAndSetIfChanged(ref _patientBirthDay, value);
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
        }

        private string _updateInfo;
        public string UpdateInfo
        {
            get => _updateInfo;
            set => this.RaiseAndSetIfChanged(ref _updateInfo, value);
        }

        public async void UpdatePatient()
        {
            try
            {
                ErrorMessage = string.Empty;

                if (string.IsNullOrEmpty(_searchPatientId))
                {
                    ErrorMessage = "GUID пустой";
                    return;
                }

                if (Validation.IsStringGuid(_searchPatientId))
                {
                    string existPatient = await App.ApiServiceInstance.GetPatientByIdAsync(Guid.Parse(_searchPatientId));
                    if (!string.IsNullOrEmpty(existPatient))
                    {
                        Patient patient = JsonConvert.DeserializeObject<Patient>(existPatient);
                        if (patient != null)
                        {
                            if (_patientBirthDay != null)
                                patient.Birthday = _patientBirthDay.Value;
                            if (_genderType != null)
                                patient.Gender = (int)_genderType.Value;
                            if (!string.IsNullOrEmpty(_fullNamePatient))
                                patient.Fullname = _fullNamePatient;

                            string result = await App.ApiServiceInstance.UpdatePatientAsync(patient);
                            UpdateInfo = result;
                        }
                    }
                    else
                    {
                        ErrorMessage = "Пациент не найден.";
                    }
                }
                else
                {
                    ErrorMessage = "Неверный формат GUID.";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Ошибка: {ex.Message}";
            }
        }
    }
}
