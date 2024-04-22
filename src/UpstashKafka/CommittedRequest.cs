using Upstash.Kafka.Client.Consumers.Models;
using Upstash.Kafka.Client.Consumers.Requests;

namespace Upstash.Kafka.Client
{
    /// <summary>
    /// Represents a committed request.
    /// </summary>
    public class CommittedRequest : BaseConsumerRequest
    {
        /// <summary>
        /// The topic partitions to commit.
        /// </summary>
        public TopicPartition[] TopicPartitions { get; set; }

    }
}