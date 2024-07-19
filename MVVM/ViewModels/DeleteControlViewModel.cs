using ClientApp.Services;
using ReactiveUI;
using System;

namespace ClientApp.MVVM.ViewModels
{
    public class DeleteControlViewModel : ViewModelBase
    {
        private string _deleteValue = string.Empty;
        public string DeleteValue
        {
            get => _deleteValue;
            set => this.RaiseAndSetIfChanged(ref _deleteValue, value);
        }


        private string _errorMessage = string.Empty;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => this.RaiseAndSetIfChanged(ref _errorMessage, value);
        }


        private string _resultValue = string.Empty;
        public string ResultValue
        {
            get => _resultValue;
            set => this.RaiseAndSetIfChanged(ref _resultValue, value);
        }


        public DeleteControlViewModel() { }

        public async void DeletePatient()
        {
            try
            {
                if (Validation.IsStringGuid(_deleteValue))
                {
                    string result = await ApiService.Instance.DeletePatientAsync(Guid.Parse(_deleteValue));
                    if (result != null)
                    {
                        ResultValue = result;
                    }
                    else
                        ErrorMessage = "Результат пустой";

                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

    }
}
