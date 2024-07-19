using ClientApp.MVVM.Models;
using ReactiveUI;
using System;

namespace ClientApp.MVVM.ViewModels
{
    public class AddControlViewModel : ViewModelBase
    {
        private string _patientName;
        public string PatientName
        {
            get => _patientName;
            set => this.RaiseAndSetIfChanged(ref _patientName, value);
        }
        private string _patientGender;
        public string PatientGender
        {
            get => _patientGender;
            set => this.RaiseAndSetIfChanged(ref _patientGender, value);
        }

        private DateTime _patientBirthDate;
        public DateTime PatientBirthDate
        {
            get => _patientBirthDate;
            set => this.RaiseAndSetIfChanged(ref _patientBirthDate, value);
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => this.RaiseAndSetIfChanged(ref _errorMessage, value);

        }
        private string _newPatientInformation;

        public string NewPatientInformation
        {
            get => _newPatientInformation;
            set => this.RaiseAndSetIfChanged(ref _newPatientInformation, value);
        }

        public Action ClearValues;

        public AddControlViewModel()
        {

            ClearValues = () =>
            {
                ErrorMessage = string.Empty;
                PatientName = string.Empty;

            };
        }
        public async void AddPatient()
        {
            try
            {
                if (PatientBirthDate == null)
                {
                    ErrorMessage = "Дата рождения не может быть пустой";
                    throw new Exception("Дата рождения не может быть пустой");
                }

                if (string.IsNullOrWhiteSpace(PatientName))
                {
                    ErrorMessage = "Имя не может быть пустым";
                    throw new Exception("Имя не может быть пустым");
                }
                if (Validation.IsStringWithoutDigits(_patientName))
                {
                    Patient patient = new Patient
                    {
                        Birthday = _patientBirthDate,
                        Fullname = _patientName,
                        Guid = Guid.NewGuid(),
                        Gender = _patientGender == "Мужской" ? 1 : 0 
                    };
                    // Отправка данных на сервер
                    Patient newpatient = await App.ApiServiceInstance.AddPatientAsync(patient); // Замените "AddPatient" на ваш реальный конечный пункт
                    NewPatientInformation = $"Имя: {newpatient.Fullname}, Пол: {newpatient.Gender}, Дата рождения: {newpatient.Birthday.ToShortDateString()}, GUID {patient.Guid}";
                    ErrorMessage = string.Empty;
                }
            }

            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }
    }
}
