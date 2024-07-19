using ClientApp.MVVM.Models;
using Newtonsoft.Json;
using ReactiveUI;
using System;


namespace ClientApp.MVVM.ViewModels
{
    public class FindControlViewModel : ViewModelBase
    {
        private string _searchValue;
        public string SearchValue
        {
            get => _searchValue;
            set => this.RaiseAndSetIfChanged(ref _searchValue, value);
        }
        private string _newPatientInfo;
        public string NewPatientInfo
        {
            get => _newPatientInfo;
            set => this.RaiseAndSetIfChanged(ref _newPatientInfo, value);
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
        }

        public enum SearchType
        {
            Name = 0,
            Guid = 1
        }
        public Action ClearValues;
        public FindControlViewModel()
        {
            ClearValues += () => _searchValue = string.Empty;
        }

        public async void GetPatientBy(SearchType searchType)
        {
            try
            {
                if (string.IsNullOrEmpty(_searchValue))
                {
                    // Handle empty search value
                    ErrorMessage = "Введите значение для поиска.";
                    return;
                }

                switch (searchType)
                {
                    case SearchType.Name: //ищем по имени
                        if (Validation.IsStringWithoutDigits(_searchValue))
                        {
                            string resultByName = await App.ApiServiceInstance.GetPatientByNameAsync(_searchValue);
                            Patient patientByName = JsonConvert.DeserializeObject<Patient>(resultByName);
                            NewPatientInfo = $"Имя: {patientByName.Fullname}, Пол: {patientByName.Gender}, Дата рождения: {patientByName.Birthday.ToShortDateString()}, GUID:{patientByName.Guid}";
                            ErrorMessage = string.Empty;
                        }
                        else
                        {
                            ErrorMessage = "Ошибка: Введенное значение содержит цифры.";
                        }
                        break;

                    case SearchType.Guid: //ищем по айди
                        if (Validation.IsStringGuid(_searchValue))
                        {
                            var resultById = await App.ApiServiceInstance.GetPatientByIdAsync(Guid.Parse(_searchValue));
                            Patient patientById = JsonConvert.DeserializeObject<Patient>(resultById);
                            NewPatientInfo = $"Имя: {patientById.Fullname}, Пол: {patientById.Gender}, Дата рождения: {patientById.Birthday.ToShortDateString()}, , GUID:{patientById.Guid}";
                            ErrorMessage = string.Empty;
                        }
                        else
                        {
                            ErrorMessage = "Ошибка: Введенное значение не является корректным GUID.";
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                ErrorMessage = $"Ошибка: {e.Message}";
            }
        }




    }
}
