using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MessageApp.MVVM;
using MessageApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MessageApp.ViewModels
{
    public partial class VerificationWindowViewModel : ViewModelBase
    {
        private string? verificationCode;

        private string? verificationText;
        public ICommand VerificationCommand { get; }
        public ICommand BackButton { get; }
        private IWindowService windowService;
        public VerificationWindowViewModel(IWindowService windowService)
        {
            this.windowService = windowService;
            VerificationCommand = new RelayCommand(VerifyAction);
            BackButton = new RelayCommand(BackAction);

            WeakReferenceMessenger.Default.Register<VerificationCodeMessage>(this, (r, m) =>
            {
                Gas(m.Value);
            });
        }

        public string? VerificationText
        {
            get { return verificationText; }
            set { 
                verificationText = value;
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

        public void Gas(string message)
        {
            VerificationChecker = message;
        }

        public void VerifyAction()
        {
            VerificationText = "Ide gas";
        }

        public void BackAction() //Goes Back To MainWindow
        {
            windowService.openWindow<MainWindow>();
            windowService.closeCurrentWindow();
        }
    }
}
