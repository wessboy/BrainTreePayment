using Braintree;
using BrainTreePayment.Infrastructure.Layer;
using Microsoft.Extensions.Configuration;

namespace BrainTreePayment.Infrastructure;

public class BrainTreeService : IBrainTreeService
{
    private readonly IConfiguration _configuration;
    public BrainTreeService(IConfiguration configuration)
    {

        _configuration = configuration;

    }
    public IBraintreeGateway CreateGateway()
    {
        BraintreeGateway newGateway = new BraintreeGateway()
        {
            Environment = Braintree.Environment.SANDBOX,
            MerchantId = Utility.MerchantId,
            PublicKey = Utility.PublicKey,
            PrivateKey = Utility.PrivateKey
        };

        return newGateway;
    }

    public IBraintreeGateway GetGateway()
    {
        return CreateGateway();
    }
}

