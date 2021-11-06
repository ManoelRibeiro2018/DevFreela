using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Insfrastructure.Payment
{
    public class PaymentService : IPaymentService
    {
        public Task<bool> PorcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            //TODO - Implementar logica de pagamento com Gateway de pagamento

            return Task.FromResult(true);
        }
    }
}
