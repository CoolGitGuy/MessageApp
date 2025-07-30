using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Services
{
    public class WindowService : IWindowService
    {
        private Window currentWindow;

        public WindowService(Window currentWindow)
        {
            this.currentWindow = currentWindow;
        }

        public void closeCurrentWindow()
        {
            currentWindow.Close();
        }

        public void openWindow<T>() where T : Window, new()
        {
            var newWindow = new T();
            newWindow.Activate();
        }
    }
}
