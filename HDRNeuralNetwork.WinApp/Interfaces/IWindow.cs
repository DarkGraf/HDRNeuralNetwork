namespace HDRNeuralNetwork.WinApp.Interfaces
{
    public interface IWindow
    {
        void Close();
        IWindow CreateChild(object viewModel);
        void Show();
        bool? ShowDialog();
    }
}