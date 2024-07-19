using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System.Collections.Generic;

namespace ClientApp.MVVM.Views
{
    public partial class MainWindow : Window
    {

        private List<ToggleButton> toggleButtons = new List<ToggleButton>();

        private UserControl currentControl;

        
        public MainWindow()
        {
            InitializeComponent();

            //������ ���������� �����������
            toggleButtons.Add(toggleBtn1);
            toggleButtons.Add(toggleBtn2);
            toggleButtons.Add(toggleBtn3);
            toggleButtons.Add(toggleBtn4);
            toggleButtons.Add(toggleBtn5);

            //��������� ��������� ��� �������
            currentControl = PatientControl.Instance;
            SwitchControl(currentControl, toggleBtn1);
        }

        #region ToggleEvent
        private void BtnGetAllPatient_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {        
            SwitchControl(PatientControl.Instance, toggleBtn1);
        }
        private void BtnAddPatient_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SwitchControl(AddControl.Instance, toggleBtn2);
        }
        private void BtnFindPatient_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SwitchControl(FindControl.Instance, toggleBtn3);
        }
        private void BtnDeletePatient_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SwitchControl(DeleteControl.Instance, toggleBtn4);
        }
        private void BtnUpdatePatient_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SwitchControl(UpdateControl.Instance, toggleBtn5);
        }

        #endregion

        /// <summary>
        /// ����� ��������, ������ ��������
        /// </summary>
        /// <param name="control"></param>
        /// <param name="toggle"></param>
        private async void SwitchControl(UserControl control, ToggleButton toggle)
        {
            if (Content is Grid grid)
            {
                if (currentControl != null)
                {
                    grid.Children.Remove(currentControl); 
                }

                currentControl = control;
                grid.Children.Add(currentControl); 
                Grid.SetColumn(currentControl, 1);

                var animateTask = AnimationUserControl.AnimateVisibility(currentControl, true);
                ToggleSwitch(toggle);
                await animateTask;
            }
        }

        /// <summary>
        /// ����� ��������� �����
        /// </summary>
        /// <param name="toggle"></param>
        private void ToggleSwitch(ToggleButton toggle)
        {
            foreach (var item in toggleButtons)
            {
                item.IsChecked = (item == toggle);
            }
        }
     }
}
