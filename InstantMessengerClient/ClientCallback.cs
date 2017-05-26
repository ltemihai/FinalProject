using InstantMessengerInterfacesLibrary;
using System.ServiceModel;
using System.Windows;
using System;

namespace InstantMessengerClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class ClientCallback : IClient
    {
        public void GetMessage(string message, string username)
        {
            ((MainWindow)Application.Current.MainWindow).TakeMessage(message, username);
        }

        public void GetUpdate(int value)
        {
            
        }
    }
}
