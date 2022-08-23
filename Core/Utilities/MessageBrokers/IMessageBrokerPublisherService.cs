
namespace Core.Utilities.MessageBrokers
{
    public interface IMessageBrokerPublisherService
    {
        void PublishMessage<T>(T message);
    }
}
