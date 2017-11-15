using HDRNeuralNetwork.WinApp.Interfaces;
using System;
using HDRNeuralNetwork.WinApp.ViewModels;

namespace HDRNeuralNetwork.WinApp.Utils
{
    public class MainWindowModelFactory : IMainWindowModelFactory
    {
        public object Create(IWindow window)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }

            return new MainWindowModel(window);
        }
    }
}