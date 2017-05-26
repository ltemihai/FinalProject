using System.ServiceModel;

namespace InstantMessengerInterfacesLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIInstantMessengerService" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IClient))]
    public interface IInstantMessengerService
    {
        [OperationContract]
        int Login(string username);

        [OperationContract]
        void Logout();

        [OperationContract]
        void SendMessage(string message, string username);
    }
}
