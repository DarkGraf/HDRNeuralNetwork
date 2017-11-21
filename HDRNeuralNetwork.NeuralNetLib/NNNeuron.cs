using System;
using System.Collections.Generic;

namespace HDRNeuralNetwork.NeuralNetLib
{
    public class NNNeuron
    {
        public NNNeuron()
        {
            Connections = new List<NNConnection>();
        }

        public List<NNConnection> Connections { get; private set; }
    }
}