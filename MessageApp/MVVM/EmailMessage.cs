using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.MVVM
{
    internal class EmailMessage : ValueChangedMessage<string>
    {
        public EmailMessage(string value) : base(value)
        {
        }
    }
}
