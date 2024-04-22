using Microsoft.Extensions.Configuration;
using Upstash.Kafka.Client;

namespace UpstashKafka.Tests.Integration;

public class UpstashKafkaTests
{
    private readonly string _upstashUrl;
    private readonly string _upstashUsername;
    private readonly string _upstashPassword;

    public UpstashKafkaTests()
    {
        var root = Directory.GetCurrentDirectory();
        var dotenv = Path.Combine(root, ".env");
        DotEnv.Load(dotenv);

        var config = new ConfigurationBuilder()
                    .AddEnvironmentVariables()
                    .Build();
        var env = config.AsEnumerable().ToDictionary(x => x.Key, x => x.Value);
        if (!env.TryGetValue("UPSTASH_KAFKA_REST_URL", out _upstashUrl!))
        {
            throw new ArgumentNullException("UPSTASH_KAFKA_REST_URL", "Please provide the Upstash Kafka REST URL via the environment variable UPSTASH_KAFKA_REST_URL.");
        }
        if (!env.TryGetValue("UPSTASH_KAFKA_REST_USERNAME", out _upstashUsername!))
        {
            throw new ArgumentNullException("UPSTASH_KAFKA_REST_USERNAME", "Please provide the Upstash Kafka REST username via the environment variable UPSTASH_KAFKA_REST_USERNAME.");
        }
        if (!env.TryGetValue("UPSTASH_KAFKA_REST_PASSWORD", out _upstashPassword!))
        {
            throw new ArgumentNullException("UPSTASH_KAFKA_REST_PASSWORD", "Please provide the Upstash Kafka REST password via the environment variable UPSTASH_KAFKA_REST_PASSWORD.");
        }
    }

    [Fact]
    public async Task Kafka_ShouldHaveInternalProducerProduceMessageToTopicAsync()
    {
        // Arrange
        var settings = new UpstashSettings(_upstashUrl, _upstashUsername, _upstashPassword);
        using var kafka = new Kafka(settings);
        var producer = kafka.Producer;

        // Act
        var message = new TestMessage("Hello, Upstash Kafka!", DateTime.UtcNow);
        var result = await producer.ProduceAsync("test", message);

        // Assert
        Assert.NotNull(result);
        // Assert.True(result.Success);
    }

    [Fact]
    public async Task Kafka_ShouldHaveInternalProducerProduceMultipleMessagesToTopicAsync()
    {
        // Arrange
        var settings = new UpstashSettings(_upstashUrl, _upstashUsername, _upstashPassword);
        using var kafka = new Kafka(settings);
        var producer = kafka.Producer;

        var messages = new List<TestMessage>();
        // Act
        foreach (var i in Enumerable.Range(1, 10))
        {
            messages.Add(new TestMessage($"Hello, Upstash Kafka! {i}", DateTime.UtcNow));
        }
        var result = await producer.ProduceManyAsync("test", messages);

        // Assert
        Assert.NotNull(result);
    }
}

internal record TestMessage(string Value, DateTime UtcTime);
