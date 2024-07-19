using Avalonia.Controls;
using ClientApp.MVVM.ViewModels;
using System;

namespace ClientApp.MVVM.Views;

public partial class DeleteControl : UserControl
{
    private static readonly Lazy<DeleteControl> _deleteControlInstance = new Lazy<DeleteControl>(() => new DeleteControl());
    public static DeleteControl Instance => _deleteControlInstance.Value;
    private DeleteControlViewModel _viewModel;
    public DeleteControl()
    {
        InitializeComponent();
        _viewModel = new DeleteControlViewModel();
        DataContext = _viewModel;
    }


    /// <summary>
    /// нажатие на кнопку Удалить
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DeleteBtn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _viewModel.DeletePatient();
    }

    /// <summary>
    /// кнопка отменить
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CancelBtn_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _viewModel.DeleteValue = string.Empty;
    }

}