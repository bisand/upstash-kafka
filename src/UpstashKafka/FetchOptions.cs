namespace UpstashKafka
{
    /// <summary>
    /// Represents the fetch options.
    /// </summary>
    public class FetchOptions
    {
        /// <summary>
        /// If true `fetch` will call upstash once for each topic in your request.
        /// This circumenvents the issue where upstash only returns from a single topic
        /// at a time when using fetch.
        /// 
        /// All requests are executed in parallel.
        /// 
        /// Default: true
        /// </summary>
        public bool? Parallel { get; set; }
    };

}
