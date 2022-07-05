using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory
{
    HostName = "localhost",
    UserName = "georyitt",
    Password = "hiphop20"
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare("geoQueue", false, false, false, null);
    
    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.Span;
        var message = Encoding.UTF8.GetString(body);
        
        Console.WriteLine("message receiver: {0}", message);
    };

    channel.BasicConsume("geoQueue", true, consumer);

}

Console.WriteLine("Press [enter] to exit.");
Console.ReadLine();