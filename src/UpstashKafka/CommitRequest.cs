namespace UpstashKafka
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
