using System.ServiceModel;

namespace InstantMessengerInterfacesLibrary
{
    public interface IClient
    {
        [OperationContract]
        void GetMessage(string message, string username);

        [OperationContract]
        void GetUpdate(int value);
    }
}
