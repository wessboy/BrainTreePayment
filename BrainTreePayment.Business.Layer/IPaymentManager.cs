using BrainTreePayment.Business.Layer.Data;

namespace BrainTreePayment.Business.Layer;

     public interface IPaymentManager
    {
            
    public ClientOrder ClientOrderProcessingHandler(BookPurchaseVM order);
    public bool  ClientPaymentProcessingHandler(BookPurchaseVM order);  
    }

