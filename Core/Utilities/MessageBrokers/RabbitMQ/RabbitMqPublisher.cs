
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace Core.Utilities.MessageBrokers.RabbitMQ
{
    public class RabbitMqPublisher : IMessageBrokerPublisherService
    {
        public void PublishMessage<T>(T message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue:"Mail-MessageQueue", durable:true, exclusive:false, autoDelete:false);

            var jsonMessage = JsonSerializer.Serialize(message);
            var byteMessage = Encoding.UTF8.GetBytes(jsonMessage);
            
            channel.BasicPublish(exchange:"", routingKey:"Mail-MessageQueue", body:byteMessage);
        }
    }
}
