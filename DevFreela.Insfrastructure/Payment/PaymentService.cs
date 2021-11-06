using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DevFreela.Insfrastructure.Payment
{
    public class PaymentService : IPaymentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _paymentsBaseUrl;

        public PaymentService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _paymentsBaseUrl = configuration.GetSection("Services:Payments").Value;
        }
        public async Task<bool> PorcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            //TODO - Implementar logica de pagamento com Gateway de pagamento
            var url = $"{_paymentsBaseUrl}/api/Payments";
            var paymentInforJson = JsonSerializer.Serialize(paymentInfoDTO);

            var paymentInforContent = new StringContent(
                paymentInforJson,
                Encoding.UTF8,
                "application/json"
                );

            var httpClient = _httpClientFactory.CreateClient("Payments");

            var response = await httpClient.PostAsync(url, paymentInforContent);

            return response.IsSuccessStatusCode;
        }
    }
}
