using HDRNeuralNetwork.WinApp.Interfaces;
using System;
using HDRNeuralNetwork.WinApp.ViewModels;
using HDRNeuralNetwork.Bll;

namespace HDRNeuralNetwork.WinApp.Utils
{
    public class MainWindowModelFactory : IMainWindowModelFactory
    {
        readonly MainModel mainModel;

        public MainWindowModelFactory(MainModel mainModel)
        {
            if (mainModel == null)
            {
                throw new ArgumentNullException(nameof(mainModel));
            }

            this.mainModel = mainModel;
        }

        public object Create(IWindow window)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }

            return new MainWindowModel(window, mainModel);
        }
    }
}