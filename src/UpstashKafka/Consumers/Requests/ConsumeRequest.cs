namespace Upstash.Kafka.Client.Consumers.Requests
{
    /// <summary>
    /// Represents a consume request.
    /// </summary>
    public class ConsumeRequest : BaseConsumerRequest
    {
        /// <summary>
        /// The topics to consume from.
        /// </summary>
        public string[] Topics { get; set; }
        /// <summary>
        /// Defines the time to wait at most for the fetch request in milliseconds.
        /// It's optional and its default value 1000.
        /// </summary>
        public int? Timeout { get; set; }
        /// <summary>
        /// If true, the consumer's offset will be periodically committed in the background.
        /// </summary>
        public bool? AutoCommit { get; set; }
        /// <summary>
        /// The frequency in milliseconds that the consumer offsets are auto-committed to Kafka
        /// if auto commit is enabled.
        /// Default is 5000.
        /// </summary>
        public int? AutoCommitInterval { get; set; }
        /// <summary>
        /// What to do when there is no initial offset in Kafka or if the current
        /// offset does not exist any more on the server. Default value is `latest`.
        /// 
        /// `earliest`: Automatically reset the offset to the earliest offset
        /// 
        /// `latest`: Automatically reset the offset to the latest offset
        /// 
        /// `none`: Throw exception to the consumer if no previous offset is found for the consumer's group.
        /// </summary>
        public KafkaAutoOffsetReset? AutoOffsetReset { get; set; } //"earliest" | "latest" | "none";
    }

}
