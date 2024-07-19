using ClientApp.MVVM.Models;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ClientApp.MVVM.ViewModels
{
    public class PatientControlViewModel : ViewModelBase
    {
        private ObservableCollection<Patient> _patients = new ObservableCollection<Patient>();
        public ObservableCollection<Patient> Patients
        {
            get => _patients;
            set => this.RaiseAndSetIfChanged(ref _patients, value);
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => this.RaiseAndSetIfChanged(ref _errorMessage, value);

        }
        public PatientControlViewModel()
        {
        }
        public async Task GetAllPatients()
        {
            try
            {
                _patients.Clear();

                // Загрузка данных с сервера
                string json = await App.ApiServiceInstance.GetPatientsAsync();
                var newPatients = JsonConvert.DeserializeObject<ObservableCollection<Patient>>(json);

                // Добавление новых пациентов в коллекцию
                foreach (var patient in newPatients)
                {
                    _patients.Add(patient);
                }
                ErrorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Ошибка при загрузке пациентов: {ex.Message}";

            }
        }
    }
}
