using Avalonia.Controls;
using ClientApp.MVVM.Models;
using ClientApp.MVVM.ViewModels;
using System;

namespace ClientApp.MVVM.Views;

public partial class UpdateControl : UserControl
{
    private static readonly Lazy<UpdateControl> _updateControlInstance = new Lazy<UpdateControl>(() => new UpdateControl());
    public static UpdateControl Instance => _updateControlInstance.Value;

    private UpdateControlViewModel _viewModel;
    public UpdateControl()
    {
        InitializeComponent();
        _viewModel = new UpdateControlViewModel();
        DataContext = _viewModel;
        DataPicker.SelectedDateChanged += (_, e) =>
        {
            _viewModel.PatientBirthDay = e.NewDate.Value.Date;
            DataPicker.SelectedDate = e.NewDate.Value.Date;
        };
        GenderTypeComboBox.SelectionChanged += (_, e) =>
        {
            _viewModel.GenderType = (GenderType?)GenderTypeComboBox.SelectedIndex;
        };
    }
    /// <summary>
    /// Нажатие на кнопку Сохранить
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SaveBtn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _viewModel.UpdatePatient(); 
    }
    /// <summary>
    /// нажатие на кнопку Отмена
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CanselBtn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        DataPicker.Clear();
       GenderTypeComboBox.Clear();
        _viewModel.FullNamePatient = null;     
    }
}