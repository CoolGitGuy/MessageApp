using MessageApp.Services;
using MessageApp.ViewModels;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MessageApp;

/// <summary>
/// An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class VerificationWindow : Window
{
    public VerificationWindowViewModel viewModel;

    public VerificationWindow()
    {
        WindowSettings();
        InitializeComponent();
        var windowService = new WindowService(this);
        viewModel = new VerificationWindowViewModel(windowService);
        this.StackPanel.DataContext = viewModel;
    }

    public void WindowSettings() //Disables Resize And Removes Title Bar
    {
        if (this.AppWindow.Presenter is OverlappedPresenter presenter)
        {
            presenter.IsResizable = false;
            //presenter.SetBorderAndTitleBar(false, false);
        }
        this.AppWindow.Resize(new SizeInt32(600, 400));
        ExtendsContentIntoTitleBar = true;
    }
}
