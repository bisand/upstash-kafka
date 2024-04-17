using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly JsonSerializerOptions _defaultJsonSerializerOptions;
        private readonly HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="Producer"/> class.
        /// </summary>
        /// <param name="client"></param>
        public Producer(HttpClient client)
        {
            _client = client;
            _defaultJsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault
            };
        }

        /// <summary>
        /// Produce a message.
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="message"></param>
        /// <param name="opts"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ProduceResponse> ProduceAsync<TMessage>(string topic, TMessage message, ProduceOptions opts = null)
        {
            bool messageIsString = typeof(TMessage) == typeof(string);
            var produceRequest = new ProduceRequest
            {
                Topic = topic,
                Value = messageIsString ? message as string : JsonSerializer.Serialize(message),
            };

            var stringContent = JsonSerializer.Serialize(produceRequest, _defaultJsonSerializerOptions);

            HttpContent content = new StringContent(stringContent, System.Text.Encoding.UTF8, messageIsString ? "text/plain" : "application/json");
            var httpResponseMessage = await _client.PostAsync("produce", content);
            httpResponseMessage.EnsureSuccessStatusCode();
            var response = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProduceResponse[]>(response, _defaultJsonSerializerOptions).FirstOrDefault();
        }

        /// <summary>
        /// Produce many messages.
        /// </summary>
        /// <typeparam name="TMessage"></typeparam>
        /// <param name="topic"></param>
        /// <param name="messages"></param>
        /// <param name="opts"></param>
        /// <returns></returns>
        public async Task<ProduceResponse[]> ProduceManyAsync<TMessage>(string topic, IList<TMessage> messages, ProduceOptions opts = null)
        {
            bool messageIsString = typeof(TMessage) == typeof(string);
            var produceRequest = new List<ProduceRequest>();
            foreach (var message in messages)
            {
                produceRequest.Add(new ProduceRequest
                {
                    Topic = topic,
                    Value = messageIsString ? message as string : JsonSerializer.Serialize(message, _defaultJsonSerializerOptions),
                });
            }

            var stringContent = JsonSerializer.Serialize(produceRequest, _defaultJsonSerializerOptions);

            HttpContent content = new StringContent(stringContent, System.Text.Encoding.UTF8, messageIsString ? "text/plain" : "application/json");
            var httpResponseMessage = await _client.PostAsync("produce", content);
            httpResponseMessage.EnsureSuccessStatusCode();
            var response = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProduceResponse[]>(response, _defaultJsonSerializerOptions);
        }
    }
}
