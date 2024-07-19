using Avalonia.Controls;
using ClientApp.MVVM.ViewModels;
using System;

namespace ClientApp.MVVM.Views;

public partial class FindControl : UserControl
{
    private static readonly Lazy<FindControl> _findControlInstance = new Lazy<FindControl>(() => new FindControl());
    public static FindControl Instance => _findControlInstance.Value;

    private FindControlViewModel _viewModel;
    private FindControlViewModel.SearchType searchType;
    public FindControl()
    {
        InitializeComponent();
        _viewModel = new FindControlViewModel();
        DataContext = _viewModel;
        ParameterTypeItem.SelectionChanged += (_, e) =>
        {
            searchType = (FindControlViewModel.SearchType)ParameterTypeItem.SelectedIndex;

        };
    }
    /// <summary>
    /// Нажаттие на кнопку Найти
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FindBtn_click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        _viewModel.GetPatientBy(searchType);
    }

    /// <summary>
    /// нажатие на кнопку отмена
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void CanselBtn_click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ParameterTypeItem.Clear();
        _viewModel.SearchValue = string.Empty;
    }
}