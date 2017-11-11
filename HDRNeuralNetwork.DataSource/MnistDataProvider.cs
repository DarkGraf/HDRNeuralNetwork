using System;
using System.IO;
using System.Net;

namespace HDRNeuralNetwork.DataSource
{
    public class MnistDataProvider
    {
        readonly string imagesFileName;
        readonly string labelsFileName;

        public MnistDataProvider(string imagesFileName, string labelsFileName)
        {
            this.imagesFileName = imagesFileName;
            this.labelsFileName = labelsFileName;
        }

        public PatternCollection Load()
        {
            return null;
        }        
    }
}