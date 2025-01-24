
using Astuc.Domain.DTOs;
using Astuc.Domain.Entities;
using EIRL.Application.Services;
using EIRL.Application.Services.Common;
using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Client;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace EIRL.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MercadoPagoController : ControllerBase
    {
        public MercadoPagoController()
        {
        }


        [HttpPost("/process_payment")]
        public async Task<IActionResult> Create(PaymentRequest request)
        {
            //MercadoPagoConfig.AccessToken = "TEST-2800454784395180-010310-ea81dcf6c11fcb4d9bc692be29798747-485585466";

            MercadoPagoConfig.AccessToken = "APP_USR-7268068929980524-040715-fa472db5f1a3880dd1059252403496ee-493157048";

            var requestOptions = new RequestOptions();
            requestOptions.CustomHeaders.Add("Authorization", "Bearer " + MercadoPagoConfig.AccessToken);
            requestOptions.CustomHeaders.Add("Content-Type", "application/json");
            requestOptions.CustomHeaders.Add("x-idempotency-key", request.token);


            var paymentRequest = new PaymentCreateRequest
            {
                TransactionAmount = request.transaction_amount,
                Token = request.token,
                Installments = request.installments,
                PaymentMethodId = request.payment_method_id,
                Payer = new PaymentPayerRequest
                {
                    Email = request.payer.email
                },
                Description = "Compra en Astuc"
            };

            var client = new PaymentClient();
            Payment payment = await client.CreateAsync(paymentRequest, requestOptions);

            return Ok(payment);
        }

        public class PaymentRequest
        {
            public string payment_method_id { get; set; }
            public decimal transaction_amount { get; set; }
            public PayerRequest payer { get; set; }
            public string token { get; set; }
            public int installments { get; set; }
        }

        public class PayerRequest
        {
            public string email { get; set; }
        }


    }
}

