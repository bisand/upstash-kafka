using System.Net.Http;

namespace UpstashKafka
{
    public class Consumer
    {
        private HttpClient _client;

        public Consumer(HttpClient client)
        {
            _client = client;
        }
    }
}
