
using InstantMessengerInterfacesLibrary;
using System;
using System.Collections.Concurrent;
using System.ServiceModel;

namespace InstantMessengerServer
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class InstantMessengerService : IInstantMessengerService
    {
        public ConcurrentDictionary<string, ConnectedClient> connectedClients = new ConcurrentDictionary<string, ConnectedClient>();

        public int Login(string username)
        {

            foreach (var clientSentinel in connectedClients)
            {
                if (clientSentinel.Key.ToLower() == username.ToLower())
                {
                    return 1;
                }
            }
            var establishedUserConnection = OperationContext.Current.GetCallbackChannel<IClient>();
            ConnectedClient client = new ConnectedClient();
            client.connection = establishedUserConnection;
            client.Username = username;

            connectedClients.TryAdd(username, client);

            Console.WriteLine("Client login: {0} at {1}", client.Username, System.DateTime.Now);

            return 0;
        }

        public void Logout()
        {
            ConnectedClient client = GetClient();
            if (client != null)
            {
                ConnectedClient removedClient;
                connectedClients.TryRemove(client.Username, out removedClient);

                Console.WriteLine("Client logoff: {0} at {1}", removedClient.Username, System.DateTime.Now);
            }
        }


        public ConnectedClient GetClient()
        {
            var establishedUserConnection = OperationContext.Current.GetCallbackChannel<IClient>();

            foreach (var clientSentinel in connectedClients)
            {
                if (clientSentinel.Value.connection == establishedUserConnection)
                {
                    return clientSentinel.Value;
                }
            }
            return null;
        }

        public void SendMessage(string message, string username)
        {
            foreach (var clientSentinel in connectedClients)
            {
                if (clientSentinel.Key.ToLower() != username.ToLower())
                {
                    clientSentinel.Value.connection.GetMessage(message, username);
                }
            }
        }

        private void updateRespone(int value)
        {
            
        }
    }
}
