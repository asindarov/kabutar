using Kabutar.Producer;

var serverUri = "http://localhost:5095";
var topicName = "test";

var httpClient = new HttpClient();

Console.WriteLine($"Producer is started");

await Task.Delay(5000);

for (int i = 0; true; i++)
{
    await new Publish(
                new Message(
                    new Topic(
                        name: topicName,
                        server: new Server(
                            serverUri)),
                    data: $"{i}) Hello world!"))
        .WithHttpClient(httpClient)
        .StartAsync();

    Console.WriteLine($"Message is published {i}");
}
