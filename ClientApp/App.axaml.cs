using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ClientApp.MVVM.Views;
using ClientApp.Services;

namespace ClientApp
{
    public partial class App : Application
    {
        public static  ApiService ApiServiceInstance => ApiService.Instance;
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) 
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MVVM.ViewModels.MainWindowViewModel(),
                };
              
               
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}