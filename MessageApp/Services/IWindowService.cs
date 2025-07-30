using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.Services
{
    public interface IWindowService
    {
        // I had to ask AI for support for this interface
        // since I didn't know how to open and close a Window
        // without breaking MVVM architecture
        // :( I will try to not use it for anything else in this project
        // If I do I will leave a comment like this one
        void openWindow<T>() where T : Window, new();
        void closeCurrentWindow();
    }
}
