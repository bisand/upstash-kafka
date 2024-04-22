using Upstash.Kafka.Client.Producers.Models;

namespace Upstash.Kafka.Client.Producers.Requests
{
    /// <summary>
    /// Request payload to produce a message to a topic.
    /// </summary>
    public class ProduceRequest : ProduceOptions
    {
        /// <summary>
        /// The topic the message should be produced to.
        /// Make sure this exists in upstash before. Otherwise it will throw an error.
        /// </summary>
        public string Topic { get; set; }
        /// <summary>
        /// The message to be produced. This will be serialized using `System.Text.Json.JsonSerializer`.
        /// </summary>
        public object Value { get; set; }
    }
}
