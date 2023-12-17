﻿using System.Text.Json.Serialization;

namespace Kabutar.Producer;

public class Topic
{
    public Topic(string name, Server server)
    {
        Name = name;
        Server = server;
    }

    public string Name { get; set; }

    public Server Server { get; set; }
    
    public static Topic Empty => new Topic(name: string.Empty, Server.Empty);
}
