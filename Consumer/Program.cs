using Kabutar.Consumer;

var topicName = "test";
var serverUri = "http://localhost:5095";

var httpClient = new HttpClient();

DeliveryResult deliveryResult;


Console.WriteLine($"Consumer is started");

await Task.Delay(5000);

while(true)
{
    deliveryResult = 
       await new Consume(
                new Topic(
                    name: topicName,
                    server: new Server(
                        serverUri: serverUri)))
         .WithHttpClient(httpClient)
         .StartAsync();

    foreach (var message in deliveryResult.Messages)
    {
        Console.WriteLine($"Received message: topic - {message.Topic}, data: {message.Data}");
    }
}
