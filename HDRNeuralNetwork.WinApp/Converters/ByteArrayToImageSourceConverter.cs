using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HDRNeuralNetwork.WinApp.Converters
{
    public class ByteArrayToImageSourceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length != 2 || values[0].GetType() != typeof(string)
                || values[1].GetType() != typeof(byte[]) || targetType != typeof(ImageSource))
            {
                throw new InvalidOperationException();
            }

            string strParameter = values[0] as string;
            int[] mas = strParameter.Split(',').Select(v => int.Parse(v)).ToArray();

            int dpi = mas[0];
            int width = mas[1];
            int height = mas[2];

            return BitmapSource.Create(width, height, dpi, dpi, PixelFormats.Gray8, null, (byte[])values[1], width);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}