using HDRNeuralNetwork.DataSource.Mnist;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HDRNeuralNetwork.DataSource.Test
{
    [TestClass]
    public class LabelMnistReaderTest
    {
        [TestMethod]
        [DeploymentItem("..\\..\\..\\HDRNeuralNetwork.DataSource.Test\\Mnist\\t10k-labels.idx1-ubyte")]
        public void LabelMnistReaderTesting()
        {
            LabelMnistReader reader = new LabelMnistReader("t10k-labels.idx1-ubyte");
            reader.Load();

            Assert.IsNotNull(reader.Data);
            Assert.AreEqual(10000, reader.Data.Length);
        }
    }
}