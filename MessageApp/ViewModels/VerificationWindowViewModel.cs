using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MessageApp.MVVM;
using MessageApp.Services;
using Microsoft.UI.Xaml.Controls.AnimatedVisuals;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MessageApp.ViewModels
{
    public partial class VerificationWindowViewModel : ViewModelBase
    {
        private int counter;
        private string? verificationCode;
        private string? email;
        private string? verificationChecker;
        private string? authTextBox;
        public ICommand AuthButtonCommand { get; }
        public ICommand BackButton { get; }
        private IWindowService windowService;
        public VerificationWindowViewModel(IWindowService windowService)
        {
            counter = 3;
            this.windowService = windowService;
            AuthButtonCommand = new RelayCommand(VerifyAction);
            BackButton = new RelayCommand(BackAction);

            WeakReferenceMessenger.Default.Register<VerificationCodeMessage>(this, (r, m) => { verificationCode = m.Value; });
            WeakReferenceMessenger.Default.Register<EmailMessage>(this, (r, m) => { email = m.Value; });
        }

        public string? AuthTextBox
        {
            get { return authTextBox; }
            set
            {
                authTextBox = value;
                OnPropertyChanged();
            }
        }

        public string? VerificationChecker
        {
            get { return verificationChecker; }
            set
            {
                verificationChecker = value;
                OnPropertyChanged();
            }
        }

        public void VerifyAction() // AuthButtonCommand, It checks if the verification code is valid or not 
        {
            if (AuthTextBox != null && AuthTextBox.Equals(verificationCode))
            {

            }
            else
            {
                counter--;
                VerificationChecker = (counter !=1) ? $"Code is not valid! You have {counter} tries left." : $"Code is not valid! You have {counter} try left.";
                if (counter == 0) BackAction(); // If counter is 0, we are going back the the MainWindow
            }
        }

        public void BackAction() //Goes Back To MainWindow
        {
            windowService.openWindow<MainWindow>();
            windowService.closeCurrentWindow();
        }
    }
}
