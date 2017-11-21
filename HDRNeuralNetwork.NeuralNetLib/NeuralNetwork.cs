using System;
using System.Collections.Generic;

namespace HDRNeuralNetwork.NeuralNetLib
{
    public class NeuralNetwork
    {
        public NeuralNetwork(double learningRate)
        {
            LearningRate = learningRate;
            Layers = new List<NNLayer>();
        }

        public double LearningRate { get; private set; }

        public List<NNLayer> Layers { get; private set; }

        public double[] Calculate(double[] inputVector)
        {
            throw new NotImplementedException();
        }
    }
}