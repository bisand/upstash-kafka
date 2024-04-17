using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace UpstashKafka
{
    /// <summary>
    /// Represents the Kafka producer.
    /// </summary>
    public class Producer
    {
        private HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Producer"/> class.
        /// </summary>
        /// <param name="client"></param>
        public Producer(HttpClient client)
        {
            this._client = client;
        }

        /// <summary>
        /// Produce a message.
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        /// <param name="opts"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<object> ProduceAsync<TMessage>(string topic, TMessage message, ProduceOptions opts = null)
        {
            string value = string.Empty;
            if (typeof(TMessage) == typeof(string))
            {
                value = message as string;
            }
            else
            {
                JsonSerializer.Serialize(message)
            }
            var produceRequest = new ProduceRequest
            {
                Topic = topic,
                Value =  value,
            };

            HttpContent content = new StringContent(JsonSerializer.Serialize(produceRequest));
            var httpResponseMessage = await _client.PostAsync("/produce", content);
            httpResponseMessage.EnsureSuccessStatusCode();
            var response = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<object>(response);
        }
    }
}
