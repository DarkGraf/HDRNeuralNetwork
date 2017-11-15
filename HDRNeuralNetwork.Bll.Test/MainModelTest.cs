using Microsoft.VisualStudio.TestTools.UnitTesting;
using HDRNeuralNetwork.Bll.Interfaces;
using Moq;

namespace HDRNeuralNetwork.Bll.Test
{
    [TestClass]
    public class MainModelTest
    {
        [TestMethod]
        public void MainModelLoadData()
        {
            byte[][] images = new byte[][]
            {
                new byte[] { 0, 1, 2, 3, 4, 5 },
                new byte[] { 9, 8, 7, 6, 5, 4 }
            };

            PatternCollection patterns1 = new PatternCollection();
            patterns1.Height = 2;
            patterns1.Width = 3;
            patterns1.Add(new Pattern(images[0], 0));
            patterns1.Add(new Pattern(images[1], 1));

            PatternCollection patterns2 = new PatternCollection();
            patterns2.Height = 2;
            patterns2.Width = 3;
            patterns2.Add(new Pattern(images[0], 0));

            IDataProvider dataProvider1 = Mock.Of<IDataProvider>(e => e.Load() == patterns1);
            IDataProvider dataProvider2 = Mock.Of<IDataProvider>(e => e.Load() == patterns2);
            MainModel model = new MainModel(new[] { dataProvider1, dataProvider2 });

            Assert.IsNotNull(model.Collections);
            Assert.AreEqual(2, model.Collections.Length);

            Assert.AreEqual(2, model.Collections[0].Count);
            CollectionAssert.AreEqual(images[0], model.Collections[0][0].Image);
            Assert.AreEqual(0, model.Collections[0][0].Label);
            CollectionAssert.AreEqual(images[1], model.Collections[0][1].Image);
            Assert.AreEqual(1, model.Collections[0][1].Label);

            Assert.AreEqual(1, model.Collections[1].Count);
            CollectionAssert.AreEqual(images[0], model.Collections[0][0].Image);
            Assert.AreEqual(0, model.Collections[0][0].Label);

            Assert.AreEqual(-1, model.ActiveCollectionIndex);
            Assert.IsNull(model.ActiveCollection);

            model.ActiveCollectionIndex = 0;
            Assert.AreEqual(2, model.ActiveCollection.Count);
        }
    }
}
