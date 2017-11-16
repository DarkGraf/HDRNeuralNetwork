using HDRNeuralNetwork.Bll;
using HDRNeuralNetwork.Bll.Interfaces;
using HDRNeuralNetwork.DataSource;
using HDRNeuralNetwork.DataSource.Mnist;
using HDRNeuralNetwork.WinApp.Interfaces;
using HDRNeuralNetwork.WinApp.Utils;
using HDRNeuralNetwork.WinApp.Views;
using System.Windows;

namespace HDRNeuralNetwork.WinApp
{
    public class PoorMansDIContainer
    {
        public IWindow ResolveWindow()
        {
            ImageMnistReader imageReader = new ImageMnistReader(@"..\..\..\HDRNeuralNetwork.DataSource.Test\Mnist\t10k-images.idx3-ubyte");
            LabelMnistReader labelReader = new LabelMnistReader(@"..\..\..\HDRNeuralNetwork.DataSource.Test\Mnist\t10k-labels.idx1-ubyte");
            DataProvider provider = new DataProvider(imageReader, labelReader);
            MainModel mainModel = new MainModel(new IDataProvider[] { provider });
            IMainWindowModelFactory viewModelFactory = new MainWindowModelFactory(mainModel);
            Window mainWindow = new MainWindow();
            return new MainWindowAdapter(mainWindow, viewModelFactory);
        }
    }
}