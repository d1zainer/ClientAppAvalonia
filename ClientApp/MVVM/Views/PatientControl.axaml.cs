using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Interactivity;
using System.Linq;
using System.Threading.Tasks;
using ClientApp.MVVM.ViewModels;
using System;

namespace ClientApp.MVVM.Views
{
    public partial class PatientControl : UserControl
    {
        private PatientControlViewModel _viewModel; 

        private static readonly Lazy<PatientControl> _patientControlInstance = new Lazy<PatientControl>(() => new PatientControl());

        public static PatientControl Instance => _patientControlInstance.Value;

        public PatientControl()
        {
            InitializeComponent();
            _viewModel = new PatientControlViewModel();
            DataContext = _viewModel;
        }

        /// <summary>
        /// нажатие на кнопку обновить
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateBtn(object sender, RoutedEventArgs e)
        {
            _viewModel.GetAllPatients();
        }     
    }
}
