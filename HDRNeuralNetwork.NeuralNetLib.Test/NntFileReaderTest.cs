using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HDRNeuralNetwork.NeuralNetLib.IReaderWriterServices;

namespace HDRNeuralNetwork.NeuralNetLib.Test
{
    [TestClass]
    public class NntFileReaderTest
    {
        private void LayerTest(NNLayer layer, int neuronsCount, int weightsCount, int connectionsCount)
        {
            Assert.AreEqual(neuronsCount, layer.Neurons.Count);
            Assert.AreEqual(weightsCount, layer.Weights.Count);
            foreach (NNNeuron n in layer.Neurons)
            {
                Assert.AreEqual(connectionsCount, n.Connections.Count);
            }
        }

        [TestMethod]
        [DeploymentItem("..\\..\\..\\HDRNeuralNetwork.NeuralNetLib.Test\\Nnt\\10September-PolishedWithUndistorted-7epochs-dot026MSE-74Errors.nnt")]
        public void NntReaderTesting()
        {
            NntFileReader reader = new NntFileReader("10September-PolishedWithUndistorted-7epochs-dot026MSE-74Errors.nnt");

            NeuralNetwork net = reader.Read();

            Assert.AreEqual(0.0001, net.LearningRate);
            Assert.AreEqual(5, net.Layers.Count);

            // Первый слой (входной). Входов 29х29.
            LayerTest(net.Layers[0], neuronsCount: 841, weightsCount: 0, connectionsCount: 0);

            // Второй слой. 6 карт по 13х13 = 1014.
            LayerTest(net.Layers[1], neuronsCount: 1014, weightsCount: 156, connectionsCount: 26);

            // Третий слой. 50 карт по 5х5 = 1250.
            LayerTest(net.Layers[2], neuronsCount: 1250, weightsCount: 7800, connectionsCount: 151);

            // Четвертый слой. Полное соединение, 100 нейронов.
            LayerTest(net.Layers[3], neuronsCount: 100, weightsCount: 125100, connectionsCount: 1251);

            // Пятый слой. Полное соединение, 10 нейронов.
            LayerTest(net.Layers[4], neuronsCount: 10, weightsCount: 1010, connectionsCount: 101);
        }
    }
}
