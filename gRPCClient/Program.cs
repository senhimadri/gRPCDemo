using Grpc.Net.Client;
using GrpcServer;


//var input = new HelloRequest { Name = "Him" };
//var channel = GrpcChannel.ForAddress("https://localhost:7257");
//var client = new Greeter.GreeterClient(channel);
//var replay = await client.SayHelloAsync(input);
//Console.WriteLine(replay.Message);

var channel = GrpcChannel.ForAddress("https://localhost:7257");
var customerClient = new Customer.CustomerClient(channel);

var clientRequest = new CustomerLookupModel()
{
    UserId = 1
};

var customer = await customerClient.GetCustomerInfoAsync(clientRequest);

Console.WriteLine($" First Name : {customer.FirstName } and Last Name : {customer.LastName }");

Console.ReadLine();
