using Grpc.Core;

namespace GrpcServer.Services;

public class CustomersService : Customer.CustomerBase
{

	private readonly ILogger<CustomersService> _logger;


	public CustomersService(ILogger<CustomersService> logger)
	{
		_logger = logger;
	}

    public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
    {
		CustomerModel output = new CustomerModel();

		if(request.UserId==1)
		{
			output.FirstName = "Himadri Sen";
			output.LastName = "Smith";
        }
        else if (request.UserId == 2)
        {
            output.FirstName = "Alamin Khan";
            output.LastName = "Sheke";
        }

        else if (request.UserId == 3)
        {
            output.FirstName = "Nakib Choudhori";
            output.LastName = "Rakib";
        }
        else
        {
            output.FirstName = "Other";
            output.LastName = "Other";
        }
        return Task.FromResult(output);
    }
}

