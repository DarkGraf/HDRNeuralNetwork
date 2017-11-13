using System.IO;
using System.Net;

namespace HDRNeuralNetwork.DataSource.Mnist
{
    public abstract class MnistReader<T>
    {
        readonly string fileName;
        readonly int magicNumber;

        public MnistReader(string fileName, int magicNumber)
        {
            this.fileName = fileName;
            this.magicNumber = magicNumber;
        }

        public T[] Data { get; private set; }

        public void Load()
        {
            using (BinaryReader reader = new BinaryReader(new FileStream(fileName, FileMode.Open)))
            {
                int magicNumber = IPAddress.HostToNetworkOrder(reader.ReadInt32());
                if (magicNumber != this.magicNumber)
                {
                    throw new FileLoadException();
                }

                int count = IPAddress.HostToNetworkOrder(reader.ReadInt32());
                Data = new T[count];

                BeforeLoad(reader);

                for (int i = 0; i < count; i++)
                {
                    Data[i] = OneLoad(reader);
                }
            }
        }

        protected abstract void BeforeLoad(BinaryReader reader);
        protected abstract T OneLoad(BinaryReader reader);
    }
}