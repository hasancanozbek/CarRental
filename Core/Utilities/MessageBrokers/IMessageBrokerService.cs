
namespace Core.Utilities.MessageBrokers
{
    public interface IMessageBrokerService
    {
        void PublishMessage<T>(T message);
    }
}
