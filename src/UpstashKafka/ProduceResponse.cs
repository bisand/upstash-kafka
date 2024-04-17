namespace UpstashKafka
{
    /// <summary>
    /// Represents the options for producing a message.
    /// </summary>
    public class ProduceResponse
    {
        /// <summary>
        /// The topic the message was produced to.
        /// </summary>
        public string Topic { get; set; }
        /// <summary>
        /// The partition the message was produced to.
        /// </summary>
        public int Partition { get; set; }
        /// <summary>
        /// The offset of the message.
        /// </summary>
        public int Offset { get; set; }
        /// <summary>
        /// The timestamp of the message.
        /// </summary>
        public long Timestamp { get; set; }
    }

}
