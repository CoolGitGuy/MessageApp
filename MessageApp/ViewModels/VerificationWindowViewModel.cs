using CommunityToolkit.Mvvm.Input;
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
        private string? verificationText;
        public ICommand VerificationCommand { get; }
        public ICommand BackButton { get; }
        private IWindowService windowService;
        public VerificationWindowViewModel(IWindowService windowService)
        {
            this.windowService = windowService;
            VerificationCommand = new RelayCommand(VerifyAction);
            BackButton = new RelayCommand(BackAction);
        }

        public string? VerificationText
        {
            get { return verificationText; }
            set { 
                verificationText = value;
                OnPropertyChanged();
            }
        }


        public void VerifyAction()
        {
            VerificationText = "Ide gas";
        }

        public void BackAction()
        {
            windowService.openWindow<MainWindow>();
            windowService.closeCurrentWindow();
        }
    }
}
