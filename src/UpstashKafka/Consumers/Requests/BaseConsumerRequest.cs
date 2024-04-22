namespace Upstash.Kafka.Client.Consumers.Requests
{
    /// <summary>
    /// Represents the Kafka consumer request.
    /// </summary>
    public class BaseConsumerRequest
    {
        /// <summary>
        /// The name of the consumer group which is used as Kafka consumer group id
        /// @see https://kafka.apache.org/documentation/#consumerconfigs_group.id
        /// </summary>
        public string ConsumerGroupId { get; set; }

        /// <summary>
        /// Used to identify kafka consumer instances in the same consumer group.
        /// Each consumer instance id is handled by a separate consumer client.
        /// @see https://kafka.apache.org/documentation/#consumerconfigs_group.instance.id
        /// </summary>
        public string InstanceId { get; set; }
    }

}
