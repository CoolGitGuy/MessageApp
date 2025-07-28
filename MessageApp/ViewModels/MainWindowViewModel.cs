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
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace MessageApp.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {


        public MainWindowViewModel()
        {
            AuthCommand = new RelayCommand(ChangeItems);
        }

        private string? authErrorText;

        public string? AuthErrorText
        {
            get { return authErrorText; }
            set { 
                    authErrorText = value;
                    OnPropertyChanged();
                }
        }

        private string? email;
        public string? Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string? password;

        public string? Password
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
            EmailVerification(Email);
        }


        public void EmailVerification(string emailAdress)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            try
            {
                mail.From = new MailAddress("leaderrat58@gmail.com");
                mail.To.Add(emailAdress);
                mail.Subject = "Verification Email";
                mail.Body = "Verifikuj se";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("leaderrat58@gmail.com", "nuov brrb thiv nczj");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
            }
            catch (Exception)
            {
                AuthErrorText = "Email address is not valid.";
            }
        }
    }
}
