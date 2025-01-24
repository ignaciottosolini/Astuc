using Astuc.Domain.DTOs;
using Astuc.Domain.Entities;
using EIRL.Application.Services;
using EIRL.Infrastructure.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace EIRL.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactoController : ControllerBase
    {
        private readonly SendEmailService _sendEmailService;


        public ContactoController(SendEmailService emailService)
        {
            _sendEmailService = emailService;
        }
        public class EmailRequest
        {
            public string Email { get; set; }
            public string Name { get; set; }
            public int Phone { get; set; }
            public string Subject { get; set; }
            public string Message { get; set; } 
        }




        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailRequest request)
        {
            var fullMessage = $"{request.Message}\n" +
                $"Email: {request.Email}\n" +
                $"Celular: {request.Phone}\n";
            var fullSubject = $"Contacto de {request.Name}, Tema: {request.Message}";
            try
            {
            await _sendEmailService.SendEmailAsync("darondaily013@gmail.com", fullSubject, fullMessage);
                return Ok(new { Message = "Email sended" });


            }
            catch (Exception e)
            {
                return BadRequest(new { Message = "Error to send Email" });

                throw;
            }

        }


    }
}
