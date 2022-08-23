
using System.Text;
using System.Text.Json;
using Entities.DTOs;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Listening...");
var factory = new ConnectionFactory { HostName = "localhost"};
var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

var consumer = new EventingBasicConsumer(channel);
channel.QueueDeclare(queue: "Mail-MessageQueue", durable: true, exclusive: false, autoDelete: false);
channel.BasicConsume("Mail-MessageQueue", false, consumer);
consumer.Received += (object sender, BasicDeliverEventArgs e) =>
 {
    var body = e.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    var rentInformation = JsonSerializer.Deserialize<RentInformationDto>(message);
    Thread.Sleep(5000);
    Console.WriteLine("E-mail was sent to "+rentInformation.CustomerEmail);
    channel.BasicAck(e.DeliveryTag,false);

};
    Console.ReadLine();

