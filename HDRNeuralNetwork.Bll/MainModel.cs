using HDRNeuralNetwork.Bll.Interfaces;
using System;

namespace HDRNeuralNetwork.Bll
{
    public class MainModel
    {
        public MainModel(IDataProvider[] dataProviders)
        {
            if (dataProviders == null)
            {
                throw new ArgumentNullException(nameof(dataProviders));
            }

            Collections = new PatternCollection[dataProviders.Length];
            for (int i = 0; i < dataProviders.Length; i++)
            {
                Collections[i] = dataProviders[i].Load();
            }

            ActiveCollectionIndex = -1;
        }

        public PatternCollection[] Collections { get; }

        public int ActiveCollectionIndex { get; set; }

        public PatternCollection ActiveCollection
        {
            get
            {
                return ActiveCollectionIndex >= 0 && ActiveCollectionIndex < Collections.Length ?
                    Collections[ActiveCollectionIndex] : null;
            }
        }
    }
}