using System.Net.Http;

namespace UpstashKafka
{
    public class Kafka
    {
        private readonly UpstashSettings _settings;

        private readonly IHttpClientFactory _factory;

        public Kafka()
        {

        }
        public Kafka(UpstashSettings settings)
        {
            _settings = settings;
        }

    }
}
