using Avalonia;
using Avalonia.Controls;
using ClientApp.MVVM.ViewModels;
using System;

namespace ClientApp.MVVM.Views;

public partial class AddControl : UserControl
{
    private AddControlViewModel _viewModel; 
    private static readonly Lazy<AddControl> _addControlInstance = new Lazy<AddControl>(() => new AddControl());
    public static AddControl Instance => _addControlInstance.Value;
    public AddControl()
    {
        InitializeComponent();
        _viewModel = new AddControlViewModel();
        DataContext = _viewModel; 
        DataPicker.SelectedDateChanged += (_, e) =>
        {
            _viewModel.PatientBirthDate = e.NewDate.Value.Date;
            DataPicker.SelectedDate = e.NewDate.Value.Date;
        };
    }
    
    /// <summary>
    /// Нажатие на кнопку Добавить
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void AddBtn_click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {      
        _viewModel.AddPatient();
    }
    /// <summary>
    /// Нажатие на кнопку Отмена
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CanselBtn_click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _viewModel.ClearValues.Invoke();
        DataPicker.Clear();
        GenderItem.Clear();
    }
}
