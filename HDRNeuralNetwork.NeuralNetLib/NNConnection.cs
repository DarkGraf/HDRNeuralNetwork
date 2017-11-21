namespace HDRNeuralNetwork.NeuralNetLib
{
    public class NNConnection
    {
        public NNConnection(uint neuronIndex, uint weightIndex)
        {
            NeuronIndex = neuronIndex;
            WeightIndex = weightIndex;
        }

        public uint NeuronIndex { get; private set; }
        public uint WeightIndex { get; private set; }
    }
}