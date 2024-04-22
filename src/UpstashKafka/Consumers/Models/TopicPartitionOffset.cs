namespace Upstash.Kafka.Client.Consumers.Models
{
    /// <summary>
    /// Represents a topic, partition and offset.
    /// </summary>
    public class TopicPartitionOffset : TopicPartition { int offset; }

}
