# Upstash.Kafka.Client

An HTTP/REST based Kafka client built on top of
[Upstash REST API](https://docs.upstash.com/kafka/rest).

C# implementation of a client library using Upstash HTTP/REST api, suited for situations where HTTP is the only option.

> **Disclaimer**!  
This library is **not** associated with Upstash in any way, but it is inspired by the [javascript implementation from Upstash](https://github.com/upstash/upstash-kafka). Some of the text in this readme is borrowed from there.

# Installation

```bash
dotnet add package Upstash.Kafka.Client
```

# Quickstart

## Auth

1. Go to [upstash](https://console.upstash.com/kafka) and select your database.
2. Copy the `REST API` secrets at the bottom of the page

```csharp
using Upstash.Kafka.Client;

var settings = new UpstashSettings(
    url: "<UPSTASH_KAFKA_REST_URL>",
    username: "<UPSTASH_KAFKA_REST_USERNAME>",
    password: "<UPSTASH_KAFKA_REST_PASSWORD>"
);

using (var kafka = new Kafka(settings))
{
  // Implementation (Examples below).
}
```

## Produce a single message

```csharp
var producer = kafka.Producer;
var message = new { Amount = 108, Name = "Product 1" };

var result = await producer.ProduceAsync("test-topic", message);
```

## Produce multiple messages.

The same options from the example above can be set for every message.

```csharp
var producer = kafka.Producer;
var messages = new[]
    {
        new { Amount = 108, Name = "Product 1" },
        new { Amount = 42, Name = "Product 2" }
        new { Amount = 1337, Name = "Product 3" }
    };

var res = await producer.ProduceManyAsync("test-topic", messages);
```

## Consume

The first time a consumer is created, it needs to figure out the group
coordinator by asking the Kafka brokers and joins the consumer group. This
process takes some time to complete. That's why when a consumer instance is
created first time, it may return empty messages until consumer group
coordination is completed.

```csharp
//TODO: Write Example
```

## Commit manually

While `consume` can handle committing automatically, you can also use
`Consumer.commit` to manually commit.

```csharp
//TODO: Write Example
```

## Fetch

You can also manage offsets manually by using `Consumer.fetch`

```csharp
//TODO: Write Example
```

# Contributing

## Requirements


## Setup


## Running tests

```bash
```