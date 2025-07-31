using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MessageApp.MVVM;
using MessageApp.Services;
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
        private string? verificationCode;

        private string? authTextBox;
        public ICommand AuthButtonCommand { get; }
        public ICommand BackButton { get; }
        private IWindowService windowService;
        public VerificationWindowViewModel(IWindowService windowService)
        {
            this.windowService = windowService;
            AuthButtonCommand = new RelayCommand(VerifyAction);
            BackButton = new RelayCommand(BackAction);

            WeakReferenceMessenger.Default.Register<VerificationCodeMessage>(this, (r, m) =>
            {
                verificationCode = m.Value;
            });
        }

        public string? AuthTextBox
        {
            get { return authTextBox; }
            set { 
                authTextBox = value;
                OnPropertyChanged();
            }
        }
        private string? verificationChecker;

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
            if(AuthTextBox != null && AuthTextBox.Equals(verificationCode))
                VerificationChecker = "Kod je validan!";
            else VerificationChecker = "Kod nije validan!";
        }

        public void BackAction() //Goes Back To MainWindow
        {
            windowService.openWindow<MainWindow>();
            windowService.closeCurrentWindow();
        }
    }
}
