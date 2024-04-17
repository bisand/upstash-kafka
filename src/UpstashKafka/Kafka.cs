using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace UpstashKafka
{
    /// <summary>
    /// Represents the settings for Upstash.
    /// </summary>
    public class Kafka : IDisposable
    {
        private readonly UpstashSettings _settings;
        private readonly HttpClient _client;
        private bool disposedValue;

        /// <summary>
        /// Kafka producer.
        /// </summary>
        public Producer Producer { get; private set; }
        /// <summary>
        /// Kafka consumer.
        /// </summary>
        public Consumer Consumer { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Kafka"/> class.
        /// </summary>
        /// <param name="settings">The Upstash settings.</param>
        public Kafka(UpstashSettings settings)
        {
            if (settings is null)
            {
                throw new ArgumentNullException(nameof(settings));
            }
            _settings = settings;
            _client = BuildNewHttpClient(settings);
            Producer = new Producer(_client);
            Consumer = new Consumer(_client);
        }

        private static HttpClient BuildNewHttpClient(UpstashSettings settings)
        {
            return new HttpClient(handler: BuildNewStandardSocketsHttpHandler(), disposeHandler: true)
            {
                BaseAddress = new Uri(settings.Url),
                DefaultRequestHeaders = {
                    Authorization= new AuthenticationHeaderValue(
                        "Basic",
                        Convert.ToBase64String(
                            System.Text.Encoding.ASCII.GetBytes($"{settings.Username}:{settings.Password}")
                        )
                    )
                }
            };
        }

        private static StandardSocketsHttpHandler BuildNewStandardSocketsHttpHandler()
        {
            return
                new StandardSocketsHttpHandler()
                {
                    // The maximum idle time for a connection in the pool. When there is no request in
                    // the provided delay, the connection is released.
                    // Default value in .NET 6: 1 minute
                    PooledConnectionIdleTimeout = TimeSpan.FromMinutes(1),

                    // This property defines maximal connection lifetime in the pool regardless
                    // of whether the connection is idle or active. The connection is reestablished
                    // periodically to reflect the DNS or other network changes.
                    // ⚠️ Default value in .NET 6: never
                    //    Set a timeout to reflect the DNS or other network changes
                    PooledConnectionLifetime = TimeSpan.FromMinutes(10),
                };
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="Kafka" /> and optionally releases the managed resources.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _client.Dispose();
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the <see cref="Kafka" />.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
