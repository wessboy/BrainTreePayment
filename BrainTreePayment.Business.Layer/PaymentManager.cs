using Braintree;
using BrainTreePayment.Infrastructure;
using BrainTreePayment.Business.Layer.Data;
namespace BrainTreePayment.Business.Layer;

public class PaymentManager : IPaymentManager
{
    private readonly IBrainTreeService _brainTreeService;
    public PaymentManager(IBrainTreeService brainTreeService)
    {
        _brainTreeService = brainTreeService;
    }
    public ClientOrder ClientOrderProcessingHandler(BookPurchaseVM order)
    {
        var gateway = _brainTreeService.GetGateway();
        var clientToken = gateway.ClientToken.Generate();

       ClientOrder clientOrder = new ClientOrder { BookPurchaseVM = order,ClientToken = clientToken};

        return clientOrder;
        
    }

    public bool ClientPaymentProcessingHandler(BookPurchaseVM order)
    {
        var gateway = _brainTreeService.GetGateway();
        var request = new TransactionRequest
        {
            Amount = Convert.ToDecimal("250"),
            PaymentMethodNonce = order.Nonce,
            Options = new TransactionOptionsRequest
            {
                SubmitForSettlement = true,
                

                
            }
        };

        Result<Transaction> result = gateway.Transaction.Sale(request);

        if (result.IsSuccess())
        {
            return true;
        }
        else
        {
            return false;
        }
    }




    //end
}


