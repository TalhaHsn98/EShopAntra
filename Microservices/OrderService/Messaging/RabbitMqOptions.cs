namespace OrderService.Messaging
{
    public class RabbitMqOptions
    {
        public string HostName { get; set; } = "localhost";
        public int Port { get; set; } = 5672;
        public string UserName { get; set; } = "guest";
        public string Password { get; set; } = "guest";
        public string VirtualHost { get; set; } = "/";
        public string Exchange { get; set; } = "order.exchange";
        public string ExchangeType { get; set; } = "topic";
        public string RoutingKeyCompleted { get; set; } = "order.completed";
        public string QueueCompleted { get; set; } = "order.completed.queue";
        public bool Durable { get; set; } = true;
    }
}
