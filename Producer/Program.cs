using Kabutar.Producer;

var serverUri = "http://localhost:5095";

var httpClient = new HttpClient();

var response = await new Publish(new Message(new Topic(name: "test", serverUri: serverUri), data: "Hello world!"))
    .WithHttpClient(httpClient)
    .SendAsync();

Console.WriteLine();
