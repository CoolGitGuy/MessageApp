using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MessageApp.MVVM;
using MessageApp.Services;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MessageApp.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private string? authErrorText;
        private string? email;
        private string? password;
        private readonly IWindowService windowService;
        public ICommand AuthCommand { get; }

        public MainWindowViewModel(IWindowService windowService)
        {
            this.windowService = windowService;
            AuthCommand = new RelayCommand(AuthAction);
        }

        public string? AuthErrorText
        {
            get { return authErrorText; }
            set { 
                    authErrorText = value;
                    OnPropertyChanged();
                }
        }

        public string? Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public string? Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        private void AuthAction()
        {
            if(Email != null)
                EmailVerification(Email);
        }


        public void EmailVerification(string emailAdress) //Sends A Verification Email Using SMTP Protocol
        {
            string verificationCode = VerificationCode();
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            try
            {
                mail.From = new MailAddress("leaderrat58@gmail.com");
                mail.To.Add(emailAdress);
                mail.Subject = "Verification Email";
                mail.Body = "Your Verification Code Is " + verificationCode;
                smtpClient.Port = 587;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("leaderrat58@gmail.com", "nuov brrb thiv nczj");
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);
                windowService.openWindow<VerificationWindow>();
                WeakReferenceMessenger.Default.Send(new VerificationCodeMessage(verificationCode));
                windowService.closeCurrentWindow();
            }
            catch (Exception)
            {
                AuthErrorText = "Email address is not valid.";
            }
        }

        public string VerificationCode() //String Containing 6 Random Numbers (Used For Email Verification)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Random randomNumber = new Random();

            for (int i = 0; i < 6; i++)
            {
                stringBuilder.Append(randomNumber.Next(10));
            }
            return stringBuilder.ToString();
        }
    }
}
