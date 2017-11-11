using System.IO;
using System.Net;

namespace HDRNeuralNetwork.DataSource
{
    public class ImageMnistReader : MnistReader<byte[]>
    {
        private int size;

        public ImageMnistReader(string fileName) : base(fileName, 2051) { }

        public int Height { get; private set; }
        public int Width { get; private set; }

        protected override void BeforeLoad(BinaryReader reader)
        {
            Height = IPAddress.HostToNetworkOrder(reader.ReadInt32());
            Width = IPAddress.HostToNetworkOrder(reader.ReadInt32());
            size = Height * Width;
        }

        protected override byte[] OneLoad(BinaryReader reader)
        {
            return reader.ReadBytes(size);
        }
    }
}