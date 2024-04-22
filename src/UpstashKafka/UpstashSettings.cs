namespace Upstash.Kafka.Client
{
    /// <summary>
    /// Represents the settings for Upstash.
    /// </summary>
    public class UpstashSettings
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="UpstashSettings"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public UpstashSettings(string url, string username, string password)
        {
            Url = url;
            Username = username;
            Password = password;
        }

        /// <summary>
        /// URL to the Upstash Kafka instance.
        /// </summary>
        public string Url { get; private set; }
        /// <summary>
        /// Username to authenticate with.
        /// </summary>
        public string Username { get; private set; }
        /// <summary>
        /// Password to authenticate with.
        /// </summary>
        public string Password { get; private set; }
    }
}