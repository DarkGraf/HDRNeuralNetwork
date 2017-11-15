namespace HDRNeuralNetwork.Bll
{
    public class Pattern
    {
        public Pattern(byte[] image, byte label)
        {
            Image = image;
            Label = label;
        }

        public byte[] Image { get; }
        public byte Label { get; }
    }
}