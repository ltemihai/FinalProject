using System;
using System.ServiceModel;

namespace InstantMessengerServer
{
    class Program
    {
        public static InstantMessengerService server;

        static void Main(string[] args)
        {
            server = new InstantMessengerService();
            using (ServiceHost host = new ServiceHost(server))
            {
                host.Open();
                Console.WriteLine("Server started");
                Console.ReadLine();
                Console.Beep();
            }
        }
    }
}
