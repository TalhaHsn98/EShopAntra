using Microsoft.Extensions.Options;
using OrderService.Events;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace OrderService.Messaging
{
    public class RabbitMqOrderEventPublisher : IOrderEventPublisher, IAsyncDisposable
    {
        private readonly RabbitMqOptions options;
        private readonly IConnection connection;

        public RabbitMqOrderEventPublisher(IOptions<RabbitMqOptions> optionsAccessor)
        {
            options = optionsAccessor.Value;

            var factory = new ConnectionFactory
            {
                HostName = options.HostName,
                Port = options.Port,
                UserName = options.UserName,
                Password = options.Password,
                VirtualHost = options.VirtualHost,
                ClientProvidedName = "orders-publisher"
            };

            connection = factory.CreateConnectionAsync().GetAwaiter().GetResult();
            EnsureTopologyAsync().GetAwaiter().GetResult();
        }

        public async Task PublishOrderCompletedAsync(OrderCompletedEvent message)
        {
            await using var channel = await connection.CreateChannelAsync();

            var payload = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(payload);

            var props = new BasicProperties();
            props.ContentType = "application/json";
            props.DeliveryMode = DeliveryModes.Persistent;

            await channel.BasicPublishAsync(
                options.Exchange,
                options.RoutingKeyCompleted,
                false,
                props,
                body);
        }

        private async Task EnsureTopologyAsync()
        {
            await using var channel = await connection.CreateChannelAsync();

            await channel.ExchangeDeclareAsync(
                options.Exchange,
                options.ExchangeType,
                options.Durable,
                false,
                null);

            await channel.QueueDeclareAsync(
                options.QueueCompleted,
                options.Durable,
                false,
                false,
                null);

            await channel.QueueBindAsync(
                options.QueueCompleted,
                options.Exchange,
                options.RoutingKeyCompleted,
                null);
        }

        public async ValueTask DisposeAsync()
        {
            await connection.DisposeAsync();
        }
    }


}