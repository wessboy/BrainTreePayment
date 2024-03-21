using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainTreePayment.Business.Layer.Data;

     public class ClientOrder
    {
      public BookPurchaseVM BookPurchaseVM { get; set; }
      public string ClientToken { get; set; } 
    }

