namespace UpstashKafka
{
    /// <summary>
    /// What to do when there is no initial offset in Kafka or if the current
    /// </summary>
    public enum KafkaAutoOffsetReset
    {
        earliest,
        latest,
        none
    }

}
