using Kabutar.Consumer;

var topicName = "test";
var serverUri = "http://localhost:5095";

var httpClient = new HttpClient();

var deliveryResult = 
    await new Consume(
            new Topic(
                name: topicName,
                server: new Server(
                    serverUri: serverUri)))
     .WithHttpClient(httpClient)
     .StartAsync();
 