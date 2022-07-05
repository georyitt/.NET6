using System.Text;
using RabbitMQ.Client;

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
    
    var message = "hello world from geo";
    var body = Encoding.UTF8.GetBytes(message);
    
    channel.BasicPublish("", "geoQueue", null, body);
    Console.WriteLine("sent {0}", message);
}

Console.WriteLine("Press [enter] to exit.");
Console.ReadLine();

