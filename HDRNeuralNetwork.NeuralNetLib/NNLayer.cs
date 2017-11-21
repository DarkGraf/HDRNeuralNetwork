using System;
using System.Collections.Generic;

namespace HDRNeuralNetwork.NeuralNetLib
{
    public class NNLayer
    {
        public NNLayer(NNLayer prevLayer = null)
        {
            PrevLayer = prevLayer;
            Neurons = new List<NNNeuron>();
            Weights = new List<NNWeight>();
        }

        public NNLayer PrevLayer { get; private set; }
        public List<NNNeuron> Neurons { get; private set; }
        public List<NNWeight> Weights { get; private set; }
    }
}