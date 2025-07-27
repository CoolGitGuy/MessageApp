using CommunityToolkit.Mvvm.Input;
using MessageApp.MVVM;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MessageApp.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {
            AuthCommand = new RelayCommand(ChangeItems);
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        public ICommand AuthCommand { get; }

        private void ChangeItems()
        {
            Email = "Hello,World";
            Password = "Hello,World";
        }
    }
}
