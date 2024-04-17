namespace UpstashKafka
{
    /// <summary>
    /// What to do when there is no initial offset in Kafka or if the current
    /// </summary>
    public enum KafkaAutoOffsetReset
    {
        /// <summary>
        /// Automatically reset the offset to the earliest offset
        /// </summary>
        earliest,
        /// <summary>
        /// Automatically reset the offset to the latest offset
        /// </summary>
        latest,
        /// <summary>
        /// Throw exception to the consumer if no previous offset is found for the consumer's group.
        /// </summary>
        none
    }

}
