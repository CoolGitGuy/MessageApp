using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MessageApp.ViewModels
{
    public partial class MainWindowViewModel : INotifyPropertyChanged
    {

        private string email;
        public string Email
        {
            get { return email; }
            set {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Email"));
                email = value; 
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
