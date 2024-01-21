using Kabutar.Consumer;

var topicName = "test2";
var serverUri = "http://localhost:80";

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
                    serverUri: serverUri))
         .WithHttpClient(httpClient)
         .StartAsync();

    foreach (var message in deliveryResult.Messages)
    {
        Console.WriteLine($"Received message: topic - {message.Topic}, data: {message.Data}");
    }
}
