using System.ServiceModel;

namespace InstantMessengerInterfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIInstantMessengerService" in both code and config file together.
    [ServiceContract]
    public interface IInstantMessengerService
    {
        [OperationContract]
        void DoWork();
    }
}
