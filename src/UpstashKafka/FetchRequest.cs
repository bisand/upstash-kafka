namespace UpstashKafka
{
    /// <summary>
    /// Represents a fetch request.
    /// </summary>
    public class FetchRequest { int? timeout; TopicPartitionOffset[] topicPartitionOffsets; }

}
