using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApp.MVVM
{
    public class VerificationCodeMessage : ValueChangedMessage<string>
    {
        public VerificationCodeMessage(string value) : base(value)
        {
        }
    }
}
