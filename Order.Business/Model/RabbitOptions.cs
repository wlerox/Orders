namespace Order.Business.Model
{
    public class RabbitOptions
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string HostName { get; set; }

        public int Port { get; set; }

        public string VHost { get; set; } = "/";
    }
}
