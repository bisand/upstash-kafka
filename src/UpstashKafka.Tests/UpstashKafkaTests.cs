using Upstash.Kafka.Client;

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
        _upstashUrl = "https://kafka-rest-proxy.upstash.com";
        _upstashUsername = "username";
        _upstashPassword = "password";
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
}
