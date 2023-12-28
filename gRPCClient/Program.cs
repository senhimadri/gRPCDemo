using Grpc.Core;
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
Console.WriteLine();

Console.WriteLine("New Customer");
Console.WriteLine();


using (var call = customerClient.GetNewCustomer(new NewCustomerRequest()))
{
    while(await call.ResponseStream.MoveNext())
    {
        var currentCustomer = call.ResponseStream.Current;

        Console.WriteLine($" First Name : {currentCustomer.FirstName} and Last Name : {currentCustomer.LastName} and Email :{currentCustomer.EmailAddress}");
    }
}

Console.ReadLine();
