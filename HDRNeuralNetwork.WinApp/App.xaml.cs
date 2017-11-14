using System.Windows;

namespace HDRNeuralNetwork.WinApp
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = new PoorMansDIContainer();
            container.ResolveWindow().Show();
        }
    }
}