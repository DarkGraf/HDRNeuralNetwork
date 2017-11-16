using HDRNeuralNetwork.Bll;
using HDRNeuralNetwork.WinApp.Interfaces;
using System;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

            int i = 0;
            Patterns = mainModel.Collections[0].Select(v => new PatternViewModel(i++, BitmapSource.Create(width, height, dpi, dpi, PixelFormats.Gray8, null, v.Image, width), v.Label)).ToArray();
        }

        public PatternViewModel[] Patterns { get; }
    }
}