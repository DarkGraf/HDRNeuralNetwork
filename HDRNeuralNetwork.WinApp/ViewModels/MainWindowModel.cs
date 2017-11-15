using HDRNeuralNetwork.Bll;
using HDRNeuralNetwork.WinApp.Interfaces;
using System;

namespace HDRNeuralNetwork.WinApp.ViewModels
{
    public class MainWindowModel
    {
        private readonly IWindow window;
        private readonly MainModel mainModel;

        int dpi = 96;
        int width = 28;
        int height = 28;

        public MainWindowModel(IWindow window, MainModel mainModel)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }
            if (mainModel == null)
            {
                throw new ArgumentNullException(nameof(mainModel));
            }

            this.window = window;
            this.mainModel = mainModel;

            ImageSource = mainModel.Collections[0][0].Image;
        }
      
        public byte[] ImageSource { get; set; }

        public string ImageSourceMetadata
        {
            get
            {
                return $"{dpi},{width},{height}";
            }
        }
    }
}