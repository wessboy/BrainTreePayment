using Braintree;

namespace BrainTreePayment.Infrastructure;

public interface IBrainTreeService
    {
       IBraintreeGateway CreateGateway();
        IBraintreeGateway GetGateway();
    }

