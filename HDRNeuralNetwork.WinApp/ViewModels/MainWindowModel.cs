using HDRNeuralNetwork.WinApp.Interfaces;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

            CreateBitmapSource();
        }

        private void CreateBitmapSource()
        {
            double dpi = 96;
            int width = 128;
            int height = 128;
            byte[] pixelData = new byte[width * height];

            for (int y = 0; y < height; ++y)
            {
                int yIndex = y * width;
                for (int x = 0; x < width; ++x)
                {
                    pixelData[x + yIndex] = (byte)(x + y);
                }
            }

            BitmapSource = BitmapSource.Create(width, height, dpi, dpi,
                PixelFormats.Gray8, null, pixelData, width);
        }

        public BitmapSource BitmapSource { get; set; }
    }
}