using System;
using System.Collections.Generic;

namespace UpstashKafka
{
    /// <summary>
    /// Represents the options for producing a message.
    /// </summary>
    public class ProduceOptions
    {
        /// <summary>
        /// The partition to produce to.
        /// Will be assigned by kafka if left empty.
        /// </summary>
        public int? Partition { get; set; }
        /// <summary>
        /// The timestamp for the message.
        /// </summary>
        public TimeSpan? Timestamp { get; set; }
        /// <summary>
        /// The key for the message.
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// The headers for the message.
        /// </summary>
        public IDictionary<string, string> Headers { get; set; }
    };
}
