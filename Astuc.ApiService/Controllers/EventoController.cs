
using Astuc.Domain.DTOs;
using Astuc.Domain.Entities;
using EIRL.Application.Services;
using EIRL.Application.Services.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EIRL.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;


        public EventoController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var evento = await _eventoService.GetAllAsync();
            return Ok(evento);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evento = await _eventoService.GetByIdAsync(id);
            if (evento == null) return NotFound();
            return Ok(evento);
        }


        [HttpPost]
        public async Task<IActionResult> Create(EventoDTO evento)
        {
            await _eventoService.CreateAsync(evento);
            return CreatedAtAction(nameof(GetById), new { id = evento.Id }, evento);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EventoDTO evento)
        {
            try
            {
                if (id != evento.Id)
                {
                    return BadRequest();
                }
                await _eventoService.UpdateAsync(evento);
                return Ok(evento);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _eventoService.DeleteAsync(id);
            return NoContent();
        }
    }
}

