using HDRNeuralNetwork.WinApp.Interfaces;
using System;

namespace HDRNeuralNetwork.WinApp.ViewModels
{
    public class MainWindowModel
    {
        private readonly IWindow window;

        public MainWindowModel(IWindow window)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }

            this.window = window;
        }
    }
}