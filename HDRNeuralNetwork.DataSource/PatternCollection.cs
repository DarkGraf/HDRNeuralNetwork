using System;
using System.Collections.Generic;

namespace HDRNeuralNetwork.DataSource
{
    public class PatternCollection : List<Pattern>
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }
}