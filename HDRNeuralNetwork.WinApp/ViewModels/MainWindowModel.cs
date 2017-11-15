using HDRNeuralNetwork.WinApp.Interfaces;
using System;

namespace HDRNeuralNetwork.WinApp.ViewModels
{
    public class MainWindowModel
    {
        private readonly IWindow window;

        int dpi = 96;
        int width = 128;
        int height = 128;

        public MainWindowModel(IWindow window)
        {
            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }

            this.window = window;

            CreateBitmapSource();
        }

        private void CreateBitmapSource()
        {
            byte[] pixelData = new byte[width * height];

            for (int y = 0; y < height; ++y)
            {
                int yIndex = y * width;
                for (int x = 0; x < width; ++x)
                {
                    pixelData[x + yIndex] = (byte)(x + y);
                }
            }

            ImageSource = pixelData;
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