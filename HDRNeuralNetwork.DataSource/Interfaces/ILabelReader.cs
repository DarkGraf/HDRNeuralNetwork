namespace HDRNeuralNetwork.DataSource.Interfaces
{
    public interface ILabelReader
    {
        byte[] Data { get; }
        void Load();
    }
}