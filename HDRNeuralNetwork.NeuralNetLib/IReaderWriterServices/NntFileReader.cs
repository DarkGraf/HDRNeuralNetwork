using System;
using System.IO;
using System.Text;

namespace HDRNeuralNetwork.NeuralNetLib.IReaderWriterServices
{
    public class NntFileReader : INNReader
    {
        readonly string fileName;

        public NntFileReader(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            this.fileName = fileName;
        }

        public NeuralNetwork Read()
        {
            NeuralNetwork net;

            using (BinaryReader reader = new BinaryReader(new FileStream(fileName, FileMode.Open)))
            {
                reader.BaseStream.Seek(0x18600, SeekOrigin.Begin);

                double learningRate = reader.ReadDouble();                
                net = new NeuralNetwork(learningRate);

                int layersCount = reader.ReadInt32();
                NNLayer layer = null;
                for (int i = 0; i < layersCount; i++)
                {
                    string layerName = ReadString(reader);
                    layer = new NNLayer(layer);
                    net.Layers.Add(layer);

                    int neuronsCount = reader.ReadInt32();
                    int weightsCount = reader.ReadInt32();

                    for (int j = 0; j < neuronsCount; j++)
                    {
                        string neuronName = ReadString(reader);
                        NNNeuron neuron = new NNNeuron();
                        layer.Neurons.Add(neuron);

                        int connectionsCount = reader.ReadInt32();

                        for (int k = 0; k < connectionsCount; k++)
                        {
                            uint neuronIndex = reader.ReadUInt32();
                            uint weightIndex = reader.ReadUInt32();
                            NNConnection connection = new NNConnection(neuronIndex, weightIndex);
                            neuron.Connections.Add(connection);
                        }
                    }

                    for (int j = 0; j < weightsCount; j++)
                    {
                        string weightName = ReadString(reader);
                        double value = reader.ReadDouble();

                        NNWeight weight = new NNWeight { Value = value };
                        layer.Weights.Add(weight);
                    }
                }
            }

            return net;
        }

        private string ReadString(BinaryReader reader)
        {
            char ch1 = char.MinValue;
            char ch2 = char.MinValue;
            StringBuilder sb = new StringBuilder();

            while (ch1 != '\n' && ch2 != '\r')
            {
                ch2 = ch1;
                ch1 = reader.ReadChars(2)[0];
                sb.Append(ch1);
            }
            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }
    }
}