namespace HDRNeuralNetwork.DataSource.Interfaces
{
    public interface IImageReader
    {
        int Height { get; }
        int Width { get; }
        byte[][] Data { get; }
        void Load();
    }
}