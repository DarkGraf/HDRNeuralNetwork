using HDRNeuralNetwork.DataSource.Mnist;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HDRNeuralNetwork.DataSource.Test
{
    [TestClass]
    public class ImageMnistReaderTest
    {
        [TestMethod]
        [DeploymentItem("..\\..\\..\\HDRNeuralNetwork.WinApp\\Mnist\\t10k-images.idx3-ubyte")]
        public void ImageMnistReaderTesting()
        {
            ImageMnistReader reader = new ImageMnistReader("t10k-images.idx3-ubyte");
            reader.Load();

            Assert.IsNotNull(reader.Data);
            Assert.AreEqual(10000, reader.Data.Length);
            Assert.AreEqual(28, reader.Height);
            Assert.AreEqual(28, reader.Width);
        }
    }
}