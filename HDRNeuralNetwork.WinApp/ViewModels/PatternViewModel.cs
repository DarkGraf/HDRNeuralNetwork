using System.Windows.Media.Imaging;

namespace HDRNeuralNetwork.WinApp.ViewModels
{
    public class PatternViewModel
    {
        public PatternViewModel(int index, BitmapSource image, byte label)
        {
            Index = index;
            Image = image;
            Label = label;
        }

        public int Index { get; set; }
        public BitmapSource Image { get; }
        public byte Label { get; }
    }
}