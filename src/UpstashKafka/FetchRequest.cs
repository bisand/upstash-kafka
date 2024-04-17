namespace UpstashKafka
{
    /// <summary>
    /// Represents a fetch request.
    /// </summary>
    public class FetchRequest
    {
        /// <summary>
        /// The fetch options.
        /// </summary>
        public int? Timeout { get; set; }
        /// <summary>
        /// The fetch options.
        /// </summary>
        public TopicPartitionOffset[] TopicPartitionOffsets { get; set; }
    }

}
