using Kabutar.Producer;

var serverUri = "http://localhost:5095";
var topicName = "test";

var httpClient = new HttpClient();

var deliveryResult = 
    await new Publish(
            new Message(
                new Topic(
                    name: topicName,
                    server: new Server(
                        serverUri)),
                data: "Hello world!"))
    .WithHttpClient(httpClient)
    .StartAsync();
