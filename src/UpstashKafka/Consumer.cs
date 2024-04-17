using System.Net.Http;

namespace UpstashKafka
{
    /// <summary>
    /// Represents the Kafka consumer.
    /// </summary>
    public class Consumer
    {
        private HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Consumer"/> class.
        /// </summary>
        /// <param name="client"></param>
        public Consumer(HttpClient client)
        {
            _client = client;
        }
    }

}
