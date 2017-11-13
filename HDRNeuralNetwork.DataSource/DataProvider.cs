using HDRNeuralNetwork.DataSource.Interfaces;
using System.IO;

namespace HDRNeuralNetwork.DataSource
{
    public class DataProvider
    {
        readonly IImageReader imageReader;
        readonly ILabelReader labelReader;

        public DataProvider(IImageReader imageReader, ILabelReader labelReader)
        {
            this.imageReader = imageReader;
            this.labelReader = labelReader;
        }

        public PatternCollection Load()
        {
            LoadFromReaders();
            PatternCollection collection = LoadToCollection();
            return collection;
        }

        private void LoadFromReaders()
        {
            imageReader.Load();
            labelReader.Load();
            if (imageReader.Data.Length != labelReader.Data.Length)
            {
                throw new InvalidDataException();
            }
        }

        private PatternCollection LoadToCollection()
        {
            PatternCollection collection = new PatternCollection();
            collection.Height = imageReader.Height;
            collection.Width = imageReader.Width;
            for (int i = 0; i < imageReader.Data.Length; i++)
            {
                Pattern pattern = new Pattern(imageReader.Data[i], labelReader.Data[i]);
                collection.Add(pattern);
            }
            return collection;
        }
    }
}