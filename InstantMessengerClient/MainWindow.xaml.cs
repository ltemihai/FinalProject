using InstantMessengerInterfacesLibrary;
using System.ServiceModel;
using System.Windows;

namespace InstantMessengerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static IInstantMessengerService Server;
        private static DuplexChannelFactory<IInstantMessengerService> channelFactory;
        public MainWindow()
        {
            InitializeComponent();
            channelFactory = new DuplexChannelFactory<IInstantMessengerService>(new ClientCallback(), "InstantMessengerServiceEndPoint");
            Server = channelFactory.CreateChannel();


        }

        public void TakeMessage(string message, string username)
        {
            DisplayTextBox.Text += username + " : " + message + "\n";
            DisplayTextBox.ScrollToEnd();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {


        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            int returnValue = Server.Login(UsernameTextBox.Text);
            if (returnValue == 1)
            {
                MessageBox.Show("Esti deja logat");
            }
            else if (returnValue == 0)
            {
                MessageBox.Show("Te-ai logat cu succes");
            }
            UsernameTextBox.IsEnabled = false;
            LoginButton.IsEnabled = false;
        }

        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageTextBox.Text.Length == 0)
            {
                return;
            }
            if (UsernameTextBox.Text == "Username")
            {
                return;
            }
            Server.SendMessage(MessageTextBox.Text, UsernameTextBox.Text);
            TakeMessage(MessageTextBox.Text, "You");
            MessageTextBox.Text = "";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Server.Logout();
        }
    }
}
