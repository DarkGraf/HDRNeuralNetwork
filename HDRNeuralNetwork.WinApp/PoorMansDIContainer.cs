using HDRNeuralNetwork.WinApp.Interfaces;
using HDRNeuralNetwork.WinApp.Utils;
using HDRNeuralNetwork.WinApp.Views;
using System.Windows;

namespace HDRNeuralNetwork.WinApp
{
    public class PoorMansDIContainer
    {
        public IWindow ResolveWindow()
        {
            IMainWindowModelFactory viewModelFactory = new MainWindowModelFactory();
            Window mainWindow = new MainWindow();
            return new MainWindowAdapter(mainWindow, viewModelFactory);
        }
    }
}