using HDRNeuralNetwork.WinApp.ViewModels;

namespace HDRNeuralNetwork.WinApp.Interfaces
{
    public interface IMainWindowModelFactory
    {
        MainWindowModel Create(IWindow window);
    }
}