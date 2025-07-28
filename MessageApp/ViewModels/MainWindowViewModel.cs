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

        private string? email;
        public string Email
        {
            get { return (email == null) ? email : ""; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string? password;

        public string Password
        {
            get { return (password == null) ? password : ""; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }
        public ICommand AuthCommand { get; }

        private void ChangeItems()
        {
            Debug.WriteLine(email);
            EmailVerification(Email);
        }


        public static void EmailVerification(string emailAdress)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            try
            {
                mail.From = new MailAddress("leaderrat58@gmail.com");
                mail.To.Add("borisboskovic16@gmail.com");
                mail.Subject = "Verification Email";
                mail.Body = "Verifikuj se";
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("leaderrat58@gmail.com", "");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
