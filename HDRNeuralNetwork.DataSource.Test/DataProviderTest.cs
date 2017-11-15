using HDRNeuralNetwork.Bll;
using HDRNeuralNetwork.DataSource.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HDRNeuralNetwork.DataSource.Test
{
    [TestClass]
    public class DataProviderTest
    {
        [TestMethod]
        public void DataProviderTesting()
        {
            byte[][] images = new byte[][]
            {
                new byte[] { 0, 1, 2, 3, 4, 5 },
                new byte[] { 6, 7, 8, 9, 0, 1 }
            };
            byte[] labels = new byte[] { 0, 1 };

            IImageReader imageReader = Mock.Of<IImageReader>(e => e.Height == 2 
                && e.Width == 3 
                && e.Data == images);
            ILabelReader labelReader = Mock.Of<ILabelReader>(e => e.Data == labels);

            DataProvider provider = new DataProvider(imageReader, labelReader);
            PatternCollection result = provider.Load();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(2, result.Height);
            Assert.AreEqual(3, result.Width);
            CollectionAssert.AreEqual(images[0], result[0].Image);
            Assert.AreEqual(labels[0], result[0].Label);
            CollectionAssert.AreEqual(images[1], result[1].Image);
            Assert.AreEqual(labels[1], result[1].Label);
        }
    }
}
