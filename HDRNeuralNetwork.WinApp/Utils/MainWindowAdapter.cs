using HDRNeuralNetwork.WinApp.Interfaces;
using HDRNeuralNetwork.WinApp.ViewModels;
using System;
using System.Windows;

namespace HDRNeuralNetwork.WinApp.Utils
{
    public class MainWindowAdapter : WindowAdapter
    {
        private readonly IMainWindowModelFactory viewModelFactory;
        private bool initialized;

        public MainWindowAdapter(Window wpfWindow, IMainWindowModelFactory viewModelFactory)
            : base(wpfWindow)
        {
            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }
                
            this.viewModelFactory = viewModelFactory;
        }

        #region IWindow

        public override void Close()
        {
            EnsureInitialized();
            base.Close();
        }

        public override IWindow CreateChild(object viewModel)
        {
            EnsureInitialized();
            return base.CreateChild(viewModel);
        }

        public override void Show()
        {
            EnsureInitialized();
            base.Show();
        }

        public override bool? ShowDialog()
        {
            EnsureInitialized();
            return base.ShowDialog();
        }

        #endregion

        private void EnsureInitialized()
        {
            if (!initialized)
            {
                object viewModel = viewModelFactory.Create(this);
                WpfWindow.DataContext = viewModel;
                initialized = true;
            }
        }
    }
}