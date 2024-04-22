using Upstash.Kafka.Client.Consumers.Models;
using Upstash.Kafka.Client.Consumers.Requests;

namespace Upstash.Kafka.Client
{
    /// <summary>
    /// Represents a commit request.
    /// </summary>
    public class CommitRequest : BaseConsumerRequest
    {
        /// <summary>
        /// Commits the last consumed messages if left empty.
        /// </summary>
        public TopicPartitionOffset[] Offset { get; set; }
    };

}
