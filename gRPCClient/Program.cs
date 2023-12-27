using Grpc.Net.Client;
using GrpcServer;


var input = new HelloRequest { Name = "Him" };

var channel = GrpcChannel.ForAddress("https://localhost:7257");

var client = new Greeter.GreeterClient(channel);

var replay = await client.SayHelloAsync(input);

Console.WriteLine(replay.Message);

Console.ReadLine();
