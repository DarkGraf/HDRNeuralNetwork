using System.IO;

namespace HDRNeuralNetwork.DataSource
{
    public class LabelMnistReader : MnistReader<byte>
    {
        public LabelMnistReader(string fileName) : base(fileName, 2049) { }

        protected override void BeforeLoad(BinaryReader reader) { }

        protected override byte OneLoad(BinaryReader reader)
        {
            return reader.ReadByte();
        }
    }
}