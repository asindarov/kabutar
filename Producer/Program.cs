using Kabutar.Producer;

var serverUri = "http://localhost:80";
var topicName = "test2";

var httpClient = new HttpClient();

Console.WriteLine($"Producer is started");

await Task.Delay(5000);

for (int i = 0; true; i++)
{
    await new Publish(
                new Message(
                    new Topic(
                        name: topicName,
                        serverUri: serverUri),
                    data: $"{i}) Hello world!"))
        .WithHttpClient(httpClient)
        .StartAsync();

    Console.WriteLine($"Message is published {i}");
}

/*
    var newMessage = new Message(
                    new Topic(
                        name: topicName,
                        server: new Server(
                            serverUri)),
                    data: $"{i}) Hello world!");
                    
     await new HttpRequest(
        new HttpClient(),   
        new Publish(newMessage);
    )
    .SendAsync();
 */
