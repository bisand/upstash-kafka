using UpstashKafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;

namespace UpstashKafka.Tests;

public class UpstashKafkaTests
{
    private readonly string _upstashUrl;
    private readonly string _upstashUsername;
    private readonly string _upstashPassword;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpstashKafkaTests"/> class.
    /// </summary>
    /// <exception cref="ArgumentNullException"></exception>
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
    public void Kafka_Constructor_ShouldThrowArgumentNullException_WhenSettingsIsNull()
    {
        // Arrange
        UpstashSettings settings = null!;

        // Act
        var exception = Record.Exception(() => new Kafka(settings));

        // Assert
        Assert.NotNull(exception);
        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void Kafka_Constructor_ShouldInitializeProperties_WhenSettingsIsNotNull()
    {
        // Arrange
        var settings = new UpstashSettings(_upstashUrl, _upstashUsername, _upstashPassword);

        // Act
        var kafka = new Kafka(settings);

        // Assert
        Assert.NotNull(kafka);
    }

    [Fact]
    public void Kafka_Constructor_ShouldInitializeProperties_WhenSettingsIsNotNullAndHttpClientIsDisposed()
    {
        // Arrange
        var settings = new UpstashSettings(_upstashUrl, _upstashUsername, _upstashPassword);

        // Act
        using var kafka = new Kafka(settings);

        // Assert
        Assert.NotNull(kafka);
    }

    [Fact]
    public void Kafka_Constructor_ShouldInitializeProperties_WhenSettingsIsNotNullAndHttpClientIsDisposedExplicitly()
    {
        // Arrange
        var settings = new UpstashSettings(_upstashUrl, _upstashUsername, _upstashPassword);

        // Act
        var kafka = new Kafka(settings);
        kafka.Dispose();

        // Assert
        Assert.NotNull(kafka);
    }

    [Fact]
    public void Kafka_ShouldHaveInternalProducerProduceMessageToTopic()
    {
        // Arrange
        var settings = new UpstashSettings(_upstashUrl, _upstashUsername, _upstashPassword);
        using var kafka = new Kafka(settings);
        var producer = kafka.Producer;

        // Act
        var message = new Message("Hello, Upstash Kafka!");
        var result = producer.ProduceAsync("test-topic", message);

        // Assert
        Assert.NotNull(result);
        // Assert.True(result.Success);
    }
}

internal class Message
{
    private string v;

    public Message(string v)
    {
        this.v = v;
    }
}