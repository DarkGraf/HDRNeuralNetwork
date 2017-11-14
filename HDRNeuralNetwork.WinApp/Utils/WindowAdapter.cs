using System;
using HDRNeuralNetwork.WinApp.Interfaces;
using System.Windows;

namespace HDRNeuralNetwork.WinApp.Utils
{
    public class WindowAdapter : IWindow
    {
        private readonly Window wpfWindow;

        public WindowAdapter(Window wpfWindow)
        {
            if (wpfWindow == null)
            {
                throw new ArgumentNullException(nameof(wpfWindow));
            }

            this.wpfWindow = wpfWindow;
        }

        protected Window WpfWindow
        {
            get { return wpfWindow; }
        }

        #region IWindow

        public virtual void Close()
        {
            wpfWindow.Close();
        }

        public virtual IWindow CreateChild(object viewModel)
        {
            throw new NotImplementedException();
        }

        public virtual void Show()
        {
            wpfWindow.Show();
        }

        public virtual bool? ShowDialog()
        {
            return wpfWindow.ShowDialog();
        }

        #endregion
    }
}