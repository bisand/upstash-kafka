namespace UpstashKafka
{
    /// <summary>
    /// Represents a committed request.
    /// </summary>
    public class CommittedRequest : BaseConsumerRequest { TopicPartition[] topicPartitions; };

}
